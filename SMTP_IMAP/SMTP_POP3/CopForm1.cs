using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using MailKit;
using MailKit.Net.Imap;
using System.Windows.Forms;
using System.Linq;
using MimeKit;
using System.Collections.Generic;
using System.Threading;

namespace SMTP_POP3
{

    public partial class MainForm : Form
    {
        private NetworkStream _tcpStream;
        private StreamReader _streamReader;
        string d, body1, s;
        static public int count_page;
        //static public int pages;
        IMailFolder inbox;
        MimeMessage tmp1;
        List<MimeMessage> data = new List<MimeMessage>();
        public MainForm()
        {
            InitializeComponent();

        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            int portNumber = 587;
            string password = "utmfcimti176";
            bool enableSSL = true;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(FromTB.Text);
                    mail.To.Add(ToTB.Text);
                    mail.Subject = SubjectTB.Text;
                    mail.Body = TextRTB.Text;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(ServerTB.Text, portNumber))
                    {

                        smtp.Credentials = new NetworkCredential(FromTB.Text, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                        MessageBox.Show("Mail Send");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static string Render(MimeMessage message)
        {
            List<MimeEntity> attachments = new List<MimeEntity>();
            var tmpDir = Path.Combine(Path.GetTempPath(), message.MessageId);
            var visitor = new HtmlPreviewVisitor(tmpDir);

            Directory.CreateDirectory(tmpDir);

            message.Accept(visitor);
            string html = visitor.HtmlBody;
            attachments = visitor.Attachments;
            return html;


            //DisplayHtml(visitor.HtmlBody);
            //DisplayAttachments(visitor.Attachments);
        }
        public void Mess_Page(object text_button)
        {
            

            using (ImapClient client = new ImapClient())
            {

                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(ServerPOPTB.Text, 993, true);

                client.Authenticate(UserTB.Text, PasswordTB.Text);

                // The Inbox folder is always available on all IMAP servers...
                inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                
                //.Text = inbox.Count.ToString() + "\n" + inbox.Recent.ToString();

                //  Console.WriteLine("Total messages: {0}", inbox.Count);
                // Console.WriteLine("Recent messages: {0}", inbox.Recent);
                listViewMessages.Items.Clear();
                count_page = inbox.Count / 10;
                if (count_page % 10 != 0)
                    count_page = count_page + 1;


                int j = 0;
                int f=0, d=0;
                int text_but =0;
                if (text_button.ToString() != "Connect")
                {
                    text_but = Convert.ToInt16(text_button);
                }
                if (text_button.ToString() == "Connect")
                {
                    j = 0;
                    if (count_page == 0)
                    {
                        count_page = count_page + 1;
                        f = inbox.Count-1;
                        d = 0;
                    }
                    else
                    {
                        f = inbox.Count-1;
                        d = f-10;
                    }
                }
                else
                {
                    j = (text_but - 1) * 10;

                    if (text_but != 1)
                    {
                        f = (text_but) * 10;
                        d = f -10;
                    }
                    else
                    {
                        f = (count_page - 1) * 10;
                        d = 0;
                        
                    }
                }
                
                int step = 100 / (f - d);
                for (int i = f; i > d; i--)
                {
                    
                    var tmp = inbox.GetMessage(i);
                    data.Add(tmp);
                    tmp = null;
                    var from = new ListViewItem();
                    var subject = new ListViewItem.ListViewSubItem();
                    var date = new ListViewItem.ListViewSubItem();
                    from.Text = data[j].From.ToString();
                    subject.Text = data[j].Subject.ToString();
                    string body_mess = data[j].Body.ToString();
                    date.Text = data[j].Date.ToString();
                    from.SubItems.Add(subject);
                    from.SubItems.Add(date);
                    listViewMessages.Items.Add(from);
                    this.progressBar1.Increment(step);
                    if(progressBar1.Value < step * (f - d))
                    {
                        ConnectBtn.Enabled = false;
                        OpenBtn.Enabled = false;
                        DeleteBtn.Enabled = false;
                        buttonBack.Enabled = false;
                        buttonNext.Enabled = false;
                    }
                    j++;
                }
                
                client.Disconnect(true);
                progressBar1.Value = 0;
                ConnectBtn.Enabled = true;
                OpenBtn.Enabled = true;
                DeleteBtn.Enabled = true;
                if(textBoxPage.Text != "1")
                buttonBack.Enabled = true;
                if(Convert.ToUInt16(textBoxPage.Text) < count_page)
                buttonNext.Enabled = true;
            }
            //return count_page;
        }
    
    public void ConnectBtn_Click(object sender, EventArgs t)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(Mess_Page));
            thread.Start(ConnectBtn.Text.ToString());
            //int pages = Mess_Page(ConnectBtn.Text.ToString());
            //thread.Interrupt();
            
            textBoxPage.Text = "1";
            buttonBack.Enabled = false;
        }


		private void OpenBtn_Click(object sender, EventArgs t)
		{
            if (listViewMessages.FullRowSelect == true)
            {
                int index = (Convert.ToInt16(textBoxPage.Text))*10-10;
                Form2 frm = new Form2();
                frm.Show();
                //var mess = TrimFunction(listViewMessages.SelectedItems[0].SubItems[2].ToString());
                frm.textBoxFrom.Text = TrimFunction(listViewMessages.SelectedItems[0].SubItems[0].ToString());
                frm.textBoxTo.Text = UserTB.Text.ToString();
                frm.textBoxSubject.Text = TrimFunction(listViewMessages.SelectedItems[0].SubItems[1].ToString());
                frm.textBoxDate.Text = TrimFunction(listViewMessages.SelectedItems[0].SubItems[2].ToString());
                index += listViewMessages.SelectedIndices[0];
                string se = Render(data[index]);
                frm.webBrowser1.DocumentText = Render(data[index]);
                
            }
        }
        string TrimFunction(string str)
        {
            string str_1 = str.Trim(new char[] { '}', '{' });
            string[] words = str_1.Split(new char[] { '{' });
            string str2 = words[1];
            return str2;
        }
		private void DeleteBtn_Click(object sender, EventArgs t)
		{
			
		}

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = Int16.Parse(textBoxPage.Text)+1;
            if (k != 1)
            {
                buttonBack.Enabled = true;
            }
            else
            {
                buttonBack.Enabled = false;
            }
            if(k == count_page)
            {
                buttonNext.Enabled = false;
            }
            else
            {
                buttonNext.Enabled = true;
            }
            textBoxPage.Text = Convert.ToString(k);
            Thread thread1 = new Thread(new ParameterizedThreadStart(Mess_Page));
            thread1.Start(textBoxPage.Text);
           // Mess_Page(textBoxPage.Text);
        }

        private int Parse(string text)
        {
            throw new NotImplementedException();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            int k = Int16.Parse(textBoxPage.Text) - 1;
            if (k == 1)
            {
                buttonBack.Enabled = false;
            }
            else
            {
                buttonBack.Enabled = true;
            }
            if(k < count_page)
            {
                buttonNext.Enabled = true;
            }
            textBoxPage.Text = Convert.ToString(k);
            Thread thread2 = new Thread(new ParameterizedThreadStart(Mess_Page));
            thread2.Start(textBoxPage.Text);
            //Mess_Page(textBoxPage.Text);

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ToTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
