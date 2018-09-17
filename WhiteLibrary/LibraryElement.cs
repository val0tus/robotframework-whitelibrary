using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWhiteLibrary
{
    public class LibraryElement
    {
        public WhiteLibrary State { get; }

        public LibraryElement(WhiteLibrary state)
        {
            State = state;
        }

    }
}
