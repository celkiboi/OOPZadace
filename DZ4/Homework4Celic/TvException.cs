using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow
{
    public class TvException : Exception
    {
        readonly string title;

        public TvException(string message, string title) : base(message)
        {
            this.title = title;
        }

        public string Title
        {
            get { return title; }
        }
    }
}
