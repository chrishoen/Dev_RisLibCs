using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ris;
using ProtoComm;

namespace MainApp
{
    //**************************************************************************
    //**************************************************************************
    //**************************************************************************
    class MyCmdLineExec : BaseCmdLineExec
    {
        //**********************************************************************

        public MyCmdLineExec()
        {
            reset();
        }

        public override void reset()
        {
        }

        //**********************************************************************

        public override void execute(CmdLineCmd aCmd)
        {
            if (aCmd.isCmd("TX"))  ExecuteTx(aCmd);
            if (aCmd.isCmd("GO1")) ExecuteGo1(aCmd);
            if (aCmd.isCmd("GO2")) ExecuteGo2(aCmd);
            if (aCmd.isCmd("GO3")) ExecuteGo3(aCmd);
            if (aCmd.isCmd("GO4")) ExecuteGo4(aCmd);
            if (aCmd.isCmd("GO5")) ExecuteGo5(aCmd);
        }

        //**********************************************************************

        public void ExecuteTx (CmdLineCmd aCmd)
        {
            aCmd.setArgDefault(1,1);
            int tMsgType= aCmd.argInt(1);

            switch (tMsgType)
            {
                case 1:
                {
                    TestMsg tMsg = new TestMsg();
                    Helper.initialize(tMsg);
                    Global.mNetworkThread.sendMsg(tMsg);
                    break;
                }
                case 2:
                {
                    FirstMessageMsg tMsg = new FirstMessageMsg();
                    Helper.initialize(tMsg);
                    Global.mNetworkThread.sendMsg(tMsg);
                    break;
                }
                case 3:
                {
                    StatusRequestMsg tMsg = new StatusRequestMsg();
                    Helper.initialize(tMsg);
                    Global.mNetworkThread.sendMsg(tMsg);
                    break;
                }
                case 4:
                {
                    StatusResponseMsg tMsg = new StatusResponseMsg();
                    Helper.initialize(tMsg);
                    Global.mNetworkThread.sendMsg(tMsg);
                    break;
                }
                case 5:
                {
                    DataMsg tMsg = new DataMsg();
                    Helper.initialize(tMsg);
                    Global.mNetworkThread.sendMsg(tMsg);
                    break;
                }
            }
        }

        //**********************************************************************

        public void ExecuteGo1(CmdLineCmd aCmd)
        {
        }

        //**********************************************************************

        public void ExecuteGo2(CmdLineCmd aCmd)
        {
            aCmd.setArgDefault(1, "aaaaaaa");
            aCmd.setArgDefault(2, 111);
            aCmd.setArgDefault(3, 22.22);

            Console.WriteLine("{0} {1} {2}", aCmd.argString(1), aCmd.argInt(2), aCmd.argDouble(3));
        }

        //**********************************************************************

        public void ExecuteGo3(CmdLineCmd aCmd)
        {
            ByteBuffer tBuffer = new ByteBuffer(1000);
            TestMsg tTxMsg = new TestMsg();
            TestMsg tRxMsg = null;
            Helper.initialize(tTxMsg);

            MsgMonkey tMonkey = new MsgMonkey();

            tMonkey.putMsgToBuffer(tBuffer,tTxMsg);
            tBuffer.rewind();
            tRxMsg = (TestMsg)tMonkey.makeMsgFromBuffer(tBuffer);
            
            Helper.show(tRxMsg);
        }

        //**********************************************************************

        public void ExecuteGo4(CmdLineCmd aCmd)
        {
            ByteBuffer tBuffer = new ByteBuffer(1000);
            DataMsg tTxMsg = new DataMsg();
            DataMsg tRxMsg = null;
            Helper.initialize(tTxMsg);

            MsgMonkey tMonkey = new MsgMonkey();

            tMonkey.putMsgToBuffer(tBuffer,tTxMsg);
            tBuffer.rewind();
            tRxMsg = (DataMsg)tMonkey.makeMsgFromBuffer(tBuffer);
            
            Helper.show(tRxMsg);
        }


        //**********************************************************************

        public void ExecuteGo5(CmdLineCmd aCmd)
        {
            aCmd.setArgDefault(1, 0x10);

            UInt64 tN = aCmd.argUInt64(1);

            Console.WriteLine("0x{0,16:X}", tN);
            
        }


    }
}
