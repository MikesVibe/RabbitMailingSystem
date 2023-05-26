using MailingSystem.Consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingSystem.Consumer.Services
{
    public class NullMailingService : IMailingService
    {
        public bool SendMail(Mail email)
        {
            return false;
        }
    }
}
