using System;
using System.Text;
using System.IO;
using Ris;

/*==============================================================================
This file contains a set of classes that encapsulate the message set
that is used to communicate with Intranet. The messages are specified
in the IDD.

There is a class for each particular message in the set and there is a
base class that all of the messages inherit from.

These messages follow the ByteContent pattern, where they all inherit
from ByteContent so that they can be copied to/from ByteBuffers.

The base class is used to specify set membership, any inheriting class
is a member of the message set, and message objects can be referenced
anonymously via pointers to the the base class.

The base class provides a member function, makeFromByteBuffer, that
extracts particular messages from a byte buffer and returns a pointer
to the base class.

These messages all have the same common form, they all contain a
common message header. The base class has a Header member object that
encapsulates the header.
==============================================================================*/

namespace ProtoComm
{
    //******************************************************************************
    //******************************************************************************
    //******************************************************************************
    // Message Types

    public class MsgIdT
    {
        //--------------------------------------------------------------------------
        // Message type indentifier

        public const int cUnspecified    =  0;
        public const int cTest           =  1;
        public const int cFirstMessage   =  2;
        public const int cStatusRequest  =  3;
        public const int cStatusResponse =  4;
        public const int cData           =  5;

    };

    //******************************************************************************
    //******************************************************************************
    //******************************************************************************
    // Message Creator

    public class MsgCreator : Ris.BaseMsgCreator
    {
        //--------------------------------------------------------------------------
        // Create a new message based on a message type

        public override Ris.ByteContent createMsg(int aMessageType)
        {
            Ris.ByteContent tMsg = null;

            switch (aMessageType)
            {
                case MsgIdT.cTest :
                    tMsg = new TestMsg();
                    break;
                case MsgIdT.cFirstMessage :
                    tMsg = new FirstMessageMsg();
                    break;
                case MsgIdT.cStatusRequest :
                    tMsg = new StatusRequestMsg();
                    break;
                case MsgIdT.cStatusResponse:
                    tMsg = new StatusResponseMsg();
                    break;
                case MsgIdT.cData:
                    tMsg = new DataMsg();
                    break;
                default :
                    break;
            }
            return tMsg;
        }
    }

    //******************************************************************************
    //******************************************************************************
    //******************************************************************************
    // Particular message classes.
    // There is one class for each message in the message set.

    public class TestMsg : BaseMsg
    {
        //------------------------------------------------
        // Content

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        // Content
        //------------------------------------------------

        public TestMsg ()
        {
            mMessageType = MsgIdT.cTest;
            mCode1 = 901;
            mCode2 = 902;
            mCode3 = 903;
            mCode4 = 904;
        } 

        public override void copyToFrom (ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy( ref mCode1 );
            aBuffer.copy( ref mCode2 );
            aBuffer.copy( ref mCode3 );
            aBuffer.copy( ref mCode4 );

            mHeader.headerReCopyToFrom(aBuffer,this);
        }

        public void initialize()
        {
            mCode1 = 901;
            mCode2 = 902;
            mCode3 = 903;
            mCode4 = 904;
        }

        public void show()
        {
            Console.WriteLine ("{0}",mCode1);
            Console.WriteLine ("{0}",mCode2);
            Console.WriteLine ("{0}",mCode3);
            Console.WriteLine ("{0}",mCode4);
        }
    };

    //******************************************************************************
    //******************************************************************************
    //******************************************************************************

    public class FirstMessageMsg : BaseMsg
    {
        //------------------------------------------------
        // Content

        public int mCode1;

        // Content
        //------------------------------------------------

        public FirstMessageMsg()
        {
            mMessageType = MsgIdT.cFirstMessage;
            mCode1 = 0;
        }

        public override void copyToFrom (ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy( ref mCode1 );

            mHeader.headerReCopyToFrom(aBuffer,this);
        }
    };

    //******************************************************************************
    //******************************************************************************
    //******************************************************************************

    public class StatusRequestMsg : BaseMsg
    {
        //------------------------------------------------
        // Content

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        public const int cMaxWords = 10;
        public int       mNumOfWords;
        public int[]     mWords;

        // Content
        //------------------------------------------------

        public StatusRequestMsg ()
        {
            mMessageType = MsgIdT.cStatusRequest;

            mCode1 = 101;
            mCode2 = 102;
            mCode3 = 103;
            mCode4 = 104;

            mNumOfWords = cMaxWords;
            mWords = new int[cMaxWords];

            for (int i=0; i<cMaxWords; i++)
            {
                mWords[i] = 101 + i;
            }
        } 

        public override void copyToFrom (ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy ( ref mCode1 );
            aBuffer.copy ( ref mCode2 );
            aBuffer.copy ( ref mCode3 );
            aBuffer.copy ( ref mCode4 );

            aBuffer.copy ( ref mNumOfWords  );
            for (int i=0;i<mNumOfWords;i++)
            {
                aBuffer.copy (ref mWords[i] );
            }

            mHeader.headerReCopyToFrom(aBuffer,this);
        }
    };
    //******************************************************************************
    //******************************************************************************
    //******************************************************************************

    public class StatusResponseMsg : BaseMsg
    {
        //------------------------------------------------
        // Content

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        public const int cMaxWords = 10;
        public int       mNumOfWords;
        public int[]     mWords;

        // Content
        //------------------------------------------------

