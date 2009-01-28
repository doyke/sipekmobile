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
 * A simple Windows Mobile SIP client.
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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

using Sipek.Common.CallControl;
using Sipek.Sip;
using Sipek.Common;



namespace SipekMobile
{
    /*
     * A Main Form
     */ 
    public partial class PhoneForm : Form
    {
      #region Native Interface
      
      [DllImport("CoreDll.dll", EntryPoint = "PlaySound", SetLastError = true)]
      private extern static int PlaySound(string szSound, IntPtr hMod, int flags);
      
      #endregion


      #region Properties

      // An application folder path
      internal static string _appFolder = "";

      // A periodic timer for Call List refresh (duration)
      private Timer _refreshTimer = new Timer();  
      
      // A SipekSdk's CallManager Instance
      CCallManager CallManager
      {
        get { return CCallManager.Instance; }
      }

      // A phone configuration structure
      PhoneConfigInterface _config = new PhoneConfigInterface();
      PhoneConfigInterface Config
      {
        get { return _config; }
        set { _config = value; }
      }

      #endregion

      /// <summary>
      /// 
      /// </summary>
      public PhoneForm()
      {
        InitializeComponent();

        //////////////////////////////////////////////////////////////////////////
        // Phone initialization
        //////////////////////////////////////////////////////////////////////////

        // get the application path
        _appFolder = Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
                    ).Replace(@"file:\", "");
        //Directory.SetCurrentDirectory(_appFolder);

        // Set a refresh timer to 1 second
        _refreshTimer.Interval = 1000;
        _refreshTimer.Tick += new EventHandler(UpdateCallTimeout);

        // initialize stack proxy, registrar and call manager
        pjsipStackProxy.Instance.Config = Config;
        pjsipRegistrar.Instance.Config = Config;
        CallManager.Config = Config;
        CallManager.StackProxy = pjsipStackProxy.Instance;
        CallManager.MediaProxy = new CMediaPlayerProxy();
        CallManager.Factory = new MobileFactory(this);

        //  register for stack events
        pjsipRegistrar.Instance.AccountStateChanged += new DAccountStateChanged(proxy_AccountStateChanged);
        pjsipStackProxy.Instance.MessageWaitingIndication += new DMessageWaitingNotification(Instance_MessageWaitingIndication);
        //pjsipStackProxy.Instance.MessageWaitingIndication += new DMessageWaitingNotification(Instance_MessageWaitingIndication);
        //  register for SipekSdk events
        CallManager.CallStateRefresh += new DCallStateRefresh(CallManager_CallStateRefresh);
        CallManager.IncomingCallNotification += new DIncomingCallNotification(CallManager_IncomingCallNotification);

        // Check for configuration 
        if ((Config.Accounts.Count == 0) || (Config.Accounts[0].HostName.Length == 0))
        {
          if (OpenSettingsDialog() != DialogResult.OK)
          {
            // Stack not initialized...
            return;
          }
        }

        // start the phone application
        CallManager.Initialize();

        // register accounts
        pjsipRegistrar.Instance.registerAccounts();

      }

      #region Internals

      private void UpdateCallTimeout(object sender, EventArgs e)
      {
        if (listViewCallLines.Items.Count == 0) return;

        for (int i = 0; i < listViewCallLines.Items.Count; i++)
        {
          ListViewItem item = listViewCallLines.Items[i];
          IStateMachine sm = (IStateMachine)item.Tag;
          if (sm.IsNull) continue;

          string duration = sm.RuntimeDuration.ToString();
          if (duration.IndexOf('.') > 0) 
            duration = duration.Remove(duration.IndexOf('.'), duration.Length); // remove miliseconds

          item.SubItems[2].Text = duration;
        }
        // restart timer
        if (listViewCallLines.Items.Count > 0)
        {
          _refreshTimer.Enabled = true;
        }
        else
        {
          _refreshTimer.Enabled = false;
        }

      }

      private DialogResult OpenSettingsDialog()
      {
        return (new SettingsForm()).ShowDialog();
      }


      #endregion


      #region SipekSdk Callbacks

      private void sync_StateChanged(int sessionId)
      {
        listViewCallLines.Items.Clear();

        try
        {
          // get entire call list
          Dictionary<int, IStateMachine> callList = CallManager.CallList;

          foreach (KeyValuePair<int, IStateMachine> kvp in callList)
          {
            string number = kvp.Value.CallingNumber;
            string name = kvp.Value.CallingName;

            string duration = kvp.Value.Duration.ToString();
            if (duration.IndexOf('.') > 0) 
              duration = duration.Remove(duration.IndexOf('.'), duration.Length); // remove miliseconds

            // show name & number or just number
            string display = name.Length > 0 ? name + " / " + number : number;
            string stateName = kvp.Value.StateId.ToString();
            //if (SipekResources.CallManager.Is3Pty) stateName = "CONFERENCE";
            ListViewItem lvi = new ListViewItem(new string[] {
            stateName, display, duration});

            lvi.Tag = kvp.Value;
            listViewCallLines.Items.Add(lvi);
            lvi.Selected = true;

            // display info
            //toolStripStatusLabel1.Text = item.Value.lastInfoMessage;
          }

        }
        catch (Exception e)
        {
          // TODO!!!!!!!!!!! Synchronize SHARED RESOURCES!!!!
        }

        this.Refresh();
      }
     
      void CallManager_IncomingCallNotification(int sessionId, string number, string info)
      {
        if (this.InvokeRequired)
        {
          Invoke(new DIncomingCallNotification(sync_IncomingCall), new object[] {sessionId,number,info});
        }
        else
        {
          sync_IncomingCall(sessionId, number, info);
        }
      }

