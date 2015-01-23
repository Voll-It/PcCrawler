using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

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


        private void directoryWalker(DirectoryNode dirNode,bool hashing = true,bool fastHashing = false)
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

                                string hashString = string.Empty;
                                if (hashing)
                                {
                                    hashString = calculateHash(hashProvider, fileStream, fastHashing);
                                }

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

        private string calculateHash(SHA512 hashProvider, Stream fileStream, bool fastHashing)
        {
            ///TODO : implement fast hashing 
            byte[] hash = hashProvider.ComputeHash(fileStream);
            return BitConverter.ToString(hash).Replace("-", String.Empty);
        }
    }
}
