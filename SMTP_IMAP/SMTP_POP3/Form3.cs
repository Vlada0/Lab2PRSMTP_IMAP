using MailKit.Net.Imap;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTP_POP31
{
    public partial class Form3 : Form
    {
        public static ImapClient client = new ImapClient();
       // List<MimeMessage> data = new List<MimeMessage>();
        public Form3()
        {
            InitializeComponent();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs t)
        {

            string hostGmail = "imap.gmail.com";
            string hostYandex = "imap.yandex.ru";
            string hostMail = "imap.mail.ru";
            if (serverTB.Text == hostGmail || serverTB.Text == hostYandex|| serverTB.Text == hostMail)
            {


                using (ImapClient client2 = new ImapClient())
                {
                    // For demo-purposes, accept all SSL certificates
                    client2.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client2.Connect(serverTB.Text, 993, true);
                    try
                    {
                        client2.Authenticate(loginTB.Text, passwordTB.Text);



                        client2.Disconnect(true);


                        this.Hide();
                        MainForm f1 = (MainForm)Application.OpenForms["MainForm"];
                        if (f1 == null) // Если форма не существует, то создаём
                        {
                            f1 = new MainForm(); // Создание нового экземпляра формы
                        }
                        else
                            f1.Activate(); // Активируем форму на передний план (из трея или заднего плана)
                        f1.Show();
                        f1.FromTB.Enabled = true;
                        f1.FromTB.Text = loginTB.Text;
                        f1.FromTB.Enabled = false;
                        //data.Clear();
                        f1.textBoxPage.Text = "1";
                        f1.Connect_Func(f1.textBoxPage.Text, 1);
                    }
                    catch
                    {
                        MessageBox.Show("Неправильный логин/пароль", "Аутентификация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильный адрес хоста", "Аутентификация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                return;

            if (MessageBox.Show("Уже уходите?", "Выход", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
                Application.Exit();
        }
    }
}
