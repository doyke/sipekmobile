namespace SipekMobile
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
          this.mainMenu1 = new System.Windows.Forms.MainMenu();
          this.menuItemExit = new System.Windows.Forms.MenuItem();
          this.textBoxUserName = new System.Windows.Forms.TextBox();
          this.UserName = new System.Windows.Forms.Label();
          this.textBoxHostName = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.textBoxPW = new System.Windows.Forms.TextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.statusBar1 = new System.Windows.Forms.StatusBar();
          this.label3 = new System.Windows.Forms.Label();
          this.comboBoxTransportMode = new System.Windows.Forms.ComboBox();
          this.button1 = new System.Windows.Forms.Button();
          this.button2 = new System.Windows.Forms.Button();
          this.SuspendLayout();
          // 
          // mainMenu1
          // 
          this.mainMenu1.MenuItems.Add(this.menuItemExit);
          // 
          // menuItemExit
          // 
          this.menuItemExit.Text = "Exit";
          this.menuItemExit.Click += new System.EventHandler(this.exitButton_Click);
          // 
          // textBoxUserName
          // 
          this.textBoxUserName.Location = new System.Drawing.Point(82, 38);
          this.textBoxUserName.Name = "textBoxUserName";
          this.textBoxUserName.Size = new System.Drawing.Size(105, 21);
          this.textBoxUserName.TabIndex = 1;
          // 
          // UserName
          // 
          this.UserName.Location = new System.Drawing.Point(3, 39);
          this.UserName.Name = "UserName";
          this.UserName.Size = new System.Drawing.Size(61, 20);
          this.UserName.Text = "Username";
          // 
          // textBoxHostName
          // 
          this.textBoxHostName.Location = new System.Drawing.Point(82, 11);
          this.textBoxHostName.Name = "textBoxHostName";
          this.textBoxHostName.Size = new System.Drawing.Size(150, 21);
          this.textBoxHostName.TabIndex = 0;
          // 
          // label1
          // 
          this.label1.Location = new System.Drawing.Point(3, 12);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(73, 20);
          this.label1.Text = "SIP Server";
          // 
          // textBoxPW
          // 
          this.textBoxPW.Location = new System.Drawing.Point(82, 65);
          this.textBoxPW.Name = "textBoxPW";
          this.textBoxPW.Size = new System.Drawing.Size(105, 21);
          this.textBoxPW.TabIndex = 2;
          // 
          // label2
          // 
          this.label2.Location = new System.Drawing.Point(3, 66);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(73, 20);
          this.label2.Text = "Password";
          // 
          // statusBar1
          // 
          this.statusBar1.Location = new System.Drawing.Point(0, 241);
          this.statusBar1.Name = "statusBar1";
          this.statusBar1.Size = new System.Drawing.Size(240, 22);
          // 
          // label3
          // 
          this.label3.Location = new System.Drawing.Point(4, 95);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(73, 20);
          this.label3.Text = "Transport";
          // 
          // comboBoxTransportMode
          // 
          this.comboBoxTransportMode.Items.Add("UDP");
          this.comboBoxTransportMode.Items.Add("TCP");
          this.comboBoxTransportMode.Location = new System.Drawing.Point(82, 93);
          this.comboBoxTransportMode.Name = "comboBoxTransportMode";
          this.comboBoxTransportMode.Size = new System.Drawing.Size(57, 22);
          this.comboBoxTransportMode.TabIndex = 17;
          // 
          // button1
          // 
          this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.button1.Location = new System.Drawing.Point(160, 155);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(72, 20);
          this.button1.TabIndex = 23;
          this.button1.Text = "OK";
          this.button1.Click += new System.EventHandler(this.buttonApply_Click);
          // 
          // button2
          // 
          this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.button2.Location = new System.Drawing.Point(3, 155);
          this.button2.Name = "button2";
          this.button2.Size = new System.Drawing.Size(72, 20);
          this.button2.TabIndex = 24;
          this.button2.Text = "Cancel";
          // 
          // SettingsForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
          this.AutoScroll = true;
          this.ClientSize = new System.Drawing.Size(240, 263);
          this.Controls.Add(this.button2);
          this.Controls.Add(this.button1);
          this.Controls.Add(this.comboBoxTransportMode);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.statusBar1);
          this.Controls.Add(this.textBoxPW);
          this.Controls.Add(this.textBoxHostName);
          this.Controls.Add(this.textBoxUserName);
          this.Controls.Add(this.UserName);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.label2);
          this.Menu = this.mainMenu1;
          this.Name = "SettingsForm";
          this.Text = "Sipek Mobile";
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox textBoxHostName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPW;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.MenuItem menuItemExit;
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox comboBoxTransportMode;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
    }
}

