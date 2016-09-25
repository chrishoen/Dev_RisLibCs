using System;
using System.Collections.Generic;
using System.Text;

using Ris;
using ProtoComm;

namespace MainApp
{
    //**************************************************************************
    //**************************************************************************
    //**************************************************************************
    class Init
    {

        //**********************************************************************
        //**********************************************************************
        //**********************************************************************

        public static void initialize()
        {
            Console.WriteLine("ProtoComm_CS BEGIN");
            initializePrint();
        }

        //**********************************************************************
        //**********************************************************************
        //**********************************************************************

        public static void finalize()
        {
            Console.WriteLine("ProtoComm_CS END");
        }

        //**********************************************************************
        //**********************************************************************
        //**********************************************************************

        public static void initializePrint()
        {
            Prn.initializeForConsole();

            Prn.setFilter(Prn.SocketInit1, false);
            Prn.setFilter(Prn.SocketInit2,  true);
            Prn.setFilter(Prn.SocketRun1,   true);
            Prn.setFilter(Prn.SocketRun2,  false);
            Prn.setFilter(Prn.SocketRun3,  false);
            Prn.setFilter(Prn.SocketRun4,  false);

            Prn.setFilter(Prn.ThreadRun1,   true);
            Prn.setFilter(Prn.ThreadRun2,  false);
            Prn.setFilter(Prn.ThreadRun3,  false);
            Prn.setFilter(Prn.ThreadRun4,  false);

        }
    }
}
