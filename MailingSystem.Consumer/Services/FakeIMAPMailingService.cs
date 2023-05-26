using MailingSystem.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingSystem.Consumer.Services
{
    public class FakeIMAPMailingService : IMailingService
    {
        public bool SendMail(Mail email)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Mail sent through {nameof(FakeIMAPMailingService)}.");
            Console.WriteLine($"To: {email.Recipient}");
            Console.WriteLine($"Subject: {email.Subject}");
            Console.WriteLine($"Body: {email.Body}");
            Console.WriteLine("-------------------------");

            return true;
        }
    }
}
