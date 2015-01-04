using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    /// <summary>
    /// Representing a Directory node on a directory tree.
    /// </summary>
    class DirectoryNode
    {
        public DirectoryInfo DirektoryInformation { get; private set; }
        public List<DirectoryNode> ChildNodes { get; private set; }
        public List<KeyValuePair<string,FileInfo>> FileInformations { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DirInfo">representig the curent direktory</param>
        public DirectoryNode(DirectoryInfo DirInfo)
        {
            this.DirektoryInformation = DirInfo;
            this.ChildNodes = new List<DirectoryNode>();
            this.FileInformations = new List<KeyValuePair<string, FileInfo>>();
        }

        public override string ToString()
        {
            return this.DirektoryInformation.Name;
        }
    }
}
