using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
        /// <param name="rootPath"></param>
        /// <param name="dirInfos"></param>
        private void direktoryWalker(DirectoryNode rootPath)
        {
            DirectoryInfo[] tempdirInfos = rootPath.DirektoryInformations.GetDirectories();

            if (tempdirInfos.Length != 0)
            {
                foreach (DirectoryInfo dirInfo in tempdirInfos)
                {
                    try
                    {
                        DirectoryNode newNode = new DirectoryNode(dirInfo);
                        rootPath.ChildNodes.Add(newNode);
                        direktoryWalker(newNode);
                    }
                    catch (Exception e)
                    {
                        Debug.Print("Can´t read dirs in {0}", dirInfo.FullName);
                    }
                }
            }
        }
    }
}
