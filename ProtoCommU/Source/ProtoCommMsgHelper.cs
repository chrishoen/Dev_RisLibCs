using System;
using System.Text;
using Ris;

namespace ProtoComm
{
    //**************************************************************************
    //**************************************************************************
    //**************************************************************************

    public class Helper
    {
        //******************************************************************************
        //******************************************************************************
        //******************************************************************************
        // TestMsg.

        public static void initialize(TestMsg aMsg)
        {
            aMsg.mCode1 = 1101;
            aMsg.mCode2 = 1102;
            aMsg.mCode3 = 1103;
            aMsg.mCode4 = 1104;
        }

        public static void show(TestMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "ProtoComm.TestMsg");
            Prn.print(Prn.ThreadRun1, "Code1      {0}", aMsg.mCode1);
            Prn.print(Prn.ThreadRun1, "Code2      {0}", aMsg.mCode2);
            Prn.print(Prn.ThreadRun1, "Code3      {0}", aMsg.mCode3);
            Prn.print(Prn.ThreadRun1, "Code4      {0}", aMsg.mCode4);
        }

        //******************************************************************************
        //******************************************************************************
        //******************************************************************************
        // FirstMessageMsg.
        
        public static void initialize(FirstMessageMsg aMsg)
        {
            aMsg.mCode1 = 1101;
        }

        public static void show(FirstMessageMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "ProtoComm.FirstMessageMsg");
            Prn.print(Prn.ThreadRun1, "Code1      {0}", aMsg.mCode1);
        }

        //******************************************************************************
        //******************************************************************************
        //******************************************************************************
        // StatusRequestMsg

        public static void initialize(StatusRequestMsg aMsg)
        {
            aMsg.mCode1 = 1201;
            aMsg.mCode2 = 1202;
            aMsg.mCode3 = 1203;
            aMsg.mCode4 = 1204;

            aMsg.mNumOfWords = 4;

            for (int i = 0; i < aMsg.mNumOfWords; i++)
            {
                aMsg.mWords[i] = 101 + i;
            }
        }

        public static void show(StatusRequestMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "ProtoCommMsg.StatusMsg");
            Prn.print(Prn.ThreadRun1, "Code1      {0}", aMsg.mCode1);
            Prn.print(Prn.ThreadRun1, "Code2      {0}", aMsg.mCode2);
            Prn.print(Prn.ThreadRun1, "Code3      {0}", aMsg.mCode3);
            Prn.print(Prn.ThreadRun1, "Code4      {0}", aMsg.mCode4);

            for (int i = 0; i < aMsg.mNumOfWords; i++)
            {
                Prn.print(Prn.ThreadRun1, "Words     {0} {1}", 1, aMsg.mWords[i]);
                aMsg.mWords[i] = 101 + i;
            }
        }

        //******************************************************************************
        //******************************************************************************
        //******************************************************************************
        // StatusResponseMsg

        public static void initialize(StatusResponseMsg aMsg)
        {
            aMsg.mCode1 = 1201;
            aMsg.mCode2 = 1202;
            aMsg.mCode3 = 1203;
            aMsg.mCode4 = 1204;

            aMsg.mNumOfWords = 4;

            for (int i = 0; i < aMsg.mNumOfWords; i++)
            {
                aMsg.mWords[i] = 101 + i;
            }
        }

        public static void show(StatusResponseMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "ProtoCommMsg.StatusMsg");
            Prn.print(Prn.ThreadRun1, "Code1      {0}", aMsg.mCode1);
            Prn.print(Prn.ThreadRun1, "Code2      {0}", aMsg.mCode2);
            Prn.print(Prn.ThreadRun1, "Code3      {0}", aMsg.mCode3);
            Prn.print(Prn.ThreadRun1, "Code4      {0}", aMsg.mCode4);

            for (int i = 0; i < aMsg.mNumOfWords; i++)
            {
                Prn.print(Prn.ThreadRun1, "Words     {0} {1}", 1, aMsg.mWords[i]);
                aMsg.mWords[i] = 101 + i;
            }
        }

        //******************************************************************************
        //******************************************************************************
        //******************************************************************************
        // DataRecord

        public static void initialize(DataRecord aMsg)
        {
            aMsg.mCode1 = 701;
            aMsg.mCode2 = 702;
            aMsg.mCode3 = 703;
            aMsg.mCode4 = 704;
        }

        public static void show(DataRecord aMsg)
        {
            Prn.print(Prn.ThreadRun1, "ProtoCommMsg.DataRecord");
            Prn.print(Prn.ThreadRun1, "Code1      {0}", aMsg.mCode1);
            Prn.print(Prn.ThreadRun1, "Code2      {0}", aMsg.mCode2);
            Prn.print(Prn.ThreadRun1, "Code3      {0}", aMsg.mCode3);
            Prn.print(Prn.ThreadRun1, "Code4      {0}", aMsg.mCode4);
        }

        //******************************************************************************
        //******************************************************************************
        //******************************************************************************
        // DataMsg

        public static void initialize(DataMsg aMsg)
        {
            aMsg.mUChar = 0x11;
            aMsg.mUShort = 0x1234;
            aMsg.mUInt = 0x12345678;
            aMsg.mUInt64 = 0x1112131415161718;
            aMsg.mChar = 0x11;
            aMsg.mShort = 0x1234;
            aMsg.mInt = 0x12345678;
            aMsg.mInt64 = 0x1112131415161718;
            aMsg.mFloat = 12.34f;
            aMsg.mDouble = 56.78;
            aMsg.mBool = true;
            aMsg.mString1 = @"abcdef";
            aMsg.mString2 = @"01234567";
            initialize(aMsg.mDataRecord);
        }

        public static void show(DataMsg aMsg)
        {
            Prn.print(Prn.ThreadRun1, "ProtoCommMsg.DataMsg");
            Console.WriteLine("UChar    {0:X}",  aMsg.mUChar   );
            Console.WriteLine("UShort   {0:X}",  aMsg.mUShort  );
            Console.WriteLine("UInt     {0:X}",  aMsg.mUInt    );
            Console.WriteLine("Unit64   {0:X}",  aMsg.mUInt64  );
            Console.WriteLine("Char     {0:X}",  aMsg.mChar    );
            Console.WriteLine("Short    {0:X}",  aMsg.mShort   );
            Console.WriteLine("Int      {0:X}",  aMsg.mInt     );
            Console.WriteLine("Int64    {0:X}",  aMsg.mInt64   );
            Console.WriteLine("Float    {0}",    aMsg.mFloat   );
            Console.WriteLine("Double   {0}",    aMsg.mDouble  );
            Console.WriteLine("Bool     {0}",    aMsg.mBool    );
            Console.WriteLine("String   {0}",    aMsg.mString1 );
            Console.WriteLine("String   {0}",    aMsg.mString2 );
            Console.WriteLine("");
            show(aMsg.mDataRecord);
            Console.WriteLine("");
        }
    }

}
