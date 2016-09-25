using System;
using System.Collections.Generic;
using System.Text;

using Ris;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Init.initialize(args);
            CmdLineConsole.execute(new MyCmdLineExec());
            Init.finalize();
        }
    }
}
