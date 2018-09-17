using System;

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
