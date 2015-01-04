using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace PcCrawler
{
    class FileCrawler
    {
        private DirectoryNode rootNode;

        public FileCrawler(DirectoryNode rootNode)
        {
            this.rootNode = rootNode;
        }

        public void Crawl()
        {
            Tools.DebugTools.StartTimeWatch("FileCrawlerStart");
            directoryWalker(rootNode);
            Tools.DebugTools.StopTimeWatch("FileCrawlerStart");
        }

        private void directoryWalker(DirectoryNode dirNode)
        {
            Tools.DebugTools.StartTimeWatch(dirNode.DirektoryInformation.FullName);
            using (SHA512 hashProvider = SHA512Managed.Create())
            {
                for (int i = 0; i < dirNode.ChildNodes.Count; i++)
                {                  
                    DirectoryNode node = dirNode.ChildNodes[i];
                    try
                    {
                        FileInfo[] files = node.DirektoryInformation.GetFiles();
                        for (int o = 0; o < files.Length; o++)
                        {
                            FileInfo currentFile = files[o];
                            using (Stream fileStream = new BufferedStream(currentFile.OpenRead(), 1048576))
                            {
                                Debug.Print("Current : {0}", currentFile.FullName);
                                byte[] hash = hashProvider.ComputeHash(fileStream);
                                string hashString = BitConverter.ToString(hash).Replace("-", String.Empty);
                                node.FileInformations.Add(
                                    new KeyValuePair<string, FileInfo>(hashString, currentFile)
                                    );
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        Debug.Print("Exception {0} on {1}", e.Message, node.DirektoryInformation.FullName);
                    }
                    directoryWalker(node);
                }
            }
            Tools.DebugTools.StopTimeWatch(dirNode.DirektoryInformation.FullName);
        }
    }
}
