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
            Init.initialize();
            CmdLineConsole.execute(new MyCmdLineExec());
            Init.finalize();
        }
    }
}
