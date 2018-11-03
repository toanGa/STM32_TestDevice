using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELABO.Communication
{
    public class ByteBuffer
    {
        private ConcurrentQueue<byte> byteQueue = new ConcurrentQueue<byte>();

        public ByteBuffer()
        {

        }

        public void PutByte(byte b)
        {
            byteQueue.Enqueue(b);
        }

        public void PutByte(byte[] b)
        {
            int count = 0;
            if (b != null)
            {
                while (count < b.Length)
                {

                    byteQueue.Enqueue(b[count++]);
                }
            }
        }

        public void PutByte(byte[] b, int from, int length)
        {
            int count = 0;
            if (b != null)
            {
                while (count < length)
                {

                    byteQueue.Enqueue(b[count+from]);

                    count++;
                }
            }
        }

        public int Find(byte b)
        {
            int idx = -1;
            for (int i = 0; i < byteQueue.Count; i++)
            {
                if (byteQueue.ElementAt(i) == b)
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }

        public int Find(string str, int FromPos = 0)
        {
            if(str == string.Empty)
            {
                return this.byteQueue.Count - 1;
            }

            if (FromPos > byteQueue.Count - 1)
                return -1;

            int idx = -1;
            for (int i = FromPos; i < byteQueue.Count; i++)
            {
                if (byteQueue.ElementAt(i) == (byte)str[0])
                {
                    bool check = false;
                    for(int j = 1; j< str.Length; j++)
                    {
                        if (i + j >= byteQueue.Count || byteQueue.ElementAt(i + j) != (byte)str[j])
                        {
                            check = true;
                            break;
                        }
                    }

                    if (!check)
                    {
                        idx = i + FromPos;
                        break;
                    }
                }
            }

            return idx;
        }

        public byte GetFirstByte()
        {
            byte first;
            if (byteQueue.TryPeek(out first))
            {
                return first;
            }
            else
            {
                throw new System.Exception("Cannot GetFirstByte in queue");
            }
        }

        public byte RetriveByte()
        {
            byte first;
            if (byteQueue.TryDequeue(out first))
            {
                return first;
            }
            else
            {
                throw new System.Exception("Cannot RetriveByte in queue");
            }
        }

        public byte[] RetriveBytes(int length)
        {
            try
            {
                byte[] bts = new byte[length];
                byte temp;
                int i = 0;
                while (i < length)
                {
                    if (byteQueue.TryDequeue(out temp))
                    {
                        bts[i++] = temp;
                    }
                }
                return bts;
            }
            catch /*(System.Exception ex)*/
            {
                return null;
            }
        }

        public byte[] GetNBytes(int length)
        {
            try
            {
                byte[] bts = new byte[length];
                int i = 0;
                while (i < length)
                {
                    bts[i] = byteQueue.ElementAt(i);
                    i++;
                }
                return bts;
            }
            catch /*(System.Exception ex)*/
            {
                return null;
            }
        }

        public int GetLength()
        {
            return byteQueue.Count;
        }
    }
}
