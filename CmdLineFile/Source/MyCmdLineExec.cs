using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ris;

namespace MyApp
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
            if (aCmd.isCmd("READ"))    executeRead(aCmd);
            if (aCmd.isCmd("GO1"))     executeGo1(aCmd);
            if (aCmd.isCmd("GO2"))     executeGo2(aCmd);
            if (aCmd.isCmd("GO3"))     executeGo3(aCmd);
            if (aCmd.isCmd("GO4"))     executeGo4(aCmd);
            if (aCmd.isCmd("GO5"))     executeGo5(aCmd);

            if (aCmd.isComment())      executeIsComment(aCmd);
        }

        //**********************************************************************

        public void executeRead(CmdLineCmd aCmd)
        {
            MyCmdLineFile tFile = new MyCmdLineFile();
            tFile.show();
        }

        //**********************************************************************

        public void executeGo1(CmdLineCmd aCmd)
        {
        }

        //**********************************************************************

        public void executeGo2(CmdLineCmd aCmd)
        {
            String tPath = Directory.GetCurrentDirectory();
            Console.WriteLine("GetCurrentDirectory {0}",tPath);
        }

        //**********************************************************************

        public void executeGo3(CmdLineCmd aCmd)
        {
            Console.WriteLine("PrintView2.exe stopping");
            Prn.print(0,"PRINTVIEW_SHUTDOWN");
        }

        //**********************************************************************

        public void executeGo4(CmdLineCmd aCmd)
        {
            aCmd.setArgDefault(1, 101);

            UInt16 tN = aCmd.argUInt16(1);

            Console.WriteLine("{0}", tN);
        }


        //**********************************************************************

        public void executeGo5(CmdLineCmd aCmd)
        {
            aCmd.setArgDefault(1,101);
            int tX = aCmd.argInt(1);

            Console.WriteLine("X       {0}",tX);
            Console.WriteLine("Comment {0} {1}",aCmd.hasComment(),aCmd.comment());

        }

        //**********************************************************************

        public void executeIsComment(CmdLineCmd aCmd)
        {
            Console.WriteLine("Comment {0}",aCmd.comment());

        }


    }
}
