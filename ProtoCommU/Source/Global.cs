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

        public static void initialize(string[] args)
        {
            int tAppCode=1;
            if (args.Length == 1)
            {
                if (args[0].CompareTo("UdpPeer1")==0) tAppCode=1;
                if (args[0].CompareTo("UdpPeer2")==0) tAppCode=2;
            }
            Console.WriteLine("AppCode {0}",tAppCode);
                
            ProtoComm.MsgMonkeyCreator tMonkeyCreator = new ProtoComm.MsgMonkeyCreator();
            
            mNetworkThread = new ProtoComm.NetworkThread();
            if (tAppCode == 1)
            {
                mNetworkThread.configure(tMonkeyCreator, "127.0.0.1", 56002, "127.0.0.1", 56001);
            }
            else
            {
                mNetworkThread.configure(tMonkeyCreator, "127.0.0.1", 56001, "127.0.0.1", 56002);
            }
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
