namespace SipekMobile
{
  partial class FormAbout
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.textBoxCredits = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.Add(this.menuItem1);
      // 
      // menuItem1
      // 
      this.menuItem1.Text = "Close";
      this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
      // 
      // textBox1
      // 
      this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox1.Location = new System.Drawing.Point(34, 111);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(171, 51);
      this.textBox1.TabIndex = 0;
      this.textBox1.Text = "Sipek Mobile is a free & simple SIP client for Windows Mobile devices.";
      this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(34, 208);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(171, 20);
      this.label1.Text = "Copyright (c) Sasa Coh 2009";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(83, 15);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(76, 78);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      // 
      // linkLabel1
      // 
      this.linkLabel1.Location = new System.Drawing.Point(3, 238);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(234, 20);
      this.linkLabel1.TabIndex = 3;
      this.linkLabel1.Text = "http://sites.google.com/site/sipekvoip/";
      this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // textBoxCredits
      // 
      this.textBoxCredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBoxCredits.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
      this.textBoxCredits.Location = new System.Drawing.Point(162, 15);
      this.textBoxCredits.Multiline = true;
      this.textBoxCredits.Name = "textBoxCredits";
      this.textBoxCredits.Size = new System.Drawing.Size(75, 78);
      this.textBoxCredits.TabIndex = 6;
      this.textBoxCredits.Text = "Mobile GUI v0.1\r\nrev. 007\r\nSipekSdk v0.3\r\nrev. 112\r\npjsip.org v1.0";
      this.textBoxCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // FormAbout
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(240, 268);
      this.Controls.Add(this.textBoxCredits);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox1);
      this.Menu = this.mainMenu1;
      this.Name = "FormAbout";
      this.Text = "About Sipek Mobile";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.TextBox textBoxCredits;
  }
}