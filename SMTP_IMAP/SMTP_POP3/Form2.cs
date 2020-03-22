using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTP_POP31
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //MainForm form1 = new MainForm();
            //form1.Show();
           this.Hide();

        }

        private void textBoxDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
