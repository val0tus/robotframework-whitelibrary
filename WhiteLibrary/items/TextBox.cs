using System;
using TestStack.White.UIItems;
using WhiteLibrary;

namespace CSWhiteLibrary.items
{
	public partial class Keywords : WhiteFW
    {

        private TextBox getTextBox(string locator)
        {
            return getItemByLocator<TextBox>(locator);
        }

    }
}
