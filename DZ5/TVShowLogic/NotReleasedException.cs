using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShowLogic
{
    public class NotReleasedException : Exception
    {
        public NotReleasedException(string messege) : base(messege)
        { }
    }
}