        public StatusResponseMsg ()
        {
            mMessageType = MsgIdT.cStatusResponse;

            mCode1 = 201;
            mCode2 = 202;
            mCode3 = 203;
            mCode4 = 204;

            mNumOfWords = cMaxWords;
            mWords = new int[cMaxWords];

            for (int i=0; i<cMaxWords; i++)
            {
                mWords[i] = 201 + i;
            }
        } 

        public override void copyToFrom (ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer,this);

            aBuffer.copy ( ref mCode1 );
            aBuffer.copy ( ref mCode2 );
            aBuffer.copy ( ref mCode3 );
            aBuffer.copy ( ref mCode4 );

            aBuffer.copy( ref mNumOfWords  );
            for (int i=0;i<mNumOfWords;i++)
            {
                aBuffer.copy (ref mWords[i] );
            }

            mHeader.headerReCopyToFrom(aBuffer,this);
        }
    };
    
    public class DataRecord : ByteContent
    {
        //------------------------------------------------
        // Content

        public int mCode1;
        public int mCode2;
        public int mCode3;
        public int mCode4;

        // Content
        //------------------------------------------------

        public DataRecord()
        {
            mCode1 = 0;
            mCode2 = 0;
            mCode3 = 0;
            mCode4 = 0;
        }

        public override void copyToFrom (ByteBuffer aBuffer)
        {
            aBuffer.copy(ref mCode1 );
            aBuffer.copy(ref mCode2 );
            aBuffer.copy(ref mCode3 );
            aBuffer.copy(ref mCode4 );
        }

        public void initialize()
        {
            mCode1 = 701;
            mCode2 = 702;
            mCode3 = 703;
            mCode4 = 704;
        }

        public void show()
        {
            Console.WriteLine("{0}", mCode1);
            Console.WriteLine("{0}", mCode2);
            Console.WriteLine("{0}", mCode3);
            Console.WriteLine("{0}", mCode4);
            Console.WriteLine("");
        }
    }
//******************************************************************************
    //******************************************************************************
    //******************************************************************************

    public class DataMsg : BaseMsg
    {
        //------------------------------------------------
        // Content

        public const int cMaxStringSize = 10;

        public byte          mUChar;
        public ushort        mUShort;
        public uint          mUInt;
        public ulong         mUInt64;
        public sbyte         mChar;
        public short         mShort;
        public int           mInt;
        public long          mInt64;
        public float         mFloat;
        public double        mDouble;
        public bool          mBool;
        public String        mString1;
        public String        mString2;
        public DataRecord    mDataRecord;

        // Content
        //------------------------------------------------

        public DataMsg()
        {
            mMessageType = MsgIdT.cData;

            mUChar  = 0;
            mUShort = 0;
            mUInt   = 0;
            mUInt64 = 0;
            mChar   = 0;
            mShort  = 0;
            mInt    = 0;
            mInt64  = 0;
            mFloat  = 0.0f;
            mDouble = 0.0;
            mBool   = false;
            mString1 = String.Empty;
            mString2 = String.Empty;
            mDataRecord = new DataRecord();
        }

        public override void copyToFrom (ByteBuffer aBuffer)
        {
            mHeader.headerCopyToFrom(aBuffer, this);

            aBuffer.copy ( ref mUChar  );
            aBuffer.copy ( ref mUShort );
            aBuffer.copy ( ref mUInt   );
            aBuffer.copy ( ref mUInt64 );
            aBuffer.copy ( ref mChar   );
            aBuffer.copy ( ref mShort  );
            aBuffer.copy ( ref mInt    );
            aBuffer.copy ( ref mInt64  );
            aBuffer.copy ( ref mFloat  );
            aBuffer.copy ( ref mDouble );
            aBuffer.copy ( ref mBool   );
            aBuffer.copy ( mDataRecord );
            aBuffer.copyS( ref mString1 );
            aBuffer.copyS( ref mString2 );

            mHeader.headerReCopyToFrom(aBuffer, this);
        }

        public void initialize()
        {
            mUChar  = 0x11;
            mUShort = 0x1234;
            mUInt   = 0x12345678;
            mUInt64 = 0x1112131415161718;
            mChar   = 0x11;
            mShort  = 0x1234;
            mInt    = 0x12345678;
            mInt64  = 0x1112131415161718;
            mFloat  = 12.34f;
            mDouble = 56.78;
            mBool   = true;
            mString1 = @"abcdef";
            mString2 = @"01234567";
            mDataRecord.initialize();
        }

        public void show()
        {
            Console.WriteLine("UChar    {0:X}",  mUChar   );
            Console.WriteLine("UShort   {0:X}",  mUShort  );
            Console.WriteLine("UInt     {0:X}",  mUInt    );
            Console.WriteLine("Unit64   {0:X}",  mUInt64  );
            Console.WriteLine("Char     {0:X}",  mChar    );
            Console.WriteLine("Short    {0:X}",  mShort   );
            Console.WriteLine("Int      {0:X}",  mInt     );
            Console.WriteLine("Int64    {0:X}",  mInt64   );
            Console.WriteLine("Float    {0}",    mFloat   );
            Console.WriteLine("Double   {0}",    mDouble  );
            Console.WriteLine("Bool     {0}",    mBool    );
            Console.WriteLine("String   {0}",    mString1 );
            Console.WriteLine("String   {0}",    mString2 );
            mDataRecord.show();
            Console.WriteLine("");
        }

    };
}
