
namespace TestBot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.CharSelDropDown = new System.Windows.Forms.ComboBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPasswrod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCharname = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(287, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CharSelDropDown
            // 
            this.CharSelDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CharSelDropDown.AutoCompleteCustomSource.AddRange(new string[] {
            "Welvome Yo",
            "asd"});
            this.CharSelDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CharSelDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CharSelDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CharSelDropDown.FormattingEnabled = true;
            this.CharSelDropDown.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "8"});
            this.CharSelDropDown.Location = new System.Drawing.Point(12, 12);
            this.CharSelDropDown.Name = "CharSelDropDown";
            this.CharSelDropDown.Size = new System.Drawing.Size(269, 21);
            this.CharSelDropDown.TabIndex = 4;
            this.CharSelDropDown.DropDown += new System.EventHandler(this.CharSelDropDown_DropDown);
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserID.BackColor = System.Drawing.Color.Black;
            this.txtUserID.ForeColor = System.Drawing.Color.White;
            this.txtUserID.Location = new System.Drawing.Point(196, 57);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(159, 20);
            this.txtUserID.TabIndex = 7;
            // 
            // txtPasswrod
            // 
            this.txtPasswrod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswrod.BackColor = System.Drawing.Color.Black;
            this.txtPasswrod.ForeColor = System.Drawing.Color.White;
            this.txtPasswrod.Location = new System.Drawing.Point(196, 96);
            this.txtPasswrod.Name = "txtPasswrod";
            this.txtPasswrod.Size = new System.Drawing.Size(159, 20);
            this.txtPasswrod.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "UserID";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Passwrod";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(196, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 20);
            this.button3.TabIndex = 12;
            this.button3.Text = "Add List";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "CharName";
            // 
            // txtCharname
            // 
            this.txtCharname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCharname.BackColor = System.Drawing.Color.Black;
            this.txtCharname.ForeColor = System.Drawing.Color.White;
            this.txtCharname.Location = new System.Drawing.Point(196, 135);
            this.txtCharname.Name = "txtCharname";
            this.txtCharname.Size = new System.Drawing.Size(159, 20);
            this.txtCharname.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(13, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(172, 136);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(362, 190);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCharname);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPasswrod);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.CharSelDropDown);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CharSelDropDown;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPasswrod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCharname;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

