using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10440914_PROG6221_POEPart2
{
    public class TextDelay
    {
        //textDelay function           
        public static void textDelay(string greeting, int delay = 5)
        {
            foreach (var c in greeting)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
}

