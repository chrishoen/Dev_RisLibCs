using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Ris
{
    //**************************************************************************
    //**************************************************************************
    //**************************************************************************

    public abstract class UdpMsgBThread
    {
        //**********************************************************************
        // Inheriting classes override this method to process received messages

        public abstract void processRxMessage (ByteMsgB aMsg);

        //**********************************************************************
        // Members

        public Thread               mThread;
        public UdpRxTMessageSocket  mRxSocket;
        public UdpTxTMessageSocket  mTxSocket;
        public int                  mRxCount;

        //**********************************************************************
        // Constructor

        public UdpMsgBThread()
        {
        }

        public void configure(
            String aRxAddress, 
            int aRxPort, 
            String aTxAddress, 
            int aTxPort, 
            BaseMsgBCopier aMsgCopier)
        {
            // Rx socket
            mRxSocket = new UdpRxTMessageSocket();
            mRxSocket.configure(aRxAddress,aRxPort,aMsgCopier);

            // Tx socket
            mTxSocket = new UdpTxTMessageSocket();
            mTxSocket.configure(aTxAddress,aTxPort,aMsgCopier);
        }

        //**********************************************************************
        // Launch thread

        public void start()
        {
            // Create new thread object using thread run function
            mThread = new Thread(new ThreadStart(threadRun));
            // Start the thread
            mThread.Start();
        }

        //**********************************************************************
        // Shutdown thread

        public void stop()
        {
            if (mRxSocket != null)
            {
                mRxSocket.close();
            }
        }

        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Thread run function, receives messages

        public void threadRun()
        {
            while (true)
            {
                //--------------------------------------------------------------
                // Receive from the message socket

                ByteMsgB tMsg = mRxSocket.receiveMessage();

                //--------------------------------------------------------------
                // Call inheritor's override to process the message

                if (tMsg != null)
                {
                    processRxMessage(tMsg);
                }
                else
                {
                    return;
                }
            }
        }

        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Transmit message

        public void sendMessage(ByteMsgB aMsg)
        {
            mTxSocket.sendMessage(aMsg);
        }
    }
}
