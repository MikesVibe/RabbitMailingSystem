using MailingSystem.Producer.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingSystem.Producer
{
    public class Producer
    {
        public void SendRequest(Request mail)
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "Rabbit Producer";

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            string exchangeName = "DemoExchange";
            string routingKey = "demo-routing-key";
            string queueName = "DemoQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);


            var message = JsonConvert.SerializeObject(mail);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchangeName, routingKey, null, body);
            Console.WriteLine("Mail sent: {0}", message);

            channel.Close();
            connection.Close();
        }
    }
}
