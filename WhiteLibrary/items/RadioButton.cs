using System;
using TestStack.White.UIItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
    public class RadioButtonKeywords : LibraryElement
    {
        public RadioButtonKeywords(WhiteLibrary state) : base(state)
        {

        }

        [RobotKeyword]
        public bool select_radio_button(string locator)
        {
            RadioButton radio_button = getRadioButton(locator);
            radio_button.Select();
            return true;
        }

        [RobotKeyword]
        public Boolean verify_radio_button(string locator)
        {
            RadioButton radio_button = getRadioButton(locator);
            return radio_button.IsSelected;
        }

        private RadioButton getRadioButton(string locator)
        {
            return State.Finder.getItemByLocator<RadioButton>(locator);
        }
    }
}
