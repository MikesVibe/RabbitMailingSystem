using MailingSystem.Producer;
using MailingSystem.Producer.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;

public class Program
{
    public static void Main()
    {
        var producer = new Producer();
        var mail = new Mail
        {
            Subject = "RabitMQ Test",
            Body = "Welcome to the hotel california",
            Recipient = "programisci@militaria.pl"
        };

        var request = new Request
        { 
            RequestedMailingServiceName = "FakeSMTPMailingService",
            Mail = mail
        };

        producer.SendRequest(request);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}