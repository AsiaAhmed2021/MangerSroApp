
namespace MangerSroApp.Tools.Maps
{
    partial class ChangePropertyViews
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
            this.txtSizeX = new System.Windows.Forms.TextBox();
            this.txtMaxRowX = new System.Windows.Forms.TextBox();
            this.txtMaxRowY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSizeY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSizeX
            // 
            this.txtSizeX.Location = new System.Drawing.Point(53, 30);
            this.txtSizeX.Name = "txtSizeX";
            this.txtSizeX.Size = new System.Drawing.Size(96, 23);
            this.txtSizeX.TabIndex = 0;
            this.txtSizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaxRowX
            // 
            this.txtMaxRowX.Location = new System.Drawing.Point(13, 81);
            this.txtMaxRowX.Name = "txtMaxRowX";
            this.txtMaxRowX.Size = new System.Drawing.Size(299, 23);
            this.txtMaxRowX.TabIndex = 2;
            this.txtMaxRowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaxRowY
            // 
            this.txtMaxRowY.Location = new System.Drawing.Point(13, 125);
            this.txtMaxRowY.Name = "txtMaxRowY";
            this.txtMaxRowY.Size = new System.Drawing.Size(299, 23);
            this.txtMaxRowY.TabIndex = 3;
            this.txtMaxRowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max Count Row Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max Count Row X";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSizeY
            // 
            this.txtSizeY.Location = new System.Drawing.Point(204, 30);
            this.txtSizeY.Name = "txtSizeY";
            this.txtSizeY.Size = new System.Drawing.Size(108, 23);
            this.txtSizeY.TabIndex = 1;
            this.txtSizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Size Icon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Height";
            // 
            // ChangePropertyViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 188);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSizeY);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaxRowY);
            this.Controls.Add(this.txtMaxRowX);
            this.Controls.Add(this.txtSizeX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangePropertyViews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Config Changer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSizeX;
        private System.Windows.Forms.TextBox txtMaxRowX;
        private System.Windows.Forms.TextBox txtMaxRowY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSizeY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}