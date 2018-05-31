using System;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using WhiteLibrary;

namespace CSWhiteLibrary
{
	public partial class Keywords : WhiteFW
    {
        private Window window;

        public void attach_window(string window)
        {
            this.window = app.GetWindow(window);
        }

    }
}
