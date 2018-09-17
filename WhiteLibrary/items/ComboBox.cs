using TestStack.White.UIItems.ListBoxItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary
{
    [RobotKeywordClass]
    public class ComboBoxKeywords : LibraryElement
    {
        public ComboBoxKeywords(WhiteLibrary state) : base(state)
        {

        }

        private ComboBox getComboBox(string locator)
        {
            return State.Finder.getItemByLocator<ComboBox>(locator);
        }

        [RobotKeyword]
        public void select_combobox_value(string locator, string value)
        {
            ComboBox comboBox = getComboBox(locator);
            comboBox.Select(value);
        }

        [RobotKeyword]
        public void select_combobox_index(string locator, int index)
        {
            ComboBox comboBox = getComboBox(locator);
            comboBox.Select(index);
        }

        [RobotKeyword]
        public string verify_combobox_item(string locator)
        {
            ComboBox comboBox = getComboBox(locator);
            return comboBox.EditableText;
        }
    }
}
