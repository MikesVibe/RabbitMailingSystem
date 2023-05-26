using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MailingSystem.Consumer.Services
{
    public class MailingServiceFactory : IMailingServiceFactory
    {
        public IMailingService GetMailingService(string mailingSystemName)
        {
            // Use reflection to find the type based on the mailing system name
            Type mailingSystemType = Assembly.GetExecutingAssembly().GetType("MailingSystem.Consumer.Services." + mailingSystemName);

            if (mailingSystemType == null || !typeof(IMailingService).IsAssignableFrom(mailingSystemType))
            {
                return new NullMailingService();
            }

            // Create an instance of the mailing system using reflection
            IMailingService mailingSystem = (IMailingService)Activator.CreateInstance(mailingSystemType);

            return mailingSystem;
        }
    }
}
