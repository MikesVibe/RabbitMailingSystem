using MailingSystem.Consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingSystem.Consumer.Services
{
    public class FakeSMTPMailingService : IMailingService
    {
        public bool SendMail(Mail email)
        {
            Console.WriteLine($"Mail sent through {nameof(FakeSMTPMailingService)}.");
            Console.WriteLine("Mail sent: Subject={0}, Recipient={1}", email.Subject, email.Recipient);

            return true;
        }
    }
}
