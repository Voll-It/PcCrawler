using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
