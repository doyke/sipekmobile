namespace SipekMobile
{
    partial class PhoneForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoneForm));
          this.mainMenu1 = new System.Windows.Forms.MainMenu();
          this.menuItem1 = new System.Windows.Forms.MenuItem();
          this.menuItemSettings = new System.Windows.Forms.MenuItem();
          this.menuItem2 = new System.Windows.Forms.MenuItem();
          this.menuItem3 = new System.Windows.Forms.MenuItem();
          this.buttonCall = new System.Windows.Forms.Button();
          this.statusBar1 = new System.Windows.Forms.StatusBar();
          this.buttonRelease = new System.Windows.Forms.Button();
          this.listViewCallLines = new System.Windows.Forms.ListView();
          this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
          this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
          this.contextMenuStripCalls = new System.Windows.Forms.ContextMenu();
          this.releaseToolStripMenuItem = new System.Windows.Forms.MenuItem();
          this.holdRetrieveToolStripMenuItem = new System.Windows.Forms.MenuItem();
          this.acceptMenuItem = new System.Windows.Forms.MenuItem();
          this.transferMenuItem = new System.Windows.Forms.MenuItem();
          this.transferNumberMenuItem = new System.Windows.Forms.MenuItem();
          this.ConferenceMenuItem = new System.Windows.Forms.MenuItem();
          this.label1 = new System.Windows.Forms.Label();
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          this.textBoxDial = new System.Windows.Forms.TextBox();
          this.SuspendLayout();
          // 
          // mainMenu1
          // 
          this.mainMenu1.MenuItems.Add(this.menuItem1);
          // 
          // menuItem1
          // 
          this.menuItem1.MenuItems.Add(this.menuItemSettings);
          this.menuItem1.MenuItems.Add(this.menuItem2);
          this.menuItem1.MenuItems.Add(this.menuItem3);
          this.menuItem1.Text = "Menu";
          // 
          // menuItemSettings
          // 
          this.menuItemSettings.Text = "Settings";
          this.menuItemSettings.Click += new System.EventHandler(this.menuItem4_Click);
          // 
          // menuItem2
          // 
          this.menuItem2.Text = "About";
          this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
          // 
          // menuItem3
          // 
          this.menuItem3.Text = "Exit";
          this.menuItem3.Click += new System.EventHandler(this.exitButton_Click);
          // 
          // buttonCall
          // 
          this.buttonCall.BackColor = System.Drawing.Color.MediumSeaGreen;
          this.buttonCall.Location = new System.Drawing.Point(132, 27);
          this.buttonCall.Name = "buttonCall";
          this.buttonCall.Size = new System.Drawing.Size(49, 20);
          this.buttonCall.TabIndex = 31;
          this.buttonCall.Text = "Call";
          this.buttonCall.Click += new System.EventHandler(this.callButton_Click);
          // 
          // statusBar1
          // 
          this.statusBar1.Location = new System.Drawing.Point(0, 246);
          this.statusBar1.Name = "statusBar1";
          this.statusBar1.Size = new System.Drawing.Size(240, 22);
          this.statusBar1.Text = "Not Initialized / Configure Settings";
          // 
          // buttonRelease
          // 
          this.buttonRelease.BackColor = System.Drawing.Color.IndianRed;
          this.buttonRelease.Location = new System.Drawing.Point(187, 27);
          this.buttonRelease.Name = "buttonRelease";
          this.buttonRelease.Size = new System.Drawing.Size(50, 20);
          this.buttonRelease.TabIndex = 34;
          this.buttonRelease.Text = "Clear";
          this.buttonRelease.Click += new System.EventHandler(this.releaseButton_Click);
          // 
          // listViewCallLines
          // 
          this.listViewCallLines.Columns.Add(this.columnHeader1);
          this.listViewCallLines.Columns.Add(this.columnHeader2);
          this.listViewCallLines.Columns.Add(this.columnHeader3);
          this.listViewCallLines.ContextMenu = this.contextMenuStripCalls;
          this.listViewCallLines.FullRowSelect = true;
          this.listViewCallLines.Location = new System.Drawing.Point(3, 67);
          this.listViewCallLines.Name = "listViewCallLines";
          this.listViewCallLines.Size = new System.Drawing.Size(234, 71);
          this.listViewCallLines.TabIndex = 40;
          this.listViewCallLines.View = System.Windows.Forms.View.Details;
          // 
          // columnHeader1
          // 
          this.columnHeader1.Text = "Call State";
          this.columnHeader1.Width = 64;
          // 
          // columnHeader2
          // 
          this.columnHeader2.Text = "Number/Name";
          this.columnHeader2.Width = 96;
          // 
          // columnHeader3
          // 
          this.columnHeader3.Text = "Duration";
          this.columnHeader3.Width = 70;
          // 
          // contextMenuStripCalls
          // 
          this.contextMenuStripCalls.MenuItems.Add(this.releaseToolStripMenuItem);
          this.contextMenuStripCalls.MenuItems.Add(this.holdRetrieveToolStripMenuItem);
          this.contextMenuStripCalls.MenuItems.Add(this.acceptMenuItem);
          this.contextMenuStripCalls.MenuItems.Add(this.transferMenuItem);
          this.contextMenuStripCalls.MenuItems.Add(this.ConferenceMenuItem);
          this.contextMenuStripCalls.Popup += new System.EventHandler(this.contextMenuStripCalls_Popup);
          // 
          // releaseToolStripMenuItem
          // 
          this.releaseToolStripMenuItem.Text = "Release";
          this.releaseToolStripMenuItem.Click += new System.EventHandler(this.releaseButton_Click);
          // 
          // holdRetrieveToolStripMenuItem
          // 
          this.holdRetrieveToolStripMenuItem.Text = "Hold/retrieve";
          this.holdRetrieveToolStripMenuItem.Click += new System.EventHandler(this.holdRetrieveToolStripMenuItem_Click);
          // 
          // acceptMenuItem
          // 
          this.acceptMenuItem.Text = "Accept";
          this.acceptMenuItem.Click += new System.EventHandler(this.callButton_Click);
          // 
          // transferMenuItem
          // 
          this.transferMenuItem.MenuItems.Add(this.transferNumberMenuItem);
          this.transferMenuItem.Text = "Transfer";
          // 
          // transferNumberMenuItem
          // 
          this.transferNumberMenuItem.Text = "";
          // 
          // ConferenceMenuItem
          // 
          this.ConferenceMenuItem.Text = "Conference";
          // 
          // label1
          // 
          this.label1.Location = new System.Drawing.Point(55, 213);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(168, 20);
          this.label1.Text = "Copyright (c) Sasa Coh 2009";
          // 
          // pictureBox1
          // 
          this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
          this.pictureBox1.Location = new System.Drawing.Point(15, 203);
          this.pictureBox1.Name = "pictureBox1";
          this.pictureBox1.Size = new System.Drawing.Size(34, 30);
          this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
          // 
          // textBoxDial
          // 
          this.textBoxDial.Location = new System.Drawing.Point(3, 26);
          this.textBoxDial.Name = "textBoxDial";
          this.textBoxDial.Size = new System.Drawing.Size(122, 21);
          this.textBoxDial.TabIndex = 46;
          // 
          // PhoneForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
          this.AutoScroll = true;
          this.ClientSize = new System.Drawing.Size(240, 268);
          this.Controls.Add(this.textBoxDial);
          this.Controls.Add(this.pictureBox1);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.listViewCallLines);
          this.Controls.Add(this.buttonRelease);
          this.Controls.Add(this.statusBar1);
          this.Controls.Add(this.buttonCall);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Menu = this.mainMenu1;
          this.Name = "PhoneForm";
          this.Text = "Sipek Mobile";
          this.Closing += new System.ComponentModel.CancelEventHandler(this.PhoneForm_Closing);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.Button buttonCall;
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.Button buttonRelease;
      private System.Windows.Forms.MenuItem menuItemSettings;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.ListView listViewCallLines;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.ContextMenu contextMenuStripCalls;
      private System.Windows.Forms.MenuItem releaseToolStripMenuItem;
      private System.Windows.Forms.MenuItem holdRetrieveToolStripMenuItem;
      private System.Windows.Forms.MenuItem acceptMenuItem;
      private System.Windows.Forms.MenuItem transferMenuItem;
      private System.Windows.Forms.MenuItem ConferenceMenuItem;
      private System.Windows.Forms.MenuItem transferNumberMenuItem;
      private System.Windows.Forms.TextBox textBoxDial;
    }
}