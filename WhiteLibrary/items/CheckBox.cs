using System;
using TestStack.White.UIItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
	public class CheckBoxKeywords : LibraryElement
    {
        public CheckBoxKeywords(WhiteLibrary state) : base(state)
        {

        }

        [RobotKeyword]
        public Boolean verify_check_box(string locator)
        {
            CheckBox check_box = getCheckBox(locator);
            return check_box.IsSelected;
        }

        [RobotKeyword]
        public void toggle_check_box(string locator)
        {
            CheckBox check_box = getCheckBox(locator);
            check_box.Toggle();
        }

        private CheckBox getCheckBox(string locator)
        {
            return State.Finder.getItemByLocator<CheckBox>(locator);
        }
    }
}
