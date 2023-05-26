using System.Net.Mail;
using System.Net;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using MailingSystem.Consumer.Models;
using MailingSystem.Consumer.Services;

public class Consumer
{
    private readonly IMailingServiceFactory _mailingServiceFactory;

    public Consumer(IMailingServiceFactory mailingService)
    {
        _mailingServiceFactory = mailingService;
    }

    public void StartConsuming()
    {
        ConnectionFactory factory = new();
        factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
        factory.ClientProvidedName = "Rabbit Consumer";

        IConnection connection = factory.CreateConnection();
        IModel channel = connection.CreateModel();

        string exchangeName = "DemoExchange";
        string routingKey = "demo-routing-key";
        string queueName = "DemoQueue";

        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
        channel.QueueDeclare(queueName, false, false, false, null);
        channel.QueueBind(queueName, exchangeName, routingKey, null);


        var consumer = new EventingBasicConsumer(channel);
        
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            
            var request = JsonConvert.DeserializeObject<Request>(message);
            //Normally I would also add validation for the request using DataAnnotations
            //but for demmo purposes I skipped this step and only cheking for nullability

            if (request != null)
            {
                //Using factory pattern to use right mailing service 
                IMailingService mailingService = _mailingServiceFactory.GetMailingService(request.RequestedMailingServiceName);


                var sentSuccess = mailingService.SendMail(request.Mail);
                if(sentSuccess == false)
                {
                    Console.WriteLine("Mail could not be sent.");
                }
            }


            channel.BasicAck(ea.DeliveryTag, false);
        };

        string consumerTag = channel.BasicConsume(queueName, false, consumer);

        Console.WriteLine("Waiting for mails...");
        Console.ReadLine();

        channel.BasicCancel(consumerTag); 
        channel.Close();
        connection.Close();
    }
}

public class Program
{
    public static void Main()
    {
        //For demo purposes I am injecting the service directly through constructor.
        //In real world application I'd rather use some dependency injection library to do it for me.
        var consumer = new Consumer(new MailingServiceFactory());
        consumer.StartConsuming();
    }
}