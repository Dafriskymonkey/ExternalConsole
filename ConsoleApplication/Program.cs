/* This is an example of a console program,
 * it will print outputs on the console.
 * this program can be anything runing and printing results within a console.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            writeNwait("Console Application : start execution.");

            //simple loop that will display numbers
            for (int i = 0; i < 5; i++)
            {
                writeNwait(i.ToString());
            }

            writeNwait("Console Application : finish execution.");
        }

        // function that will print str and wait for timeout (ms)
        static void writeNwait(string str, int timeOut = 1000)
        {
            Console.WriteLine(str);
            System.Threading.Thread.Sleep(timeOut);
        }
    }
}
