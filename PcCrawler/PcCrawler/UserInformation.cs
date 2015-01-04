using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/****************************************************************************************************
 * Crawls datas from a Windows system, an save, to compare them.                                    *
 * Copyright (C) 2015  Emanuel Vollmer                                                              *
 * This program is free software;                                                                   *
 * you can redistribute it and/or modify it under the terms of the GNU                              *
 * General Public License as published by the Free Software Foundation;                             *
 * either version 3 of the License, or (at your option) any later version.                          *
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;        *
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.        *
 * See the GNU General Public License for more details.                                             *
 * You should have received a copy of the GNU General Public License along with this program;       *
 * if not, see <http://www.gnu.org/licenses/>.                                                      *
 *                                                                                                  *
 * Author: Emanuel Vollmer                                                                          *
 * Date: 4.1.2015                                                                                   *
 * **************************************************************************************************
 */

namespace PcCrawler
{
    public partial class UserInformation : Form
    {
        public UserInformation(string text)
        {   
            InitializeComponent();
            this.Text = text; 
        }

        private void UserInformation_Paint(object sender, PaintEventArgs e)
        {            
            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, 0, 0);
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {   
            this.Size = this.CreateGraphics().MeasureString(this.Text,this.Font).ToSize();
            this.CenterToParent();
            this.Invalidate();
        }
    }
}
