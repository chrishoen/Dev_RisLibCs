using System;
using System.Text;

using Ris;

namespace ProtoComm
{
    //**************************************************************************
    //**************************************************************************
    //**************************************************************************

    public class NetworkThread : UdpMsgThread
    {
        //**********************************************************************
        //**********************************************************************
        //**********************************************************************
        // Receive message handlers

        public override void processRxMsg(ByteContent aRxMsg)
        {
            BaseMsg tRxMsg = (BaseMsg)aRxMsg;

            // Message jump table based on message type.
            // Calls corresponding specfic message handler method.
            switch (tRxMsg.mMessageType)
            {
                case MsgIdT.cTest :
                    processRxMsg((TestMsg)tRxMsg);
                    break;
                case MsgIdT.cStatusRequest :
                    processRxMsg((StatusRequestMsg)tRxMsg);
                    break;
                case MsgIdT.cStatusResponse:
                    processRxMsg((StatusResponseMsg)tRxMsg);
                    break;
                case MsgIdT.cData:
                    processRxMsg((DataMsg)tRxMsg);
                    break;
                default :
                    Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg UNKNOWN");
                    break;
            }
        }
        //******************************************************************************
        // Message handler - TestMsg.

        void processRxMsg(TestMsg aRxMsg)
        {
            Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg_TestMsg");
        }

        //******************************************************************************
        // Rx message handler - StatusRequestMsg

        void processRxMsg(StatusRequestMsg aRxMsg)
        {
            Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg_StatusRequestMsg");
            Prn.print(Prn.ThreadRun1, "Code1      {0}", aRxMsg.mCode1);
            Prn.print(Prn.ThreadRun1, "Code2      {0}", aRxMsg.mCode2);
            Prn.print(Prn.ThreadRun1, "Code3      {0}", aRxMsg.mCode3);
            Prn.print(Prn.ThreadRun1, "Code4      {0}", aRxMsg.mCode4);
        }

        //******************************************************************************
        // Rx message handler - StatusResponseMsg

        void processRxMsg(StatusResponseMsg aRxMsg)
        {
            Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg_StatusResponseMsg");
        }

        //******************************************************************************
        // Rx message handler - DataMsg

        void processRxMsg(DataMsg aRxMsg)
        {
            Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg_DataMsg");
            aRxMsg.show();
        }
    }
}
