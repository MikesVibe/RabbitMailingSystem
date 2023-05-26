using MailingSystem.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingSystem.Consumer.Services
{
    public interface IMailingService
    {
        bool SendMail(Mail email);
    }
}
