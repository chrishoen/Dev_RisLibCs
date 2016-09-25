using System;
using System.Text;
using System.IO;

namespace ProtoComm
{

    //***************************************************************************
    //***************************************************************************
    //***************************************************************************
    // Message Types

    public class MsgIdT
    {
        public const int cUnspecified       = 0;
        public const int cTestMsg           = 1;
        public const int cFirstMessageMsg   = 2;
        public const int cStatusRequestMsg  = 3;
        public const int cStatusResponseMsg = 4;
        public const int cDataMsg           = 5;
    };

    //***************************************************************************
    //***************************************************************************
    //***************************************************************************
    // Message Creator

    public class MsgCreator : Ris.BaseMsgCreator
    {
        //***********************************************************************
        // Create a new message, based on a message type.

        public override Ris.ByteContent createMsg (int aMessageType)
        {
            Ris.ByteContent tMsg = null;

            switch(aMessageType)
            {
                case MsgIdT.cTestMsg :
                    tMsg = new TestMsg();
                    break;
                case MsgIdT.cFirstMessageMsg :
                    tMsg = new FirstMessageMsg();
                    break;
                case MsgIdT.cStatusRequestMsg :
                    tMsg = new StatusRequestMsg();
                    break;
                case MsgIdT.cStatusResponseMsg :
                    tMsg = new StatusResponseMsg();
                    break;
                case MsgIdT.cDataMsg :
                    tMsg = new DataMsg();
                    break;
            }
            return tMsg;
        }
    };

    //***************************************************************************
    //***************************************************************************
    //***************************************************************************

    public class TestMsg : BaseMsg
    {
        //***********************************************************************
        // Members

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        //***********************************************************************
        // Constructor

        public TestMsg()
        {
            mMessageType = MsgIdT.cTestMsg;

            mCode1 = 1001;
            mCode2 = 0;
            mCode3 = 0;
            mCode4 = 0;
        }

        //***********************************************************************
        // Copy

        public override void copyToFrom (Ris.ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy ( ref mCode1 );
            aBuffer.copy ( ref mCode2 );
            aBuffer.copy ( ref mCode3 );
            aBuffer.copy ( ref mCode4 );

            mHeader.headerReCopyToFrom(aBuffer,this);
        }
    };

    //***************************************************************************
    //***************************************************************************
    //***************************************************************************

    public class FirstMessageMsg : BaseMsg
    {
        //***********************************************************************
        // Members

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        //***********************************************************************
        // Constructor

        public FirstMessageMsg()
        {
            mMessageType = MsgIdT.cFirstMessageMsg;

            mCode1 = 1001;
            mCode2 = 0;
            mCode3 = 0;
            mCode4 = 0;
        }

        //***********************************************************************
        // Copy

        public override void copyToFrom (Ris.ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy ( ref mCode1 );
            aBuffer.copy ( ref mCode2 );
            aBuffer.copy ( ref mCode3 );
            aBuffer.copy ( ref mCode4 );

            mHeader.headerReCopyToFrom(aBuffer,this);
        }
    };

    //***************************************************************************
    //***************************************************************************
    //***************************************************************************

    public class StatusRequestMsg : BaseMsg
    {
        //***********************************************************************
        // Members

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        //***********************************************************************
        // Constructor

        public StatusRequestMsg()
        {
            mMessageType = MsgIdT.cStatusRequestMsg;

            mCode1 = 1001;
            mCode2 = 0;
            mCode3 = 0;
            mCode4 = 0;
        }

        //***********************************************************************
        // Copy

        public override void copyToFrom (Ris.ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy ( ref mCode1 );
            aBuffer.copy ( ref mCode2 );
            aBuffer.copy ( ref mCode3 );
            aBuffer.copy ( ref mCode4 );

            mHeader.headerReCopyToFrom(aBuffer,this);
        }
    };

    //***************************************************************************
    //***************************************************************************
    //***************************************************************************

    public class StatusResponseMsg : BaseMsg
    {
        //***********************************************************************
        // Members

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        //***********************************************************************
        // Constructor

        public StatusResponseMsg()
        {
            mMessageType = MsgIdT.cStatusResponseMsg;

            mCode1 = 1001;
            mCode2 = 0;
            mCode3 = 0;
            mCode4 = 0;
        }

        //***********************************************************************
        // Copy

        public override void copyToFrom (Ris.ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy ( ref mCode1 );
            aBuffer.copy ( ref mCode2 );
            aBuffer.copy ( ref mCode3 );
            aBuffer.copy ( ref mCode4 );

            mHeader.headerReCopyToFrom(aBuffer,this);
        }
    };
    //***************************************************************************
    //***************************************************************************
    //***************************************************************************

    public class DataMsg : BaseMsg
    {
        //***********************************************************************
        // Members

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        //***********************************************************************
        // Constructor

        public DataMsg()
        {
            mMessageType = MsgIdT.cDataMsg;

            mCode1 = 1001;
            mCode2 = 0;
            mCode3 = 0;
            mCode4 = 0;
        }

        //***********************************************************************
        // Copy

        public override void copyToFrom (Ris.ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy ( ref mCode1 );
            aBuffer.copy ( ref mCode2 );
            aBuffer.copy ( ref mCode3 );
            aBuffer.copy ( ref mCode4 );

            mHeader.headerReCopyToFrom(aBuffer,this);
        }
    };
}
