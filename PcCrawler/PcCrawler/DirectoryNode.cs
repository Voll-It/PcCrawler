using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcCrawler
{
    /// <summary>
    /// Representing a Directory node on a directory tree.
    /// </summary>
    class DirectoryNode
    {
        public DirectoryInfo DirektoryInformations { get; private set; }
        public List<DirectoryNode> ChildNodes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DirInfo">representig the curent direktory</param>
        public DirectoryNode(DirectoryInfo DirInfo)
        {
            this.DirektoryInformations = DirInfo;
            this.ChildNodes = new List<DirectoryNode>();
        }

        public override string ToString()
        {
            return this.DirektoryInformations.Name;
        }
    }
}
