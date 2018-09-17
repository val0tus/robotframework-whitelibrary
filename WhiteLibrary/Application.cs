using System;
using TestStack.White;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary
{
    [RobotKeywordClass]
    public class ApplicationKeywords : LibraryElement
    {
        public ApplicationKeywords(WhiteLibrary state) : base(state)
        {
        }
    
        [RobotKeyword]
        public bool launchApplication(string sut)
        {
            State.App = Application.Launch(sut);
            return true;
        }

        [RobotKeyword]
        public bool closeApplication()
        {
            State.App.Close();
            return true;
        }
    }
}
