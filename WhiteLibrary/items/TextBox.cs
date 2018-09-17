using TestStack.White.UIItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
    public class TextBoxKeywords : LibraryElement
    {
        public TextBoxKeywords(WhiteLibrary state) : base(state)
        {
        }

        private TextBox getTextBox(string locator)
        {
            return State.Finder.getItemByLocator<TextBox>(locator);
        }

        [RobotKeyword]
        public bool inputTextToTextbox(string locator, string mytext)
        {
            TextBox textBox = getTextBox(locator);
            textBox.Text = mytext;
            return true;
        }

        [RobotKeyword]
        public string verify_text_textbox(string locator)
        {
            TextBox textBox = getTextBox(locator);
            return textBox.Text;
        }

    }
}
