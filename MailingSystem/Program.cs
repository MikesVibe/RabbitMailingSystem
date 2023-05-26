using MailingSystem.Model.Model;
using MailingSystem.Producer;
using RabbitMQ.Client.Exceptions;

// Setting endless loop for sending messages via MailingSystem.Producer library
for (int idx=0; idx > -1; idx++)
{
    var mail = new Mail
    {
        Recipient = "programisci@militaria.pl",
        Subject = $"RabitMQ Test - [{idx}]",
        Body = "Welcome to the hotel california"
    };

    var request = new Request
    {
        //Switching services when idx can be divded by 2
        RequestedMailingServiceName = (idx%2 == 0) ? "FakeSMTPMailingService" : "FakeIMAPMailingService",
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
    Thread.Sleep(3000);
}