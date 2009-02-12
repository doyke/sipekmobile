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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

using Sipek.Common.CallControl;
using Sipek.Sip;
using Sipek.Common;
using Microsoft.WindowsMobile.PocketOutlook;



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

      //
      IPresenceAndMessaging Messenger
      {
        get { return pjsipPresenceAndMessaging.Instance; }
      }

      // A phone configuration structure
      PhoneConfigInterface _config = new PhoneConfigInterface();
      PhoneConfigInterface Config
      {
        get { return _config; }
        set { _config = value; }
      }

      IStateMachine ActiveSession {
        get {
          IStateMachine tmp = (IStateMachine)tabPagePhone.Tag;
          return tmp;
        }
      }

      ChatForm _chatForm = null; 

      #endregion

      #region Audio Device (RIL) Declarations
      //#define RIL_AUDIO_NONE                              (0x00000000)      // @constdefine No audio devices
      //#define RIL_AUDIO_HANDSET                           (0x00000001)      // @constdefine Handset
      //#define RIL_AUDIO_SPEAKERPHONE                      (0x00000002)      // @constdefine Speakerphone
      //#define RIL_AUDIO_HEADSET                           (0x00000003)      // @constdefine Headset
      //#define RIL_AUDIO_CARKIT                            (0x00000004)      // @constdefine Carkit
      //#define RIL_PARAM_ADI_ALL                           (0x00000003) // @paramdefine
      
      public delegate void RILRESULTCALLBACK(int dwCode, IntPtr hrCmdID, IntPtr lpData, int cbData, int dwParam);
      public delegate void RILNOTIFYCALLBACK(int dwCode, IntPtr lpData, int cbData, int dwParam);
      public static IntPtr hRil;

      [DllImport("ril.dll")]
      private static extern IntPtr RIL_Initialize(int dwIndex, RILRESULTCALLBACK pfnResult, RILNOTIFYCALLBACK pfnNotify, int dwNotificationClasses, int dwParam, out IntPtr lphRil);

      [DllImport("ril.dll")]
      private static extern IntPtr RIL_Deinitialize(IntPtr hRil);

      [DllImport("ril.dll")]
      private static extern IntPtr RIL_SetAudioDevices(IntPtr hRil, RILAUDIODEVICEINFO lpAudioDeviceInfo);

      [StructLayout(LayoutKind.Explicit)]
      class RILAUDIODEVICEINFO 
      {
        [FieldOffset(0)]
        public uint cbSize;
        [FieldOffset(4)]
        public uint dwParams;
        [FieldOffset(8)]
        public uint dwTxDevice;
        [FieldOffset(12)]
        public uint dwRxDevice;
      } 

      public static void f_notify(int dwCode, IntPtr lpData, int cbData, int dwParam)
      { 
      }

      public static void f_result(int dwCode, IntPtr hrCmdID, IntPtr lpData, int cbData, int dwParam)
      {
        //RILAUDIODEVICEINFO radi = new RILAUDIODEVICEINFO();
        //Marshal.PtrToStructure(lpData, radi);
      }
      #endregion

      #region Initialization

      MenuItem menuItemMenu = new MenuItem();
      MenuItem menuItemCall = new MenuItem();

      MenuItem menuSubitemAbout = new MenuItem();
      MenuItem menuSubitemSettings = new MenuItem();
      MenuItem menuSubitemRefresh = new MenuItem();
      MenuItem menuSubitemExit = new MenuItem();

      MenuItem menuItemRelease = new MenuItem();
      MenuItem menuItemCallMenu = new MenuItem();
      MenuItem menuItemCallAnswer = new MenuItem();

      MenuItem menuCallSubitemHold = new MenuItem();
      MenuItem menuCallSubitemRelease = new MenuItem();
      MenuItem menuCallSubitemMessage = new MenuItem();

      /// <summary>
      /// Constructor
      /// </summary>
      public PhoneForm()
      {
        InitializeComponent();

        // Application code
        InitializeMenus();

        // remove call tab...
        tabControl.Controls.Remove(tabPagePhone);

        // get the application path
        _appFolder = Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
                    ).Replace(@"file:\", "");
        //Directory.SetCurrentDirectory(_appFolder);

        // Set a call refresh timer to 1 second
        _refreshTimer.Interval = 1000;
        _refreshTimer.Tick += new EventHandler(UpdateCallTimeout);

        // Init
        initApplication();

      }

      /// <summary>
      /// 
      /// </summary>
      private void InitializeMenus()
      {
        // Init Controls
        menuItemMenu.Text = "Menu";
        menuItemCall.Text = "Call";
        menuItemCall.Click += new EventHandler(callButton_Click);

        menuSubitemAbout.Text = "About";
        menuSubitemAbout.Click += new EventHandler(menuItemAbout_Click);

        menuSubitemRefresh.Text = "Refresh";
        menuSubitemRefresh.Click += new EventHandler(menuItemRefresh_Click);

        menuSubitemSettings.Text = "Settings";
        menuSubitemSettings.Click += new EventHandler(menuItemSettings_Click);

        menuSubitemExit.Text = "Exit";
        menuSubitemExit.Click += new EventHandler(exitButton_Click);

        //////////////////////////////////////////////////////////////////////////
        menuItemRelease.Text = "Hang-Up";
        menuItemRelease.Click += new EventHandler(releaseButton_Click);

        menuItemCallMenu.Text = "Options";

        menuItemCallAnswer.Text = "Answer";
        menuItemCallAnswer.Click += new EventHandler(menuItemCallAnswer_Click);

        menuCallSubitemHold.Text = "Hold/resume";
        menuCallSubitemHold.Click += new EventHandler(holdRetrieveToolStripMenuItem_Click);

        menuCallSubitemRelease.Text = "Release";
        menuCallSubitemRelease.Click += new EventHandler(releaseButton_Click);

        menuCallSubitemMessage.Text = "Send a message";
        menuCallSubitemMessage.Click += new EventHandler(menuCallSubitemMessage_Click);
 
      }

      /// <summary>
      /// 
      /// </summary>
      private void BuildMainMenu()
      {
        // build menus
        mainMenu.MenuItems.Clear();
        mainMenu.MenuItems.Add(menuItemMenu);
        mainMenu.MenuItems.Add(menuItemCall);

        menuItemMenu.MenuItems.Clear();
        menuItemMenu.MenuItems.Add(menuSubitemAbout);
        menuItemMenu.MenuItems.Add(menuSubitemRefresh);
        menuItemMenu.MenuItems.Add(menuSubitemSettings);
        menuItemMenu.MenuItems.Add(menuSubitemExit);
      }

      /// <summary>
      /// Answer the incoming call
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void menuItemCallAnswer_Click(object sender, EventArgs e)
      {
        IStateMachine sm = (IStateMachine)tabPagePhone.Tag;

        if (sm.StateId == EStateId.INCOMING)
        {
          CallManager.onUserAnswer(sm.Session);
        }
      
      }

      /// <summary>
      /// Init application
      /// </summary>
      private void initApplication()
      {
        // Initialize Audio
        InitRILAudio();

        // Setup VoIP library - SipekSdk
        SetupVoIP();

        // Open settings dialog now if config's not complete!
        if (Config.Accounts[0].HostName.Length == 0)
        {
          OpenSettingsDialog();
        }
        else
        {
          InitializeVoIP();
        }
      }

      /// <summary>
      /// Initialize Audio
      /// </summary>
      private void InitRILAudio()
      {
        IntPtr res;
        RILRESULTCALLBACK result = new RILRESULTCALLBACK(f_result);
        RILNOTIFYCALLBACK notify = new RILNOTIFYCALLBACK(f_notify);
        res = RIL_Initialize(1, result, notify, (0x00010000 | 0x00020000 | 0x00080000), 0, out PhoneForm.hRil);
        if (res != IntPtr.Zero)
        {
          return;
        }

        RILAUDIODEVICEINFO audioDeviceInfo = new RILAUDIODEVICEINFO();
        audioDeviceInfo.cbSize = 16;
        audioDeviceInfo.dwParams = 0x00000003; //RIL_PARAM_ADI_ALL;
        audioDeviceInfo.dwRxDevice = 0x00000001;//RIL_AUDIO_HANDSET;
        audioDeviceInfo.dwTxDevice = 0x00000001;//RIL_AUDIO_HANDSET;
        res = RIL_SetAudioDevices(hRil, audioDeviceInfo);
      }

      /// <summary>
      /// Setup VoIP...
      /// </summary>
      private void SetupVoIP()
      {
        // Configure VoIP: stack proxy, registrar and call manager
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
      }

      /// <summary>
      /// Initialize VOIP library - SipekSdk
      /// </summary>
      private void InitializeVoIP()
      { 
        pjsipStackProxy.Instance.ConfigMore.logLevel = 5;

        // start the phone application
        CallManager.Initialize();

        // register accounts
        pjsipRegistrar.Instance.registerAccounts();
        
        // messaging and presence
        Messenger.Config = Config;
        Messenger.MessageReceived += new DMessageReceived(Instance_MessageReceived);
        Messenger.BuddyStatusChanged += new DBuddyStatusChanged(Messenger_BuddyStatusChanged);
      }

      /// <summary>
      /// Initialize Contacts...
      /// </summary>
      private void InitContacts()
      {
        OutlookSession os = new OutlookSession();
        ContactCollection contacts = os.Contacts.Items;
        listViewContacts.Items.Clear();
        foreach (Contact item in contacts)
        {
          string textName = item.ToString();
          string textNumber = item.MobileTelephoneNumber;
          ListViewItem lvi = new ListViewItem(new String[] { "", textName, textNumber });
          lvi.Tag = item;
          listViewContacts.Items.Add(lvi);
        
          // add item to buddy list and subscribe buddy presence
//           string sipname = normalize(textNumber);
//           int buddyId = Messenger.addBuddy(sipname, true);
//           // little hack to store buddy identification for later use
//           item.CustomerId = buddyId.ToString();
        }
        //int buddyId = Messenger.addBuddy("4444", true);

      }
      #endregion

      #region Internals

      /// <summary>
      /// Make an outgoing call...
      /// </summary>
      /// <param name="number"></param>
      /// <returns></returns>
      private bool MakeCall(string innumber)
      {
        if (innumber.Length == 0) return false;

        // normalize number format...
        string number = normalize(innumber);

        // in case having another call active...
        if (CallManager.Count == 1)
        {
          CallManager.createOutboundCall(number);

          // switch to calling screen and update data...
          tabControl.SelectedIndex = 1;
          CallManager_CallStateRefresh(-1);
          return true;
        }

        IStateMachine sm = CallManager.createOutboundCall(number);

        if (sm.IsNull)
        {
          MessageBox.Show("Call Failed!");
        }
        else
        {
          // check no of sessions...
          tabControl.Controls.Add(tabPagePhone);
          // store state machine instance
          tabPagePhone.Tag = sm;
          tabControl.SelectedIndex = 1;

          _refreshTimer.Enabled = true;

          sync_StateChanged(sm.Session);
        }

        return !sm.IsNull;
      }

      /// <summary>
      /// Update calling display periodicaly
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void UpdateCallTimeout(object sender, EventArgs e)
      {
        IStateMachine activeSession = (IStateMachine)tabPagePhone.Tag;

        // remove the call tab if no calls are active...
        if (CallManager.Count == 0)
        {
          tabControl.Controls.Remove(tabPagePhone);
          return;
        }

        // switch active session if IDLE
        if ((activeSession.StateId == EStateId.IDLE) && (CallManager.Count >= 1) && (listViewBackground.Items.Count > 0))
        {
          activeSession = (IStateMachine)listViewBackground.Items[0].Tag;
          // make it active
          tabPagePhone.Tag = activeSession;
          // refresh calling form
          sync_StateChanged(activeSession.Session);
        } 

        // calculate call duration
        string duration = activeSession.RuntimeDuration.ToString();
        if (duration.IndexOf('.') > 0)
          duration = duration.Remove(duration.IndexOf('.'), duration.Length); // remove miliseconds

        labelDuration.Text = duration;

        //// restart timer
        _refreshTimer.Enabled = true;

      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="activeSession"></param>
      private void UpdateCallMenus()
      {
        IStateMachine callSession = (IStateMachine)tabPagePhone.Tag;

        if (null == callSession) return;

        mainMenu.MenuItems.Clear();
        mainMenu.MenuItems.Add(menuItemCallMenu);
        mainMenu.MenuItems.Add(menuItemRelease);

        menuItemCallMenu.MenuItems.Clear();
        // add release menu item anyway
        menuItemCallMenu.MenuItems.Add(menuCallSubitemRelease);

        switch (callSession.StateId)
        {
          case EStateId.INCOMING:
            // Show Answer menu
            mainMenu.MenuItems.Remove(menuItemRelease);
            mainMenu.MenuItems.Add(menuItemCallAnswer);
            break;
          case EStateId.ACTIVE:
            menuCallSubitemHold.Text = "Hold";
            menuItemCallMenu.MenuItems.Add(menuCallSubitemHold);
            menuItemCallMenu.MenuItems.Add(menuCallSubitemMessage);
            break;
          case EStateId.HOLDING:
            menuCallSubitemHold.Text = "Resume";
            menuItemCallMenu.MenuItems.Add(menuCallSubitemHold);
            break;
        }

      }


      /// <summary>
      /// Open settings dialog and apply changes...
      /// </summary>
      private void OpenSettingsDialog()
      {
        if ((new SettingsForm()).ShowDialog() == DialogResult.OK)
        {
          // Init VoIP & register account
          InitializeVoIP();
        }
      }

      /// <summary>
      /// Normalize number format
      /// </summary>
      /// <param name="p"></param>
      /// <returns></returns>
      private string normalize(string p)
      {
        string tmp = p;
        tmp = tmp.Replace(" ", "");
        tmp = tmp.Replace("(", "");
        tmp = tmp.Replace(")", "");
        tmp = tmp.Replace("-", "");
        tmp = tmp.Replace("++", "00");
        tmp = tmp.Replace("+", "00");
        return tmp;
      }

      #endregion

      #region SipekSdk Callbacks


      /// <summary>
      /// Synchronizing...
      /// </summary>
      /// <param name="sessionId"></param>
      /// <param name="number"></param>
      /// <param name="info"></param>
      void CallManager_IncomingCallNotification(int sessionId, string number, string info)
      {
        if (this.InvokeRequired)
        {
          Invoke(new DIncomingCallNotification(sync_IncomingCall), new object[] { sessionId, number, info });
        }
        else
        {
          sync_IncomingCall(sessionId, number, info);
        }
      }

      /// <summary>
      /// Synchronized incoming call notification
      /// </summary>
      /// <param name="sessionId"></param>
      /// <param name="number"></param>
      /// <param name="info"></param>
      void sync_IncomingCall(int sessionId, string number, string info)
      {
        // 
        tabControl.Controls.Add(tabPagePhone);
        tabControl.SelectedIndex = 1;
        // make it active state machine 
        tabPagePhone.Tag = CallManager.CallList[sessionId];

        _refreshTimer.Enabled = true;

        sync_StateChanged(sessionId);
      }

      /// <summary>
      /// Synchronizing...
      /// </summary>
      /// <param name="sessionId"></param>
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
      /// Synchronized call state changed callback
      /// </summary>
      /// <param name="sessionId"></param>
      private void sync_StateChanged(int sessionId)
      {
        // get the active session
        IStateMachine activeSession = (IStateMachine)tabPagePhone.Tag;

        if (activeSession == null) return;
        // Check if hanging call...
        if (activeSession.StateId == EStateId.IDLE)
        {
          return;
        }

        // check if only one call left and is not active
        IStateMachine sm = CallManager.getCall(sessionId);


        if ((!sm.IsNull) && ((CallManager.Count == 1))
              && (sessionId != activeSession.Session))
        {
          // make it active
          tabPagePhone.Tag = sm;
          activeSession = sm;
        }

        // get entire call list
        Dictionary<int, IStateMachine> callList = CallManager.CallList;

        // remove call tab if no calls are active...
        if (callList.Count == 0)
        {
          tabControl.Controls.Remove(tabPagePhone);
          return;
        }

        // Update call data for active session only
        if (sessionId == activeSession.Session)
        {
          string number = activeSession.CallingNumber;
          string name = activeSession.CallingName;

          // show name & number or just number
          string display = name.Length > 0 ? name + " / " + number : number;
          string stateName = activeSession.StateId.ToString();
          if (CallManager.Is3Pty)
            stateName = "CONFERENCE";

          labelCallStatus.Text = stateName;
          labelName.Text = display;

        }

        listViewBackground.Items.Clear();
        listViewBackground.Visible = false;
        // update call info for "background" sessions
        foreach (KeyValuePair<int, IStateMachine> kvp in callList)
        {
          // ignore active session...
          if ((kvp.Value.StateId == EStateId.IDLE) || (kvp.Value.Session == activeSession.Session))
            continue;

          listViewBackground.Visible = true;

          string callingname = kvp.Value.CallingNumber;
          string callstate = kvp.Value.StateId.ToString();
          ListViewItem lvi = new ListViewItem(new string[] { callingname + ", " + callstate });
          lvi.Tag = kvp.Value;
          listViewBackground.Items.Add(lvi);
        }

        // Update call menu
        UpdateCallMenus();

        this.Refresh();
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
            statusBar1.Text = "Registered to " + Config.Accounts[Config.DefaultAccountIndex].HostName;
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


      /// <summary>
      /// 
      /// </summary>
      /// <param name="buddyId"></param>
      /// <param name="status"></param>
      /// <param name="text"></param>
      void Messenger_BuddyStatusChanged(int buddyId, int status, string text)
      {
        if (this.InvokeRequired)
        {
          Invoke(new DBuddyStatusChanged(sync_Messenger_BuddyStatusChanged), new object[] { buddyId, status, text });
        }
        else
        {
          sync_Messenger_BuddyStatusChanged(buddyId, status, text);
        }

      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="buddyId"></param>
      /// <param name="status"></param>
      /// <param name="text"></param>
      private void sync_Messenger_BuddyStatusChanged(int buddyId, int status, string text)
      {
        foreach (ListViewItem item in listViewContacts.Items)
        {
          Contact contact = (Contact)item.Tag;
          try
          {
            int cid = Int32.Parse(contact.CustomerId);
            if (buddyId == cid)
            {
              item.SubItems[0].Text = status.ToString();
            }
          }
          catch (System.Exception e)
          {
          }

        }
      }


      void Instance_MessageWaitingIndication(int mwi, string text)
      {

      }

      /// <summary>
      /// Instant message received - Synchro
      /// </summary>
      /// <param name="from"></param>
      /// <param name="text"></param>
      void Instance_MessageReceived(string from, string text)
      {
        if (this.InvokeRequired)
        {
          Invoke(new DMessageReceived(sync_Instance_MessageReceived), new object[] { from, text });
        }
        else
        {
          sync_Instance_MessageReceived(from, text);
        }
        
      }

      /// <summary>
      /// Instant message received handler...
      /// </summary>
      /// <param name="from"></param>
      /// <param name="text"></param>
      void sync_Instance_MessageReceived(string from, string text)
      {

        // check if ChatForm already opened
        if (_chatForm == null)
        {
          _chatForm = new ChatForm();
        }
        _chatForm.Title = from;
        _chatForm.ReceivedMessage = text;
        _chatForm.ShowDialog();
      }

      #endregion

      #region GUI handlers

      /// <summary>
      /// Get selected Item and make a call
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void callButton_Click(object sender, EventArgs e)
      {
        // make a call
        if ((listViewContacts.SelectedIndices.Count > 0) && (listViewContacts.Focused))
        {
          menuItemContactCall_Click(sender, e);
        }
        else
        {
          MakeCall(textBoxNumber.Text);
        }
      }

      /// <summary>
      /// Release the call
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void releaseButton_Click(object sender, EventArgs e)
      {
        if (CallManager.CallList.Count > 0)
        {
          CallManager.onUserRelease(((CStateMachine)tabPagePhone.Tag).Session);
        }

        textBoxNumber.Text = "";
      }

      /// <summary>
      /// Exit application
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void exitButton_Click(object sender, EventArgs e)
      {
        Close();
      }

      /// <summary>
      /// Open the settings dialog and reinitialize
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuItemSettings_Click(object sender, EventArgs e)
      {
        OpenSettingsDialog();
      }

      /// <summary>
      /// Handle shutdown...
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PhoneForm_Closing(object sender, CancelEventArgs e)
      {
        pjsipStackProxy.Instance.shutdown();
        // reinitialize RIL 
        RIL_Deinitialize(PhoneForm.hRil);
      }

      /// <summary>
      /// Open About Form
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuItemAbout_Click(object sender, EventArgs e)
      {
        (new FormAbout()).ShowDialog();
      }

      /// <summary>
      /// Send the call hold or retrieve request
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void holdRetrieveToolStripMenuItem_Click(object sender, EventArgs e)
      {
        IStateMachine sm = (CStateMachine)tabPagePhone.Tag;
        CallManager.onUserHoldRetrieve(sm.Session);
      }
      
      /// <summary>
      /// Set an audio output device using RIL
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void checkBoxSpeakerPhone_CheckStateChanged(object sender, EventArgs e)
      {
        RILAUDIODEVICEINFO audioDeviceInfo = new RILAUDIODEVICEINFO();
        audioDeviceInfo.cbSize = 16;
        audioDeviceInfo.dwParams = 0x00000003; //RIL_PARAM_ADI_ALL;

        if (checkBoxSpeakerPhone.Checked)
        {
          audioDeviceInfo.dwRxDevice = 0x00000000;//RIL_AUDIO_NONE;
          audioDeviceInfo.dwTxDevice = 0x00000000;//RIL_AUDIO_NONE;
        }
        else
        {
          audioDeviceInfo.dwRxDevice = 0x00000001;//RIL_AUDIO_HANDSET;
          audioDeviceInfo.dwTxDevice = 0x00000001;//RIL_AUDIO_HANDSET;
        }
        // Set audio device!!!
        RIL_SetAudioDevices(hRil, audioDeviceInfo);
      }

      /// <summary>
      /// Refresh registration and contact list
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuItemRefresh_Click(object sender, EventArgs e)
      {
        // (re)register accounts
        InitializeVoIP();

        // reinit contacts...
        InitContacts();
      }

      /// <summary>
      /// Make a call from contacts list
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuItemContactCall_Click(object sender, EventArgs e)
      {

        if (listViewContacts.SelectedIndices.Count > 0)
        {
          int index = listViewContacts.SelectedIndices[0];
          ListViewItem lvi = listViewContacts.Items[index];
          Contact ct = (Contact)lvi.Tag;
          if (ct.MobileTelephoneNumber.Length > 0)
          {
            // make a call
            MakeCall(ct.MobileTelephoneNumber);
          }
        }
      }

      /// <summary>
      /// Show a chat dialog
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void menuCallSubitemMessage_Click(object sender, EventArgs e)
      {
        if (null != ActiveSession)
        {
          (new ChatForm(ActiveSession.Session)).ShowDialog();
        }
      }

      /// <summary>
      /// Initialization
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PhoneForm_Load(object sender, EventArgs e)
      {
        // Initialize Contacts list...
        InitContacts();     
      }

      /// <summary>
      /// Update main menu according to active tab page
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
      {
        mainMenu.MenuItems.Clear();
        switch (tabControl.SelectedIndex)
        {
          case 0:
              BuildMainMenu();
            break;
          case 1:
              mainMenu.MenuItems.Add(menuItemCallMenu);
              mainMenu.MenuItems.Add(menuItemRelease);
            break;

        }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuItemMessage_Click(object sender, EventArgs e)
      {
        // get selected item text
        if (listViewContacts.SelectedIndices.Count > 0)
        {
          int index = listViewContacts.SelectedIndices[0];
          ListViewItem lvi = listViewContacts.Items[index];
          Contact ct = (Contact)lvi.Tag;
          if (ct.MobileTelephoneNumber.Length > 0)
          {
            string sipname = normalize(ct.MobileTelephoneNumber);
            (new ChatForm(sipname)).ShowDialog();
          }
        }
      }

      /// <summary>
      /// selected call -> active call
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void menuItemActivate_Click(object sender, EventArgs e)
      {
        // 
        if (listViewBackground.SelectedIndices.Count > 0)
        {
          int index = listViewBackground.SelectedIndices[0];
          // switch handles...
          IStateMachine sm = (IStateMachine)listViewBackground.Items[index].Tag;
          listViewBackground.Items[index].Tag = tabPagePhone.Tag; 
          tabPagePhone.Tag = sm;
          sync_StateChanged(sm.Session);
        }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void textBoxNumber_GotFocus(object sender, EventArgs e)
      {
        textBoxNumber.Text = "";
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void textBoxNumber_LostFocus(object sender, EventArgs e)
      {
        if (textBoxNumber.Text.Length == 0)
        {
          textBoxNumber.Text = "Enter a number...";
        }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void tabPageContacts_Paint(object sender, PaintEventArgs e)
      {
        BuildMainMenu();
      }

      #endregion

    }
}