using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string argument)
        {
            Console.WriteLine(argument);
        }
    }
}
