using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ELABO.Utils
{
    public class ThreadsManager
    {
        private Dictionary<string, Thread> mapThread = new Dictionary<string, Thread>();
        private static ThreadsManager instance;

        private ThreadsManager()
        {

        }

        public static ThreadsManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ThreadsManager();
            }
            return instance;
        }

        public Thread GenerateThread(string name, ThreadStart s)
        {
            if (mapThread.ContainsKey(name))
            {
                throw new System.Exception("This thread has allready exited.");
            }
            Thread tem = new Thread(s);
            tem.Priority = ThreadPriority.Highest;
            mapThread.Add(name, tem);
            return tem;
        }

        public void AddThread(string name, Thread t)
        {
            if (mapThread.ContainsKey(name))
            {
                throw new System.Exception("This thread has allready exited.");
            }
            mapThread.Add(name, t);
        }

        public Thread GetThread(string name)
        {
            if (mapThread.ContainsKey(name))
            {
                Thread tem;
                if (mapThread.TryGetValue(name, out tem))
                {
                    return tem;
                }
            }
            return null;
        }

        public Thread RemoveThread(string name)
        {
            if (mapThread.ContainsKey(name))
            {
                Thread tem;
                if (mapThread.TryGetValue(name, out tem))
                {
                    mapThread.Remove(name);
                    return tem;
                }
            }
            return null;
        }
        public int StopAll()
        {
            int t = 0;
            foreach (string i in mapThread.Keys)
            {
                t++;
                Thread tem;
                if (mapThread.TryGetValue(i, out tem))
                {
                    try
                    {
                        tem.Abort();

                        tem = null;
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            mapThread.Clear();
            return t;
        }
    }
}
