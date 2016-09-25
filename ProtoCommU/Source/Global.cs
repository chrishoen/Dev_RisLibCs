using System;
using System.Text;

namespace ProtoComm
{
    //******************************************************************************
    //******************************************************************************
    //******************************************************************************
    // ProtoComm global object

    public class Global
    {
        //******************************************************************************
        // Global objects

        public static ProtoComm.NetworkThread  mNetworkThread;

        //******************************************************************************
        // Initialize

        public static void initialize()
        {
            ProtoComm.MsgMonkeyCreator tMonkeyCreator = new ProtoComm.MsgMonkeyCreator();
            
            mNetworkThread = new ProtoComm.NetworkThread();
            mNetworkThread.configure(tMonkeyCreator,"127.0.0.1", 56002, "127.0.0.1", 56001);
            mNetworkThread.start();
        }

        //******************************************************************************
        // Initialize

        public static void finalize()
        {
            mNetworkThread.stop();
        }
    };
}
