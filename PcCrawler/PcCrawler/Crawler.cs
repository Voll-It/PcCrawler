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
    public partial class Crawler : Form
    {
        private bool strgPresed = false;

        public Crawler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void bt_test_Click(object sender, EventArgs e)
        {
            using (Form waitingForm = new UserInformation("Reading Filesystem"))
            {
                waitingForm.Show(this);
                waitingForm.Refresh();
                this.Enabled = false;

                DirectoryCrawler dCrawler = new DirectoryCrawler();
                dCrawler.Crawl();
                FileCrawler fCrawler = new FileCrawler(dCrawler.DirektoryRootNodes.ElementAt(0));
                //fCrawler.Crawl();

                foreach (var directoryRootNode in dCrawler.DirektoryRootNodes)
                {
                    TreeFiller(directoryRootNode, tv_test);
                }

                waitingForm.Hide();
                this.Enabled = true;
            }
        }

        private void tv_test_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            object nodeData = e.Node.Tag;
            if(nodeData is DirectoryNode)
            {
                DirectoryNode dNode = nodeData as DirectoryNode;
                lvFiles.Items.Clear();
                lb_name.Text = dNode.DirektoryInformation.Name;
                lb_fullpath.Text = dNode.DirektoryInformation.FullName;

                
                long fileSize = 0;

                try
                {
                    foreach (var file in dNode.DirektoryInformation.GetFiles())
                    {
                        fileSize += file.Length;
                    }
                }
                catch (Exception){}

                lb_size.Text = fileSize / 8.0 + " Kbytes";

                foreach (var item in dNode.FileInformations)
                {
                    ListViewItem lvItem = lvFiles.Items.Add(item.Value.Name);
                    lvItem.SubItems.Add(item.Key);
                }
            }
        }
    }
}
