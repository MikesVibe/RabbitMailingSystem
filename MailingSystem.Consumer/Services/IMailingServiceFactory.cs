using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingSystem.Consumer.Services
{
    public interface IMailingServiceFactory
    {
        IMailingService GetMailingService(string mailingSystemName);
    }
}
