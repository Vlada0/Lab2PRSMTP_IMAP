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
using SMTP_POP31.Properties;

namespace SMTP_POP31
{ 
    public partial class MainForm : Form
    {
       // ImapClient client = new ImapClient();
        string d,s;
        int choise = 1;
        static public int count_page;
        IMailFolder inbox, sent;
        MimeMessage tmp;
        List<MimeMessage> data = new List<MimeMessage>();
        
        
        List<UniqueId> uids = new List<UniqueId>();
        public MainForm()
        {
            InitializeComponent();
           //client = Connect_Function(); 
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            int portNumber = 587;
            string server = null;
            string domainGmail = "@gmail.com";
            string domainYandex = "@yandex.ru";
            string domainMail = "@mail.ru";
            DialogResult res = new DialogResult();
            bool enableSSL = true;

            try
            {
                Form3 f3 = new Form3();
                if (f3.serverTB.Text == "imap.gmail.com")
                {
                    server = "smtp.gmail.com";
                }
                if (f3.serverTB.Text == "imap.yandex.ru")
                {
                    server = "smtp.yandex.ru";
                }
                if (f3.serverTB.Text == "imap.mail.ru")
                {
                    server = "smtp.mail.ru";
                }
                if (ToTB.Text.ToString() == "")
                {
                    MessageBox.Show("Введите адрес получателя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (SubjectTB.Text.ToString() == "")

                    {

                        res = MessageBox.Show("Хотите отправить сообщение без темы?", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    }
                    if (res == DialogResult.Cancel)
                    {
                    }
                    else
                    {
                        // if(SubjectTB.Text )
                        using (MailMessage mail = new MailMessage())
                        {

                            mail.From = new MailAddress(FromTB.Text);
                            if ((ToTB.Text.EndsWith(domainGmail) && ToTB.Text!=domainGmail)||(ToTB.Text.EndsWith(domainYandex)&&ToTB.Text!=domainYandex)) { 
                                mail.To.Add(ToTB.Text);

                            mail.Subject = SubjectTB.Text;
                            mail.Body = TextRTB.Text;
                            mail.IsBodyHtml = true;
                            //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment 

                            using (SmtpClient smtp = new SmtpClient(server, portNumber))
                            {
                                    smtp.UseDefaultCredentials = false;
                                    smtp.Credentials = new NetworkCredential(f3.loginTB.Text, f3.passwordTB.Text);
                                smtp.EnableSsl = enableSSL;
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtp.Send(mail);

                                MessageBox.Show("Mail Send");

                            }
                            ToTB.Text = "";
                            SubjectTB.Text = "";
                            TextRTB.Text = ""; }
                             else
                            {
                                MessageBox.Show("Неправильный адрес получателя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }


                }
                    
                
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }

        public static OpenItem Render(MimeMessage message)
        {
            OpenItem RendItem = new OpenItem(); 
            var tmpDir = Path.Combine(Path.GetTempPath(), message.MessageId);
            var visitor = new HtmlPreviewVisitor(tmpDir); 
            Directory.CreateDirectory(tmpDir); 
            message.Accept(visitor);
            RendItem.Sethtml=visitor.HtmlBody;
            RendItem.Setattachments = visitor.Attachments; 
            return RendItem; 
        }

         public ImapClient Connect_Function()
        {
            ImapClient client = new ImapClient();
            using (client)
            {
                Form3 f3 = (Form3)Application.OpenForms["Form3"];
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(f3.serverTB.Text, 993, true);
                client.Authenticate(f3.loginTB.Text, f3.passwordTB.Text);
                return client;
            }
        }
        public void Mess_Page(object text_button)
        {
            DataClass t = new DataClass();
            t = (DataClass)text_button;
            Form3 f3 = (Form3)Application.OpenForms["Form3"];
            int text_but = Convert.ToInt16(t.number_page);
            int count_mess = 0;
            using (IImapClient client = new ImapClient())
            {

                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(f3.serverTB.Text, 993, true);
                client.Authenticate(f3.loginTB.Text, f3.passwordTB.Text);
                // The Inbox folder is always available on all IMAP servers...
                if (t.folder == 1)
                {
                    count_page = 0;
                    count_mess = 0;
                    inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    count_page = inbox.Count / 10;
                    if (count_page == 0 || inbox.Count % 10 != 0)
                        count_page = count_page + 1;
                    count_mess = inbox.Count;
                   
                }
                if(t.folder == 2)
                {
                    count_page = 0;
                    count_mess = 0;
                    sent = client.GetFolder(SpecialFolder.Sent);
                    sent.Open(FolderAccess.ReadOnly);
                    count_page = sent.Count / 10;
                    if (count_page == 0 || sent.Count % 10 != 0)
                        count_page = count_page + 1;
                    count_mess = sent.Count;
                   
                }

                if (count_mess == 0)
                {
                    MessageBox.Show("В данной папке нет сообщений", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            listViewMessages.Items.Clear();
                        });
                    }
                    else
                    {
                        listViewMessages.Items.Clear();
                    }

                    int f = 0, d = 0;
                    int j = 0;
                    if (text_but != count_page)
                    {
                        f = (count_mess - 1) - (text_but - 1) * 10;
                        d = f - 10;
                    }
                    else
                    {
                        f = (count_mess - 1) - (text_but - 1) * 10;
                        d = -1;

                    }

                    int step = 100 / (f - d);
                    try
                    {
                        for (int i = f; i > d; i--)
                        {
                            if (t.folder == 1)
                            {
                                tmp = inbox.GetMessage(i);
                            }
                            if (t.folder == 2)
                            {
                                tmp = sent.GetMessage(i);
                            }
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
                            j++;
                            if (InvokeRequired)
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    listViewMessages.Items.Add(from);
                                    this.progressBar1.Increment(step);
                                    if (progressBar1.Value < step * (f - d))
                                    {
                                        ConnectBtn.Enabled = false;
                                        OpenBtn.Enabled = false;
                                        OutGoingBTN.Enabled = false;
                                        DeleteBtn.Enabled = false;
                                        buttonBack.Enabled = false;
                                        buttonNext.Enabled = false;
                                    }
                                });
                            }
                            else
                            {
                                listViewMessages.Items.Add(from);
                                this.progressBar1.Increment(step);
                                if (progressBar1.Value < step * (f - d))
                                {
                                    ConnectBtn.Enabled = false;
                                    OpenBtn.Enabled = false;
                                    OutGoingBTN.Enabled = false;
                                    DeleteBtn.Enabled = false;
                                    buttonBack.Enabled = false;
                                    buttonNext.Enabled = false;
                                }
                            }
                        }
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                progressBar1.Value = 0;
                                ConnectBtn.Enabled = true;
                                OpenBtn.Enabled = true;
                                OutGoingBTN.Enabled = true;
                                DeleteBtn.Enabled = true;
                                if (textBoxPage.Text != "1")
                                    buttonBack.Enabled = true;
                                if (Convert.ToUInt16(textBoxPage.Text) < count_page)
                                    buttonNext.Enabled = true;
                            });
                        }
                        else
                        {
                            progressBar1.Value = 0;
                            ConnectBtn.Enabled = true;
                            OpenBtn.Enabled = true;
                            OutGoingBTN.Enabled = true;
                            DeleteBtn.Enabled = true;
                            if (textBoxPage.Text != "1")
                                buttonBack.Enabled = true;
                            if (Convert.ToUInt16(textBoxPage.Text) < count_page)
                                buttonNext.Enabled = true;
                        }

                        
                    }

                    catch (Exception EX)
                    {
                        Console.WriteLine(EX.Message);
                    }
                }
                client.Disconnect(true);
            } 
        }
        public void Connect_Func(string Text_Page, int n)
        {
            DataClass tmp = new DataClass();
            tmp.Page = Text_Page;
            tmp.Folder = n;
            data.Clear();
            buttonBack.Enabled = false;
            //Form3 f3 = (Form3)Application.OpenForms["Form3"];

                Thread thread = new Thread(new ParameterizedThreadStart(Mess_Page));
                thread.Start(tmp);
            
        }
        public void ConnectBtn_Click(object sender, EventArgs t)
        {
            choise = 1;
            Connect_Func(textBoxPage.Text, choise);
           
        }
         
