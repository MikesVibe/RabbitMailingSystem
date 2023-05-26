using MailingSystem.Model.Model;
using MailingSystem.Producer;
using RabbitMQ.Client.Exceptions;

// Setting endless loop for sending messages via MailingSystem.Producer library
while (true)
{
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

    try
    {
        var producer = new Producer();
        producer.SendRequest(request);
    }
    catch (BrokerUnreachableException ex)
    {
        Console.WriteLine("Something went wrong while trying to connect with RabitMQ.");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}