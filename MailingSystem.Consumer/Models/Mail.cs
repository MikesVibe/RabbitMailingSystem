using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingSystem.Consumer.Models
{
    public class Mail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
    }

}
