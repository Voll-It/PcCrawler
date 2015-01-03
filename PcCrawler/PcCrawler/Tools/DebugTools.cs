using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
namespace PcCrawler.Tools
{
    class DebugTools
    {
        static DebugTools instance;
        static object instanceLock = new object();
        static object timeWatchLock = new object();

        ConcurrentDictionary<object, Stopwatch> timeWatchers;
        private DebugTools()
        {
            timeWatchers = new ConcurrentDictionary<object, Stopwatch>();
        }


        private static DebugTools getInstanze()
        {
            lock (instanceLock)
            {
                if (instance == null)
                    instance = new DebugTools();
            }

            return instance;
        }


        public static void StartTimeWatch(string ID)
        {
#if DEBUG
            DebugTools instance = getInstanze();

            if (!instance.timeWatchers.ContainsKey(ID))
            {
                lock (timeWatchLock)
                {
                    Stopwatch sw = new Stopwatch();
                    instance.timeWatchers.TryAdd(ID, sw);
                    Debug.WriteLine("Timer started " + ID);
                    sw.Start();
                }
            }
            else
            {
                Debug.Print("{0} ID collision : {1}", instance.GetType(), ID);
            }
#endif
        }

        public static void StopTimeWatch(string ID)
        {
#if DEBUG
            DebugTools instance = getInstanze();

            if (instance.timeWatchers.ContainsKey(ID))
            {
                lock (timeWatchLock)
                {
                    Stopwatch sw = null;
                    if(instance.timeWatchers.TryGetValue(ID,out sw))
                    {
                        sw.Stop();
                        Debug.Print("{0} takes {1} ms", ID, sw.ElapsedTicks / 1000f);
                    }
                    else
                    {
                        Debug.Print("{0} Error {1} not found.");
                    }
                }
            }
            else
            {
                Debug.Print("{0} invalid ID : {1}", instance.GetType(), ID);
            }
#endif
        }
    }
}
