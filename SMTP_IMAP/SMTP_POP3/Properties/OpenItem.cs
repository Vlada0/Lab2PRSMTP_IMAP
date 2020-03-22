using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace SMTP_POP31.Properties
{
    public class OpenItem
    {
        string Html;
        List<MimeEntity> Attachments = new List<MimeEntity>();

        public List<MimeEntity> Setattachments { set { Attachments = value; } } 
        public string Sethtml { set { Html = value; } }

        public List<MimeEntity> Getattachments { get { return Attachments; } } 
        public string Gethtml { get { return Html; } } 
    }
}
