using System.Net.Mail;
using System.Net;
using MailingSystem.Consumer.Services;

public class Program
{
    public static void Main()
    {
        //For demo purposes I am injecting the service directly through constructor.
        //In real world application I'd rather use some dependency injection library to do it for me.
        //var consumer = new Consumer(new MailingServiceFactory());
        //consumer.StartConsuming();
    }
}