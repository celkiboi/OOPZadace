using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow
{
    public class FilePrinter : IPrinter
    {
        private string outputFile;

        public FilePrinter(string outputFile)
        {
            this.outputFile = outputFile;
        }
        public string OutputFile
        {
            get { return outputFile; }
        }

        public void Print(string argument)
        {
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                sw.WriteLine(argument);
            }
        }
    }
}
