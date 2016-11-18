using System;
using System.Text;
using Ris;

namespace MyApp
{
    //******************************************************************************
    //******************************************************************************
    //******************************************************************************
    // InputFile

    public class MyCmdLineFile : BaseCmdLineExec
    {
        //---------------------------------------------------------------------------
        // Members

        int mCode1;
        int mCode2;
        int mCode3;
        int mCode4;

        //---------------------------------------------------------------------------
        // Constructor

        public MyCmdLineFile()
        {
            CmdLineFile tCmdLineFile = new CmdLineFile();

            String tFilePath = @"..\..\..\Files\MyCmdLineFile.txt";

            // Open command line file
            if (!tCmdLineFile.open(tFilePath))
            {
                Console.WriteLine("MyCmdLineFile.readFromFilePath FAIL {0}\n", tFilePath);
                return;
            }
            else
            {
                Console.WriteLine("MyCmdLineFile.readFromFilePath PASS {0}\n", tFilePath);
            }

            // Read command line file, execute commands for each line in the file,
            // using this command line executive
            tCmdLineFile.execute(this);

            // Close command line file
            tCmdLineFile.close();
        }

        public void show()
        {
            Console.WriteLine("mCode1 {0}", mCode1);
            Console.WriteLine("mCode2 {0}", mCode2);
            Console.WriteLine("mCode3 {0}", mCode3);
            Console.WriteLine("mCode4 {0}", mCode4);
        }

        //---------------------------------------------------------------------------
        // Execute

        public override void execute(CmdLineCmd aCmd)
        {
            // Read Members
            if (aCmd.isCmd("Code1"))        mCode1 = aCmd.argInt(1);
            if (aCmd.isCmd("Code2"))        mCode2 = aCmd.argInt(1);
            if (aCmd.isCmd("Code3"))        mCode3 = aCmd.argInt(1);
            if (aCmd.isCmd("Code4"))        mCode4 = aCmd.argInt(1);
        }

    };
}
