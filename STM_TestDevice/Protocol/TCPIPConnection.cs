using ELABO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ELABO.Communication
{
    public class TCPIPConnection : iL1Communication
    {
        private L1DataReceived TCPIPDataReceivedEvent;

        private ThreadsManager ThMan = ThreadsManager.GetInstance();

        private Thread ThreadCom;

        private Socket clientSocket;

        // common param
        private CommConfig config; //store all config initialize for this connection
        private ByteBuffer bytesReceived = new ByteBuffer(); // store byte received from COM PORT
        //private ManualResetEvent ComRecvBytes = new ManualResetEvent(false);
        private byte[] lastSendBytes;

        public L1DataReceived L1DataReceivedEvent
        {
            get{ return TCPIPDataReceivedEvent; }
            set{ TCPIPDataReceivedEvent = value;}
        }

        public TCPIPConnection (CommConfig config)
        {
            this.config = config;

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        public void Open()
        {
            try
            {
                if(clientSocket.Connected)
                {
                    Close();
                }

	            clientSocket.Connect(new IPEndPoint(IPAddress.Parse(config.IPAddress), config.IPPort));
	            ThreadCom = new Thread(new ThreadStart(NotifyReceiveMessage));
	            ThreadCom.Name = "Communications - Receive message";
	
	            ThMan.AddThread(ThreadCom.Name, ThreadCom);
	
	            ThreadCom.Start();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void NotifyReceiveMessage()
        {
            while (this.clientSocket.Connected)
            {
                byte[] buffer = new byte[256];

                //bytesReceived
                int len = clientSocket.Receive(buffer);

                // Put to bytesReceived
                bytesReceived.PutByte(buffer, 0, len);

                if (bytesReceived.GetLength() > 0 && L1DataReceivedEvent != null)
                {
                    L1DataReceivedEvent(bytesReceived);
                }
            }
            Close();
        }

        public void Close()
        {
            try
            {
                ThreadCom.Abort();
                ThMan.RemoveThread(ThreadCom.Name);
                ThreadCom = null;

	            this.clientSocket.Shutdown(SocketShutdown.Both);
	            this.clientSocket.Close();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool IsConnected()
        {
            return clientSocket.Connected;
        }

        public void Send(string data)
        {
            try
            {
	            clientSocket.Send(Util.StrToByteArray(data));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Send(byte[] data)
        {
            try
            {
                clientSocket.Send(data);

                lastSendBytes = data;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void CleanRxBuffer()
        {
            bytesReceived.RetriveBytes(bytesReceived.GetLength());
        }
    }
}
