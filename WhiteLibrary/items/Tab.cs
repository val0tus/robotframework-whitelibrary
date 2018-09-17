using TestStack.White.UIItems.TabItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
    public class TabKeywords : LibraryElement
    {
        public TabKeywords(WhiteLibrary state) : base(state)
        {
        }

        [RobotKeyword]
        public bool selectTabPage(string locator, string tabTitle)
        {
            Tab tab = getTab(locator);
            tab.SelectTabPage(tabTitle);
            return true;
        }

        private Tab getTab(string locator)
        {
            return State.Finder.getItemByLocator<Tab>(locator);
        }
    }
}
