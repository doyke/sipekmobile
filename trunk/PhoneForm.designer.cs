namespace SipekMobile
{
    partial class PhoneForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoneForm));
          this.mainMenu = new System.Windows.Forms.MainMenu();
          this.menuItem1 = new System.Windows.Forms.MenuItem();
          this.contextMenuBackgroundCalls = new System.Windows.Forms.ContextMenu();
          this.menuItemActivate = new System.Windows.Forms.MenuItem();
          this.contextMenuContacts = new System.Windows.Forms.ContextMenu();
          this.menuItemConactsCall = new System.Windows.Forms.MenuItem();
          this.menuItemMessage = new System.Windows.Forms.MenuItem();
          this.tabControl = new System.Windows.Forms.TabControl();
          this.tabPageContacts = new System.Windows.Forms.TabPage();
          this.textBoxNumber = new System.Windows.Forms.TextBox();
          this.listViewContacts = new System.Windows.Forms.ListView();
          this.columnHeaderStatus = new System.Windows.Forms.ColumnHeader();
          this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
          this.columnHeaderNumber = new System.Windows.Forms.ColumnHeader();
          this.tabPagePhone = new System.Windows.Forms.TabPage();
          this.listViewBackground = new System.Windows.Forms.ListView();
          this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
          this.checkBoxSpeakerPhone = new System.Windows.Forms.CheckBox();
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          this.labelDuration = new System.Windows.Forms.Label();
          this.labelCallStatus = new System.Windows.Forms.Label();
          this.labelName = new System.Windows.Forms.Label();
          this.statusBar1 = new System.Windows.Forms.StatusBar();
          this.tabControl.SuspendLayout();
          this.tabPageContacts.SuspendLayout();
          this.tabPagePhone.SuspendLayout();
          this.SuspendLayout();
          // 
          // mainMenu
          // 
          this.mainMenu.MenuItems.Add(this.menuItem1);
          // 
          // menuItem1
          // 
          this.menuItem1.Text = "";
          // 
          // contextMenuBackgroundCalls
          // 
          this.contextMenuBackgroundCalls.MenuItems.Add(this.menuItemActivate);
          // 
          // menuItemActivate
          // 
          this.menuItemActivate.Text = "Activate";
          this.menuItemActivate.Click += new System.EventHandler(this.menuItemActivate_Click);
          // 
          // contextMenuContacts
          // 
          this.contextMenuContacts.MenuItems.Add(this.menuItemConactsCall);
          this.contextMenuContacts.MenuItems.Add(this.menuItemMessage);
          // 
          // menuItemConactsCall
          // 
          this.menuItemConactsCall.Text = "Call";
          this.menuItemConactsCall.Click += new System.EventHandler(this.menuItemContactCall_Click);
          // 
          // menuItemMessage
          // 
          this.menuItemMessage.Text = "Send Message";
          this.menuItemMessage.Click += new System.EventHandler(this.menuItemMessage_Click);
          // 
          // tabControl
          // 
          this.tabControl.Controls.Add(this.tabPageContacts);
          this.tabControl.Controls.Add(this.tabPagePhone);
          this.tabControl.Location = new System.Drawing.Point(0, 0);
          this.tabControl.Name = "tabControl";
          this.tabControl.SelectedIndex = 0;
          this.tabControl.Size = new System.Drawing.Size(240, 246);
          this.tabControl.TabIndex = 0;
          this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
          // 
          // tabPageContacts
          // 
          this.tabPageContacts.Controls.Add(this.textBoxNumber);
          this.tabPageContacts.Controls.Add(this.listViewContacts);
          this.tabPageContacts.Location = new System.Drawing.Point(0, 0);
          this.tabPageContacts.Name = "tabPageContacts";
          this.tabPageContacts.Size = new System.Drawing.Size(240, 223);
          this.tabPageContacts.Text = "Contacts";
          // 
          // textBoxNumber
          // 
          this.textBoxNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.textBoxNumber.Dock = System.Windows.Forms.DockStyle.Top;
          this.textBoxNumber.Location = new System.Drawing.Point(0, 0);
          this.textBoxNumber.Name = "textBoxNumber";
          this.textBoxNumber.Size = new System.Drawing.Size(240, 21);
          this.textBoxNumber.TabIndex = 1;
          this.textBoxNumber.Text = "Enter a number...";
          this.textBoxNumber.GotFocus += new System.EventHandler(this.textBoxNumber_GotFocus);
          this.textBoxNumber.LostFocus += new System.EventHandler(this.textBoxNumber_LostFocus);
          // 
          // listViewContacts
          // 
          this.listViewContacts.Columns.Add(this.columnHeaderStatus);
          this.listViewContacts.Columns.Add(this.columnHeaderName);
          this.listViewContacts.Columns.Add(this.columnHeaderNumber);
          this.listViewContacts.ContextMenu = this.contextMenuContacts;
          this.listViewContacts.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.listViewContacts.FullRowSelect = true;
          this.listViewContacts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
          this.listViewContacts.Location = new System.Drawing.Point(0, 20);
          this.listViewContacts.Name = "listViewContacts";
          this.listViewContacts.Size = new System.Drawing.Size(240, 203);
          this.listViewContacts.TabIndex = 0;
          this.listViewContacts.View = System.Windows.Forms.View.Details;
          // 
          // columnHeaderStatus
          // 
          this.columnHeaderStatus.Text = "S";
          this.columnHeaderStatus.Width = 10;
          // 
          // columnHeaderName
          // 
          this.columnHeaderName.Text = "Name";
          this.columnHeaderName.Width = 102;
          // 
          // columnHeaderNumber
          // 
          this.columnHeaderNumber.Text = "Number";
          this.columnHeaderNumber.Width = 114;
          // 
          // tabPagePhone
          // 
          this.tabPagePhone.Controls.Add(this.listViewBackground);
          this.tabPagePhone.Controls.Add(this.checkBoxSpeakerPhone);
          this.tabPagePhone.Controls.Add(this.pictureBox1);
          this.tabPagePhone.Controls.Add(this.labelDuration);
          this.tabPagePhone.Controls.Add(this.labelCallStatus);
          this.tabPagePhone.Controls.Add(this.labelName);
          this.tabPagePhone.Location = new System.Drawing.Point(0, 0);
          this.tabPagePhone.Name = "tabPagePhone";
          this.tabPagePhone.Size = new System.Drawing.Size(240, 223);
          this.tabPagePhone.Text = "Calling...";
          // 
          // listViewBackground
          // 
          this.listViewBackground.Columns.Add(this.columnHeader1);
          this.listViewBackground.ContextMenu = this.contextMenuBackgroundCalls;
          this.listViewBackground.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
          this.listViewBackground.FullRowSelect = true;
          this.listViewBackground.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
          this.listViewBackground.Location = new System.Drawing.Point(127, 175);
          this.listViewBackground.Name = "listViewBackground";
          this.listViewBackground.Size = new System.Drawing.Size(112, 48);
          this.listViewBackground.TabIndex = 9;
          this.listViewBackground.View = System.Windows.Forms.View.Details;
          this.listViewBackground.Visible = false;
          // 
          // columnHeader1
          // 
          this.columnHeader1.Text = "number";
          this.columnHeader1.Width = 101;
          // 
          // checkBoxSpeakerPhone
          // 
          this.checkBoxSpeakerPhone.Location = new System.Drawing.Point(3, 175);
          this.checkBoxSpeakerPhone.Name = "checkBoxSpeakerPhone";
          this.checkBoxSpeakerPhone.Size = new System.Drawing.Size(100, 20);
          this.checkBoxSpeakerPhone.TabIndex = 4;
          this.checkBoxSpeakerPhone.Text = "Loudspeaker";
          this.checkBoxSpeakerPhone.Click += new System.EventHandler(this.checkBoxSpeakerPhone_CheckStateChanged);
          // 
          // pictureBox1
          // 
          this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
          this.pictureBox1.Location = new System.Drawing.Point(69, 80);
          this.pictureBox1.Name = "pictureBox1";
          this.pictureBox1.Size = new System.Drawing.Size(100, 68);
          this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
          // 
          // labelDuration
          // 
          this.labelDuration.Location = new System.Drawing.Point(80, 152);
          this.labelDuration.Name = "labelDuration";
          this.labelDuration.Size = new System.Drawing.Size(80, 20);
          this.labelDuration.Text = "...";
          this.labelDuration.TextAlign = System.Drawing.ContentAlignment.TopCenter;
          // 
          // labelCallStatus
          // 
          this.labelCallStatus.Location = new System.Drawing.Point(7, 57);
          this.labelCallStatus.Name = "labelCallStatus";
          this.labelCallStatus.Size = new System.Drawing.Size(226, 20);
          this.labelCallStatus.Text = "Status";
          this.labelCallStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
          // 
          // labelName
          // 
          this.labelName.Location = new System.Drawing.Point(7, 22);
          this.labelName.Name = "labelName";
          this.labelName.Size = new System.Drawing.Size(226, 20);
          this.labelName.Text = "Name";
          this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
          // 
          // statusBar1
          // 
          this.statusBar1.Location = new System.Drawing.Point(0, 246);
          this.statusBar1.Name = "statusBar1";
          this.statusBar1.Size = new System.Drawing.Size(240, 22);
          // 
          // PhoneForm
          // 
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
          this.ClientSize = new System.Drawing.Size(240, 268);
          this.Controls.Add(this.statusBar1);
          this.Controls.Add(this.tabControl);
          this.Menu = this.mainMenu;
          this.Name = "PhoneForm";
          this.Text = "Sipek Mobile";
          this.Load += new System.EventHandler(this.PhoneForm_Load);
          this.tabControl.ResumeLayout(false);
          this.tabPageContacts.ResumeLayout(false);
          this.tabPagePhone.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

      private System.Windows.Forms.MainMenu mainMenu;
      private System.Windows.Forms.ContextMenu contextMenuBackgroundCalls;
      private System.Windows.Forms.ContextMenu contextMenuContacts;
      private System.Windows.Forms.TabControl tabControl;
      private System.Windows.Forms.TabPage tabPagePhone;
      private System.Windows.Forms.TabPage tabPageContacts;
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.Label labelCallStatus;
      private System.Windows.Forms.Label labelName;
      private System.Windows.Forms.Label labelDuration;
      private System.Windows.Forms.TextBox textBoxNumber;
      private System.Windows.Forms.ListView listViewContacts;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.ColumnHeader columnHeaderName;
      private System.Windows.Forms.ColumnHeader columnHeaderNumber;
      private System.Windows.Forms.MenuItem menuItemConactsCall;
      private System.Windows.Forms.ColumnHeader columnHeaderStatus;
      private System.Windows.Forms.MenuItem menuItemMessage;
      private System.Windows.Forms.CheckBox checkBoxSpeakerPhone;
      private System.Windows.Forms.ListView listViewBackground;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.MenuItem menuItemActivate;


      }
}