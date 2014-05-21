using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Shsict.ThreadConsole
{
    class Program
    {
        public static Thread myThread;

        static void Main(string[] args)
        {
            myThread = new Thread(new ThreadStart(run));
            myThread.Start();

        }

         

        private static void run()
        {
            throw new NotImplementedException();
        }
    }
}
