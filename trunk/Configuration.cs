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
using System.Text;
using Sipek.Common;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Sipek.Common.CallControl;

namespace SipekMobile
{

  public class MobileFactory : AbstractFactory
  {
    PhoneForm _form; // reference to MainForm to provide timer context

    public MobileFactory(PhoneForm mf)
    {
      _form = mf;
    }

    public ITimer createTimer()
    {
      return new GUITimer(_form);
    }

    public IStateMachine createStateMachine()
    {
      // TODO: check max number of calls
      return new CStateMachine();
    }
  }

  internal class ConfigurationManager
  {
    string configFile = PhoneForm._appFolder + @"\config.xml";

    PhoneConfig _config = null;

    static ConfigurationManager _instance = null;

    internal static ConfigurationManager Instance
    {
      get {
        if (_instance == null)
          _instance = new ConfigurationManager();
        return _instance;
      }
    }

    internal PhoneConfig RawConfiguration
    {
      get {
        if (_config == null)
          Load();

        return _config;
      }
    }

    internal void Update(PhoneConfig config)
    {
      if (config != null)
        _config = config;
    }

    internal void Load()
    {
      XmlReader xr = XmlReader.Create(configFile);
      try
      {
        XmlSerializer s = new XmlSerializer(typeof(PhoneConfig));
        _config = (PhoneConfig)s.Deserialize(xr);
      }

      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      finally
      {
        xr.Close();
      }

    }

    internal void Save()
    {
      StreamWriter sw = new StreamWriter(configFile);
      try
      {
        XmlSerializer s = new XmlSerializer(typeof(PhoneConfig));
        s.Serialize(sw, _config);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      finally
      {
        sw.Close();
      }
    }

  }

  #region Serialized Structs

  public class PhoneConfig
  {
    [System.ComponentModel.DefaultValueAttribute("false")]
    public bool AAFlag;
    [System.ComponentModel.DefaultValueAttribute("false")]
    public bool CFBFlag;
    [System.ComponentModel.DefaultValueAttribute("")]
    public string CFBNumber;
    [System.ComponentModel.DefaultValueAttribute("false")]
    public bool CFNRFlag;
    [System.ComponentModel.DefaultValueAttribute("")]
    public string CFNRNumber;
    [System.ComponentModel.DefaultValueAttribute("false")]
    public bool CFUFlag;
    [System.ComponentModel.DefaultValueAttribute("")]
    public string CFUNumber;
    [System.ComponentModel.DefaultValueAttribute("false")]
    public bool DNDFlag;
    [System.ComponentModel.DefaultValueAttribute("0")]
    public int DefaultAccountIndex;
    [System.ComponentModel.DefaultValueAttribute("5060")]
    public int SIPPort;

    public string AccountName;

    public string DisplayName;

    [System.ComponentModel.DefaultValueAttribute("*")]
    public string DomainName;

    [System.ComponentModel.DefaultValueAttribute("")]
    public string HostName;

    [System.ComponentModel.DefaultValueAttribute("")]
    public string Id;

    public int Index;

    [System.ComponentModel.DefaultValueAttribute("")]
    public string Password;

    [System.ComponentModel.DefaultValueAttribute("")]
    public string ProxyAddress;

    public int RegState;

    public ETransportMode TransportMode;

    [System.ComponentModel.DefaultValueAttribute("")]
    public string UserName;

    [System.ComponentModel.DefaultValueAttribute(false)]
    public bool EnablePresence;
  }

  #endregion 

  #region RawConfiguration

  internal class PhoneConfigInterface : IConfiguratorInterface
  {
    List<IAccount> _accountlist = new List<IAccount>();

    internal PhoneConfigInterface()
    {
      _accountlist.Add(new AccountConfigInterface());
    }

    PhoneConfig Configuration
    {
      get {
        return ConfigurationManager.Instance.RawConfiguration;
      }
    }

    #region Application specific settings
    
    public bool EnablePresence
    {
      get { return Configuration.EnablePresence; }
      set { Configuration.EnablePresence = value; }
    }
    
    #endregion

    #region IConfiguratorInterface Members

    public bool AAFlag
    {
      get { return false; }
      set { ; }
    }

    public bool CFBFlag
    {
      get { return false; }
      set { ; }
    }

    public string CFBNumber
    {
      get { return ""; }
      set { ; }
    }

    public bool CFNRFlag
    {
      get { return false; }
      set { ; }
    }

    public string CFNRNumber
    {
      get { return ""; }
      set { ; }
    }

    public bool CFUFlag
    {
      get { return false; }
      set { ; }
    }

    public string CFUNumber
    {
      get { return ""; }
      set { ; }
    }

    public List<string> CodecList
    {
      get {
        List<string> cl = new List<string>();
        cl.Add("PCMU");
        return cl;
      }
      set { ; }
    }

    public bool DNDFlag
    {
      get { return false; }
      set { ; }
    }

    public int DefaultAccountIndex
    {
      get { return 0; }
    }

    public bool IsNull
    {
      get { return false; }
    }

    public bool PublishEnabled
    {
      get { return false; }
      set { ; }
    }

