namespace SMTP_POP31
{
	partial class MainForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OutGoingBTN = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.columnFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SendBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TextRTB = new System.Windows.Forms.RichTextBox();
            this.SubjectTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ToTB = new System.Windows.Forms.TextBox();
            this.FromTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1033, 671);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.OutGoingBTN);
            this.tabPage2.Controls.Add(this.Exit);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.textBoxPage);
            this.tabPage2.Controls.Add(this.buttonNext);
            this.tabPage2.Controls.Add(this.buttonBack);
            this.tabPage2.Controls.Add(this.listViewMessages);
            this.tabPage2.Controls.Add(this.DeleteBtn);
            this.tabPage2.Controls.Add(this.OpenBtn);
            this.tabPage2.Controls.Add(this.ConnectBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1025, 642);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "IMAP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // OutGoingBTN
            // 
            this.OutGoingBTN.Location = new System.Drawing.Point(10, 51);
            this.OutGoingBTN.Name = "OutGoingBTN";
            this.OutGoingBTN.Size = new System.Drawing.Size(186, 38);
            this.OutGoingBTN.TabIndex = 22;
            this.OutGoingBTN.Text = "Outgoing";
            this.OutGoingBTN.UseVisualStyleBackColor = true;
            this.OutGoingBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(4, 569);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(186, 35);
            this.Exit.TabIndex = 21;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(203, 569);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(797, 30);
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(289, 14);
            this.textBoxPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(40, 22);
            this.textBoxPage.TabIndex = 19;
            // 
            // buttonNext
            // 
            this.buttonNext.Enabled = false;
            this.buttonNext.Location = new System.Drawing.Point(335, 6);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(80, 39);
            this.buttonNext.TabIndex = 18;
            this.buttonNext.Text = ">>";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Enabled = false;
            this.buttonBack.Location = new System.Drawing.Point(203, 6);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(80, 39);
            this.buttonBack.TabIndex = 17;
            this.buttonBack.Text = "<<";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // listViewMessages
            // 
            this.listViewMessages.CheckBoxes = true;
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFrom,
            this.columnSubject,
            this.columnData});
            this.listViewMessages.FullRowSelect = true;
            this.listViewMessages.Location = new System.Drawing.Point(203, 51);
            this.listViewMessages.Margin = new System.Windows.Forms.Padding(4);
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.Size = new System.Drawing.Size(799, 470);
            this.listViewMessages.TabIndex = 16;
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            this.listViewMessages.SelectedIndexChanged += new System.EventHandler(this.listViewMessages_SelectedIndexChanged);
            // 
            // columnFrom
            // 
            this.columnFrom.Text = "From";
            this.columnFrom.Width = 78;
            // 
            // columnSubject
            // 
            this.columnSubject.Text = "Subject";
            this.columnSubject.Width = 82;
            // 
            // columnData
            // 
            this.columnData.Text = "Data";
            this.columnData.Width = 76;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(10, 141);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(187, 37);
            this.DeleteBtn.TabIndex = 14;
            this.DeleteBtn.Text = "Delete Message";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Enabled = false;
            this.OpenBtn.Location = new System.Drawing.Point(9, 96);
            this.OpenBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(187, 37);
            this.OpenBtn.TabIndex = 13;
            this.OpenBtn.Text = "Open Message";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(9, 6);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(187, 37);
            this.ConnectBtn.TabIndex = 12;
            this.ConnectBtn.Text = "Inbox";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SendBtn);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.TextRTB);
            this.tabPage1.Controls.Add(this.SubjectTB);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.ToTB);
            this.tabPage1.Controls.Add(this.FromTB);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1025, 642);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Send Message";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SendBtn
            // 
            this.SendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendBtn.Location = new System.Drawing.Point(731, 572);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(275, 42);
            this.SendBtn.TabIndex = 10;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 206);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Text:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // TextRTB
            // 
            this.TextRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextRTB.Location = new System.Drawing.Point(11, 230);
            this.TextRTB.Margin = new System.Windows.Forms.Padding(4);
            this.TextRTB.Name = "TextRTB";
            this.TextRTB.Size = new System.Drawing.Size(995, 334);
            this.TextRTB.TabIndex = 8;
            this.TextRTB.Text = "";
            // 
            // SubjectTB
            // 
            this.SubjectTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubjectTB.Location = new System.Drawing.Point(8, 162);
            this.SubjectTB.Margin = new System.Windows.Forms.Padding(4);
            this.SubjectTB.Name = "SubjectTB";
            this.SubjectTB.Size = new System.Drawing.Size(995, 22);
            this.SubjectTB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(8, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Subject:";
            // 
            // ToTB
            // 
            this.ToTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToTB.Location = new System.Drawing.Point(515, 86);
            this.ToTB.Margin = new System.Windows.Forms.Padding(4);
            this.ToTB.Name = "ToTB";
            this.ToTB.Size = new System.Drawing.Size(483, 22);
            this.ToTB.TabIndex = 5;
            this.ToTB.TextChanged += new System.EventHandler(this.ToTB_TextChanged);
            // 
            // FromTB
            // 
            this.FromTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FromTB.Location = new System.Drawing.Point(12, 86);
            this.FromTB.Margin = new System.Windows.Forms.Padding(4);
            this.FromTB.Name = "FromTB";
            this.FromTB.Size = new System.Drawing.Size(487, 22);
            this.FromTB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(511, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "To:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "From:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 674);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Mail Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox SubjectTB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox ToTB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox TextRTB;
		private System.Windows.Forms.Button SendBtn;
		private System.Windows.Forms.Button DeleteBtn;
		private System.Windows.Forms.Button OpenBtn;
		private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ColumnHeader columnFrom;
        private System.Windows.Forms.ColumnHeader columnSubject;
        private System.Windows.Forms.ColumnHeader columnMessage;
        private System.Windows.Forms.ColumnHeader columnData;
        private System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.Button buttonBack;
        public System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button OutGoingBTN;
        public System.Windows.Forms.TextBox FromTB;
    }
}

