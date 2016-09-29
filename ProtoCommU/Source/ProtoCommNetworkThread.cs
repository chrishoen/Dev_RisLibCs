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

        public override void processRxMsg(ByteContent aMsg)
        {
            BaseMsg tRxMsg = (BaseMsg)aMsg;

            // Message jump table based on message type.
            // Calls corresponding specfic message handler method.
            switch (tRxMsg.mMessageType)
            {
                case MsgIdT.cTestMsg :
                    processRxMsg((TestMsg)tRxMsg);
                    break;
                case MsgIdT.cStatusRequestMsg :
                    processRxMsg((StatusRequestMsg)tRxMsg);
                    break;
                case MsgIdT.cStatusResponseMsg:
                    processRxMsg((StatusResponseMsg)tRxMsg);
                    break;
                case MsgIdT.cDataMsg:
                    processRxMsg((DataMsg)tRxMsg);
                    break;
                default :
                    Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg UNKNOWN");
                    break;
            }
        }
        //******************************************************************************
        // Message handler - TestMsg.

        void processRxMsg(TestMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg_TestMsg");
            Helper.show(aMsg);
        }

        //******************************************************************************
        // Rx message handler - StatusRequestMsg

        void processRxMsg(StatusRequestMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg_StatusRequestMsg");
            Helper.show(aMsg);
        }

        //******************************************************************************
        // Rx message handler - StatusResponseMsg

        void processRxMsg(StatusResponseMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg_StatusResponseMsg");
            Helper.show(aMsg);
        }

        //******************************************************************************
        // Rx message handler - DataMsg

        void processRxMsg(DataMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "NetworkThread.processRxMsg_DataMsg");
            Helper.show(aMsg);
        }
    }
}