      void sync_IncomingCall(int sessionId, string number, string info)
      {
      }

      void CallManager_CallStateRefresh(int sessionId)
      {
        if (this.InvokeRequired)
        {
          Invoke(new DCallStateRefresh(sync_StateChanged), new object[] { sessionId });
        }
        else
        {
          sync_StateChanged(sessionId);
        }
      }

      /// <summary>
      /// Invoke status refresh. First check for cross threading!!!
      /// </summary>
      /// <param name="accountId"></param>
      /// <param name="accState"></param>
      void proxy_AccountStateChanged(int accountId, int accState)
      {
        if (this.InvokeRequired)
        {
          Invoke(new DAccountStateChanged(proxy_AccountStateChanged), new object[] { accountId, accState });
        }
        else
        {
          sync_AccountStateChanged(accountId, accState);
        }
      }

      /// <summary>
      /// Update registration status
      /// </summary>
      /// <param name="accId"></param>
      /// <param name="accState"></param>
      private void sync_AccountStateChanged(int accId, int accState)
      {
        if (accState != 0)
        {
          if (accState == 200)
          {
            int index = Config.Accounts[Config.DefaultAccountIndex].Index;
            statusBar1.Text = "Registered";
          }
          else if (accState == 408)
          {
            MessageBox.Show("Request Timeout");
            statusBar1.Text = "Registration Error";
          }
          else
          {
            //MessageBox.Show("Registration failed");
            statusBar1.Text = "Registration Error";
          }

        }
        else
        {
          statusBar1.Text = "Registering...";
        }
      }


      void Instance_MessageWaitingIndication(int mwi, string text)
      {

      }

      #endregion


      #region GUI handlers
      private void callButton_Click(object sender, EventArgs e)
      {
        _refreshTimer.Enabled = true;

        // check for incoming calls
        List<IStateMachine> calls = (List<IStateMachine>)CallManager.enumCallsInState(EStateId.INCOMING);
        if (calls.Count > 0)
        {
          if (listViewCallLines.SelectedIndices.Count > 0)
          {
            int index = listViewCallLines.SelectedIndices[0];
            ListViewItem lvi = listViewCallLines.Items[index];
            CallManager.onUserAnswer(((CStateMachine)lvi.Tag).Session);
          }
        }
        else
        {
          CallManager.createOutboundCall(textBoxDial.Text);

          sync_StateChanged(-1);
        }

      }

      private void releaseButton_Click(object sender, EventArgs e)
      {
        if (listViewCallLines.SelectedIndices.Count > 0)
        {
          int index = listViewCallLines.SelectedIndices[0];
          ListViewItem lvi = listViewCallLines.Items[index];
          CallManager.onUserRelease(((CStateMachine)lvi.Tag).Session);
        }
      }

      private void exitButton_Click(object sender, EventArgs e)
      {
        Close();

          //try
          //{
          //    Process.GetCurrentProcess().Kill();
          //}
          //catch (Exception o)
          //{ }
      }


      private void menuItem4_Click(object sender, EventArgs e)
      {
        if (OpenSettingsDialog() == DialogResult.OK)
        {
          CallManager.Initialize();
          pjsipRegistrar.Instance.registerAccounts();
        }
      }

      private void PhoneForm_Closing(object sender, CancelEventArgs e)
      {
        pjsipStackProxy.Instance.shutdown();
      }

      private void menuItem2_Click(object sender, EventArgs e)
      {
        (new FormAbout()).ShowDialog();
      }

      private void contextMenuStripCalls_Popup(object sender, EventArgs e)
      {
        // Hide all items...
        contextMenuStripCalls.MenuItems.Clear();

        if (listViewCallLines.SelectedIndices.Count > 0)
        {
          int  index = listViewCallLines.SelectedIndices[0];
          ListViewItem lvi = listViewCallLines.Items[index];
          if (CallManager.Count <= 0)
          {
            return;
          }
          else
          {
            EStateId stateId = ((CStateMachine)lvi.Tag).StateId;
            // add release menu item anyway
            contextMenuStripCalls.MenuItems.Add(releaseToolStripMenuItem);
            switch (stateId)
            {
              case EStateId.INCOMING:
                contextMenuStripCalls.MenuItems.Add(acceptMenuItem);
                contextMenuStripCalls.MenuItems.Add(transferMenuItem);
                break;
              case EStateId.ACTIVE:
                holdRetrieveToolStripMenuItem.Text = "Hold";
                contextMenuStripCalls.MenuItems.Add(holdRetrieveToolStripMenuItem);
                contextMenuStripCalls.MenuItems.Add(transferMenuItem);
                break;
              case EStateId.HOLDING:
                holdRetrieveToolStripMenuItem.Text = "Retrieve";
                contextMenuStripCalls.MenuItems.Add(holdRetrieveToolStripMenuItem);
                break;
            }

          }
          // call
          //releaseToolStripMenuItem.Visible = true;
        }
      }

      private void holdRetrieveToolStripMenuItem_Click(object sender, EventArgs e)
      {
        // get call session
        if (listViewCallLines.SelectedIndices.Count > 0)
        {
          int index = listViewCallLines.SelectedIndices[0];
          ListViewItem lvi = listViewCallLines.Items[index];
          CallManager.onUserHoldRetrieve(((CStateMachine)lvi.Tag).Session);
        }
      }
      #endregion


    }
}