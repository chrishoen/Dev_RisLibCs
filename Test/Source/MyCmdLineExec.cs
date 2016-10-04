﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ris;

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
            if (aCmd.isCmd("GO1")) executeGo1(aCmd);
            if (aCmd.isCmd("GO2")) executeGo2(aCmd);
            if (aCmd.isCmd("GO3")) executeGo3(aCmd);
            if (aCmd.isCmd("GO4")) executeGo4(aCmd);
            if (aCmd.isCmd("GO5")) executeGo5(aCmd);
        }

        //**********************************************************************

        public void executeGo1(CmdLineCmd aCmd)
        {
            String tProcessName = @"C:\RedInc\SDSAT\Bin\PrintView2.exe";

            if (File.Exists(tProcessName))
            {
                if (Process.GetProcessesByName(tProcessName).Length == 0)
                {
                    Console.WriteLine("PrintView2.exe starting");
                    Process.Start(tProcessName);
                }
                else
                {
                    Console.WriteLine("PrintView2.exe already started");
                }
            }
            else
            {
                Console.WriteLine("PrintView2.exe not found");
            }
        }

        //**********************************************************************

        public void executeGo2(CmdLineCmd aCmd)
        {
            Prn.print(0,"TESTING");
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
//          DasComm.Settings.writeToXmlFile(@"C:\Alpha\Settings\DasCommSettings.xml");
        }


    }
}
