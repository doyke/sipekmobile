/* 
 * Copyright (C) 2008 Sasa Coh <sasacoh@gmail.com>
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
 * @see http://sites.google.com/site/sipekvoip/
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sipek.Sip;
using Sipek.Common;
using Sipek.Common.CallControl;

namespace SipekMobile
{
    public partial class SettingsForm : Form
    {

      PhoneConfigInterface _config;
      PhoneConfigInterface Config
      {
        get {
          if (_config == null)
            _config = new PhoneConfigInterface();
          return _config; 
        }
      }


      public SettingsForm()
      {
        InitializeComponent();

        // load values
        textBoxUserName.Text = Config.Accounts[0].UserName;
        textBoxPW.Text       = Config.Accounts[0].Password;
        textBoxHostName.Text = Config.Accounts[0].HostName;
        comboBoxTransportMode.SelectedIndex = (int)Config.Accounts[0].TransportMode;

      }



      private void exitButton_Click(object sender, EventArgs e)
      {
        pjsipStackProxy.Instance.shutdown();
        Close();
          //try
          //{
          //    System.Diagnostics.Process.GetCurrentProcess().Kill();
          //}
          //catch (Exception j)
          //{ }

      }

      private void buttonApply_Click(object sender, EventArgs e)
      {
        Config.Accounts[0].Id = this.textBoxUserName.Text;
        Config.Accounts[0].UserName = this.textBoxUserName.Text;
        Config.Accounts[0].Password = this.textBoxPW.Text;
        Config.Accounts[0].HostName = this.textBoxHostName.Text;
        Config.Accounts[0].TransportMode = (ETransportMode)comboBoxTransportMode.SelectedIndex;

        Config.Save();

        Close();
      }

    }
}