    public int SIPPort
    {
      get { return Configuration.SIPPort; }
      set { Configuration.SIPPort = value; }
    }

    public List<IAccount> Accounts
    {
      get {

        return _accountlist;
      }
      set {

      }
    }


    public void Save()
    {
      ConfigurationManager.Instance.Save();
    }

    #endregion
  }

  /// <summary>
  /// 
  /// </summary>
  class AccountConfigInterface : IAccount
  {
    PhoneConfig Configuration
    {
      get
      {
        return ConfigurationManager.Instance.RawConfiguration;
      }
    }

    #region IAccount Members

    public string AccountName
    {
      get { return ""; }
      set { }
    }

    public string DisplayName
    {
      get { return "Sipek Mobile"; }
      set { }
    }

    public string DomainName
    {
      get { return Configuration.DomainName; }
      set { Configuration.DomainName = value; }
    }

    public string HostName
    {
      get { return Configuration.HostName; }
      set { Configuration.HostName = value; }
    }

    public string Id
    {
      get { return Configuration.Id; }
      set { Configuration.Id = value; }
    }

    public int Index
    {
      get { return 0; }
      set { }
    }

    public string Password
    {
      get { return Configuration.Password; }
      set { Configuration.Password = value; }
    }

    public string ProxyAddress
    {
      get { return Configuration.ProxyAddress; }
      set { Configuration.ProxyAddress = value; }
    }

    public int RegState
    {
      get { return 0; }
      set { }
    }

    public ETransportMode TransportMode
    {
      get { return Configuration.TransportMode; }
      set { Configuration.TransportMode = value; }
    }

    public string UserName
    {
      get { return Configuration.UserName; }
      set { Configuration.UserName = value; }
    }

    #endregion
  }
  
  #endregion


  #region Timer Implementation

  public class GUITimer : ITimer
  {
    delegate void DStart();

    Timer _guiTimer;
    PhoneForm _form;


    public GUITimer(PhoneForm mf)
    {
      _form = mf;
      _guiTimer = new Timer();
      //_guiTimer.Enabled = true;
      _guiTimer.Tick += new EventHandler(_guiTimer_Tick);
    }

    void _guiTimer_Tick(object sender, EventArgs e)
    {
      _guiTimer.Enabled = false;
      _elapsed(sender, e);
      // Synchronize thread with GUI because SIP stack works with GUI thread only
      _form.Invoke(_elapsed, new object[] { sender, e });
    }

    public bool Start()
    {
      // synch
      _form.Invoke(new DStart(Start_Sync));
      
      return true;
    }

    private void Start_Sync()
    {
      _guiTimer.Enabled = true;
    }

    public bool Stop()
    {
      _guiTimer.Enabled = false;
      return true;
    }

    private int _interval;
    public int Interval
    {
      get { return _interval; }
      set { _interval = value; _guiTimer.Interval = value; }
    }

    private TimerExpiredCallback _elapsed;
    public TimerExpiredCallback Elapsed
    {
      set
      {
        _elapsed = value;
      }
    }
  }
  #endregion

  #region Tone Player
  //////////////////////////////////////////////////////
  // Media proxy
  // internal class
  public class CMediaPlayerProxy : IMediaProxyInterface
  {
    [DllImport("CoreDll.dll", EntryPoint = "PlaySound", SetLastError = true)]
    private extern static int PlaySound(string szSound, IntPtr hMod, int flags);

    private static string soundLocation = PhoneForm._appFolder + "\\Sounds\\";

    private enum SND
    {
      SYNC          = 0x0000,
      ASYNC         = 0x0001,
      NODEFAULT     = 0x0002,
      MEMORY        = 0x0004,
      LOOP          = 0x0008,
      NOSTOP        = 0x0010,
      PURGE         = 0x0040,     // purge non-static events
      NOWAIT        = 0x00002000,
      ALIAS         = 0x00010000,
      ALIAS_ID      = 0x00110000,
      FILENAME      = 0x00020000,
      RESOURCE      = 0x00040004
    }

    //SoundPlayer player = new SoundPlayer();

    #region Methods

    public int playTone(ETones toneId)
    {
      string fname;

      switch (toneId)
      {
        case ETones.EToneDial:
          fname = PhoneForm._appFolder + @"\Sounds\dial.wav";
          break;
        case ETones.EToneCongestion:
          fname = PhoneForm._appFolder + @"\Sounds\congestion.wav";
          break;
        case ETones.EToneRingback:
          fname = PhoneForm._appFolder + @"\Sounds\ringback.wav";
          break;
        case ETones.EToneRing:
          fname = PhoneForm._appFolder + @"\Sounds\ring.wav";
          break;
        default:
          fname = "";
          break;
      }

      PlaySound(fname, IntPtr.Zero, (int)(SND.ASYNC | SND.FILENAME | SND.LOOP));

      return 1;
    }

    public int stopTone()
    {
      PlaySound(null, IntPtr.Zero, (int)SND.PURGE);
      return 1;
    }

    #endregion

  }
  #endregion


}
