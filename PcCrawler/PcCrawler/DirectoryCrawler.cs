using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
 * Date: 1.1.2015                                                                                   *
 * **************************************************************************************************
 */
namespace PcCrawler
{
    class DirectoryCrawler
    {
        public List<DriveInfo> drives;

        public List<DirectoryNode> DirektoryRootNodes { get; private set; }

        /// <summary>
        /// Creates an instance and saves all HDD´s.
        /// </summary>
        public DirectoryCrawler()
        {
            Tools.DebugTools.StartTimeWatch("DirectoryCrawler ctr");

            drives = new List<DriveInfo>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            for (int i = 0; i < allDrives.Length; i++)
            {
                DriveInfo curDriveInfo = allDrives[i];

                if (curDriveInfo.DriveType == DriveType.Fixed)
                    drives.Add(curDriveInfo);    
            }

            Tools.DebugTools.StopTimeWatch("DirectoryCrawler ctr");
        }

        public void Crawl()
        {
            DirektoryRootNodes = new List<DirectoryNode>();
            foreach (var drive in drives)
            {
                Tools.DebugTools.StartTimeWatch(drive.Name);
                DirectoryNode rootNode = new DirectoryNode(new DirectoryInfo(drive.Name));
                DirektoryRootNodes.Add(rootNode);
                direktoryWalker(rootNode);
                Tools.DebugTools.StopTimeWatch(drive.Name);

            }
        }
        
        /// <summary>
        /// Recoursiv helper funktion that moves each folder path to the end an
        /// add the DirektoryInfo to the second param.
        /// </summary>
        /// <param name="rootNode"></param>
        private void direktoryWalker(DirectoryNode rootNode)
        {
            DirectoryInfo[] tempdirInfos = rootNode.DirektoryInformation.GetDirectories();

            if (tempdirInfos.Length != 0)
            {
                foreach (DirectoryInfo dirInfo in tempdirInfos)
                {
                    try
                    {
                        DirectoryNode newNode = new DirectoryNode(dirInfo);
                        rootNode.ChildNodes.Add(newNode);
                        rootNode.IsReadable = true;

                        //Call the next node 
                        direktoryWalker(newNode);
                    }
                    catch (Exception e)
                    {
                        rootNode.IsReadable = false;
                        Debug.Print("Can´t read dirs in {0}", dirInfo.FullName);
                    }
                }
            }
        }
    }
}
