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
using System.Diagnostics;

namespace SipekMobile
{
  public partial class FormAbout : Form
  {

    public FormAbout()
    {
      InitializeComponent();
    }

    private void menuItem1_Click(object sender, EventArgs e)
    {
      Close();
    }

  }
}