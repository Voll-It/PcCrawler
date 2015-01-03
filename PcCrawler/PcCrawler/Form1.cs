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
 * Date: 1.1.2015                                                                                   *
 * **************************************************************************************************
 */
namespace PcCrawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryCrawler dCrawler = new DirectoryCrawler();
            dCrawler.Crawl();
            foreach (var directoryRootNode in dCrawler.DirektoryRootNodes)
            {
                TreeFiller(directoryRootNode, tv_test);
            }
            
        }

        /// <summary>
        /// Fills the tree viewer with the Folder datas.
        /// </summary>
        /// <param name="dirNode"></param>
        /// <param name="tv"></param>
        /// <param name="currentNode"></param>
        private void TreeFiller(DirectoryNode dirNode, TreeView tv, TreeNode currentNode = null)
        {
            if (currentNode == null)
                currentNode = tv.Nodes.Add(dirNode.ToString());
            else
                currentNode = currentNode.Nodes.Add(dirNode.ToString());

            currentNode.Tag = dirNode;

            foreach (DirectoryNode node in dirNode.ChildNodes)
            {
                TreeFiller(node, tv, currentNode);
            }
        }
    }
}
