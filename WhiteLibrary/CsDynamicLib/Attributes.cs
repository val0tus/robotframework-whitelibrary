using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsDynamicLib
{
    class Attributes
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class RobotKeyword : Attribute
        {

        }

        [AttributeUsage(AttributeTargets.Class)]
        public class RobotKeywordClass : Attribute
        {

        }

    }
}
