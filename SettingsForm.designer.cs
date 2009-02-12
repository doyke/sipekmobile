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
          this.menuItem1 = new System.Windows.Forms.MenuItem();
          this.textBoxUserName = new System.Windows.Forms.TextBox();
          this.UserName = new System.Windows.Forms.Label();
          this.textBoxHostName = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.textBoxPW = new System.Windows.Forms.TextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.comboBoxTransportMode = new System.Windows.Forms.ComboBox();
          this.checkBoxPresence = new System.Windows.Forms.CheckBox();
          this.SuspendLayout();
          // 
          // mainMenu1
          // 
          this.mainMenu1.MenuItems.Add(this.menuItemExit);
          this.mainMenu1.MenuItems.Add(this.menuItem1);
          // 
          // menuItemExit
          // 
          this.menuItemExit.Text = "Cancel";
          this.menuItemExit.Click += new System.EventHandler(this.exitButton_Click);
          // 
          // menuItem1
          // 
          this.menuItem1.Text = "OK";
          this.menuItem1.Click += new System.EventHandler(this.buttonApply_Click);
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
          // checkBoxPresence
          // 
          this.checkBoxPresence.Location = new System.Drawing.Point(4, 164);
          this.checkBoxPresence.Name = "checkBoxPresence";
          this.checkBoxPresence.Size = new System.Drawing.Size(150, 20);
          this.checkBoxPresence.TabIndex = 22;
          this.checkBoxPresence.Text = "Enable Presence";
          // 
          // SettingsForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
          this.AutoScroll = true;
          this.ClientSize = new System.Drawing.Size(240, 268);
          this.Controls.Add(this.checkBoxPresence);
          this.Controls.Add(this.comboBoxTransportMode);
          this.Controls.Add(this.label3);
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
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox comboBoxTransportMode;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.CheckBox checkBoxPresence;
    }
}

