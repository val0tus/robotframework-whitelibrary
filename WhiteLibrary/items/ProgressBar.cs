using System;
using TestStack.White.UIItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
    public class ProgressBarKeywords : LibraryElement
    {
        public ProgressBarKeywords(WhiteLibrary state) : base(state)
        {

        }

        [RobotKeyword]
        public Double verify_progressbar(string locator)
        {
            ProgressBar myProgressBar = getProgressBar(locator);
            return myProgressBar.Value;
        }

        private ProgressBar getProgressBar(string locator)
        {
            return State.Finder.getItemByLocator<ProgressBar>(locator);
        }

    }
}
