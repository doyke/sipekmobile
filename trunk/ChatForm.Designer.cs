namespace SipekMobile
{
  partial class ChatForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MainMenu mainMenu;

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
      this.mainMenu = new System.Windows.Forms.MainMenu();
      this.menuItemCancel = new System.Windows.Forms.MenuItem();
      this.menuItemSend = new System.Windows.Forms.MenuItem();
      this.textBoxInput = new System.Windows.Forms.TextBox();
      this.textBoxHistory = new System.Windows.Forms.TextBox();
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.SuspendLayout();
      // 
      // mainMenu
      // 
      this.mainMenu.MenuItems.Add(this.menuItemCancel);
      this.mainMenu.MenuItems.Add(this.menuItemSend);
      // 
      // menuItemCancel
      // 
      this.menuItemCancel.Text = "Cancel";
      this.menuItemCancel.Click += new System.EventHandler(this.menuItemCancel_Click);
      // 
      // menuItemSend
      // 
      this.menuItemSend.Text = "Send";
      this.menuItemSend.Click += new System.EventHandler(this.menuItemSend_Click);
      // 
      // textBoxInput
      // 
      this.textBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Top;
      this.textBoxInput.Location = new System.Drawing.Point(0, 0);
      this.textBoxInput.Multiline = true;
      this.textBoxInput.Name = "textBoxInput";
      this.textBoxInput.Size = new System.Drawing.Size(240, 59);
      this.textBoxInput.TabIndex = 0;
      // 
      // textBoxHistory
      // 
      this.textBoxHistory.BackColor = System.Drawing.Color.Gainsboro;
      this.textBoxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxHistory.Location = new System.Drawing.Point(0, 59);
      this.textBoxHistory.Multiline = true;
      this.textBoxHistory.Name = "textBoxHistory";
      this.textBoxHistory.ReadOnly = true;
      this.textBoxHistory.Size = new System.Drawing.Size(240, 209);
      this.textBoxHistory.TabIndex = 1;
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 246);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(240, 22);
      // 
      // ChatForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(240, 268);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.textBoxHistory);
      this.Controls.Add(this.textBoxInput);
      this.Menu = this.mainMenu;
      this.Name = "ChatForm";
      this.Text = "Chat Room";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxInput;
    private System.Windows.Forms.TextBox textBoxHistory;
    private System.Windows.Forms.MenuItem menuItemCancel;
    private System.Windows.Forms.MenuItem menuItemSend;
    private System.Windows.Forms.StatusBar statusBar;
  }
}