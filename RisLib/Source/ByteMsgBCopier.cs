using System;
using System.Text;
using System.IO;

namespace Ris
{ 

    //******************************************************************************
    //******************************************************************************
    //******************************************************************************

    public abstract class BaseMsgBCopier
    { 
        //***********************************************************************
        // This creates a new record, based on a record type

        public abstract ByteMsgB createMessage (int aMessageType);

        //***********************************************************************
        // This copies byte buffers to/from records

        public abstract void copyToFrom( ByteBuffer aBuffer, ByteMsgB aMsg);
    };

}
