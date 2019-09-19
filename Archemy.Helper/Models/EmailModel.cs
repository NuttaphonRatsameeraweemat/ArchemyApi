using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Helper.Models
{
    public class EmailModel
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
