using TestStack.White.UIItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
    public class ButtonKeywords : LibraryElement
    {
        public ButtonKeywords(WhiteLibrary state) : base(state)
        {
        }

        [RobotKeyword]
        public string verify_button(string locator)
        {
            Button button = getButton(locator);
            return button.Text;
        }

        [RobotKeyword]
        public bool click_button(string locator)
        {
            Button button = getButton(locator);
            button.Click();
            return true;
        }

        private Button getButton(string locator)
        {
            return State.Finder.getItemByLocator<Button>(locator);
        }

    }
}