		private void OpenBtn_Click(object sender, EventArgs t)
		{
            if (listViewMessages.FullRowSelect == true && listViewMessages.SelectedItems.Count!=0)
            {
                OpenItem RendItem = new OpenItem();
                Form3 f3 = (Form3)Application.OpenForms["Form3"];
                
                Form2 frm = (Form2)Application.OpenForms["Form2"];
                if (frm == null) // Если форма не существует, то создаём
                {
                    frm = new Form2(); // Создание нового экземпляра формы 
                }
                else
                    frm.Activate(); // Активируем форму на передний план (из трея или заднего плана)
                frm.Show(); // Отображаем форму 
                frm.textBoxFrom.Text = TrimFunction(listViewMessages.SelectedItems[0].SubItems[0].ToString());
                frm.textBoxTo.Text = f3.loginTB.Text.ToString();
                frm.textBoxSubject.Text = TrimFunction(listViewMessages.SelectedItems[0].SubItems[1].ToString());
                frm.textBoxDate.Text = TrimFunction(listViewMessages.SelectedItems[0].SubItems[2].ToString());
                int index = listViewMessages.SelectedIndices[0];
                RendItem = Render(data[index]);
                frm.webBrowser1.DocumentText = RendItem.Gethtml;
                if (RendItem.Getattachments.Count() != 0)
                {
                    var result = MessageBox.Show("Сообщение имеет вложения. Скачать вложения?", "Идет скачивание", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        foreach (var attachment in RendItem.Getattachments)
                        {
                            var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                            using (var stream = File.Create(fileName))
                            {
                                if (attachment is MessagePart)
                                {
                                    var rfc822 = (MessagePart)attachment; 
                                    rfc822.Message.WriteTo(stream);
                                } 
                                    var part = (MimePart)attachment; 
                                    part.Content.DecodeTo(stream); 
                            }
                        }
                    }      
                } 
            }
            else
                 MessageBox.Show("Сообщение не выбрано!", "Сообщения", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
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
            int count_message = 0;
            int check = 0;
            ConnectBtn.Enabled = false;
            OpenBtn.Enabled = false;
            OutGoingBTN.Enabled = false;
            DeleteBtn.Enabled = false;
            buttonBack.Enabled = false;
            buttonNext.Enabled = false;
            for (int i = 0; i < listViewMessages.Items.Count; i++)
            {
                if (listViewMessages.Items[i].Checked == true)
                {
                    check++;
                }
            }
            if (check == 0)
            {
                MessageBox.Show("Выберите сообщение для удаления", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConnectBtn.Enabled = true;
                OpenBtn.Enabled = true;
                OutGoingBTN.Enabled = true;
                DeleteBtn.Enabled = true;
                if (textBoxPage.Text != "1")
                    buttonBack.Enabled = true;
                if (Convert.ToUInt16(textBoxPage.Text) < count_page)
                    buttonNext.Enabled = true;
            }
            else
            {
                
                using (ImapClient client = new ImapClient())
                {
                    Form3 f3 = (Form3)Application.OpenForms["Form3"];
                    // For demo-purposes, accept all SSL certificates
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(f3.serverTB.Text, 993, true);
                    client.Authenticate(f3.loginTB.Text, f3.passwordTB.Text);
                    if (choise == 1)
                    {
                        uids.Clear();
                        //count_page = 0;
                        count_message = 0;
                        inbox = client.Inbox;
                        inbox.Open(FolderAccess.ReadWrite);
                        count_message = inbox.Count;
                        foreach (var summary in inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure))
                        {
                            uids.Add(summary.UniqueId);
                        }
                    }

                    if (choise == 2)
                    {
                        uids.Clear();
                        //count_page = 0;
                        count_message = 0;
                        sent = client.GetFolder(SpecialFolder.Sent);
                        sent.Open(FolderAccess.ReadWrite);
                        count_message = sent.Count;
                        foreach (var summary in sent.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure))
                        {
                            uids.Add(summary.UniqueId);
                        }
                    }


                    var trash = client.GetFolder(SpecialFolder.Trash);

                    int f = 0, d = 0;
                    int j = 0;
                    int text_but = Convert.ToInt16(textBoxPage.Text);
                    if (text_but != count_page)
                    {
                        f = (count_message - 1) - (text_but - 1) * 10;
                        d = f - 10;
                    }
                    else
                    {
                        f = (count_message - 1) - (text_but - 1) * 10;
                        d = -1;
                    }
                    for (int i = f; i > d; i--)
                    {
                        if (listViewMessages.Items[j].Checked == true)
                        {

                            if (choise == 1)
                            {
                                inbox.Open(FolderAccess.ReadWrite);
                                var moved = inbox.MoveTo(uids[i], trash);

                                if (moved.HasValue)
                                {
                                    trash.Open(FolderAccess.ReadWrite);
                                    trash.AddFlags(moved.Value, MessageFlags.Deleted, true);
                                    trash.Expunge(new[] { moved.Value });
                                }
                            }
                            if (choise == 2)
                            {
                                sent.Open(FolderAccess.ReadWrite);
                                var moved = sent.MoveTo(uids[i], trash);

                                if (moved.HasValue)
                                {
                                    trash.Open(FolderAccess.ReadWrite);
                                    trash.AddFlags(moved.Value, MessageFlags.Deleted, true);
                                    trash.Expunge(new[] { moved.Value });
                                }
                            }

                            listViewMessages.Items[j].Remove();
                            j--;
                        }

                        j++;
                    }

                    client.Disconnect(true);

                    uids.Clear();
                    Connect_Func("1", choise);
                   
                }
            } 
        }
     
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            data.Clear();
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
            
                Connect_Func(textBoxPage.Text, choise);
            
        }

        private int Parse(string text)
        {
            throw new NotImplementedException();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        { 
            data.Clear();
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
            Connect_Func(textBoxPage.Text, choise);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listViewMessages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxPage.Text = "1";
            choise = 2;
            Connect_Func(textBoxPage.Text, choise);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                return;

            if (MessageBox.Show("Уже уходите?", "Выход", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
                Application.Exit();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Form3 f3 = (Form3)Application.OpenForms["Form3"];
            //f3.Close();
            this.Hide();
            if (f3 == null) // Если форма не существует, то создаём
            {
                f3 = new Form3(); // Создание нового экземпляра формы 
            }
            else
                f3.Activate(); // Активируем форму на передний план (из трея или заднего плана)
            f3.Show(); // Отображаем форму  
            
        }

        private void ToTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
