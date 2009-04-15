/* 
 * Copyright (C) 2009 Sasa Coh <sasacoh@gmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 
 * 
 * 
 * A simple Windows Mobile SIP client.
 * 
 * 
 * @see http://sites.google.com/site/sipekvoip/ 
 * @see http://sites.google.com/site/sipekvoip/sipek-mobile
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sipek.Sip;
using System.IO;
using Sipek.Common;
using Sipek.Common.CallControl;

namespace SipekMobile
{
  public partial class ChatForm : Form
  {
    private string mbuddy = "";
    private int mSessionId = -1;
    private string _initTitle = "";

    public string ReceivedMessage
    {
      set { textBoxHistory.Text += value; }
    }

    public string Title
    {
      set { this.Text = _initTitle + " - " + value; }
    }


    public ChatForm()
    {
      InitializeComponent();
      _initTitle = Text;
    }

    public ChatForm(int session) : this()
    {
      mSessionId = session;
    }

    public ChatForm(string title)
      : this()
    {
      mbuddy = title;
      Title = title;
    }

    private void menuItemCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void menuItemSend_Click(object sender, EventArgs e)
    {
      int status = -1;

      statusBar.Text = "Sending message...";

      if (mSessionId > -1)
      {
        status = CCallManager.Instance.onUserSendCallMessage(mSessionId, textBoxInput.Text) == true ? 0 : -1;
      }
      else
      {
        status = pjsipPresenceAndMessaging.Instance.sendMessage(mbuddy, textBoxInput.Text);
      }

      if (status < 0)
      {
        statusBar.Text = "Error: " + status;
      }
      else
      {
        statusBar.Text = "Message sent!";
      }

      textBoxHistory.Text += "me: " + textBoxInput.Text + "\\r\\n";
      textBoxInput.Text = "";
    }


  }
}