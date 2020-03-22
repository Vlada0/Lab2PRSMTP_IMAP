using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTP_POP31
{
	static class Program
	{
       
       // public static MainForm f1;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
		static void Main()
		{

            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form3());
		}

     

    }
    public class DataClass
    {
        public string number_page;
        public int folder;
        public string Page { get { return number_page; } set { number_page = value; } }
        public int Folder { get { return folder; } set { folder = value; } }
        
    }
  
   
}
