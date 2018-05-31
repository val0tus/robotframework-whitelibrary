using System;
using TestStack.White.UIItems;
using WhiteLibrary;

namespace CSWhiteLibrary.items
{
	public partial class Keywords : WhiteFW
    {
        public void set_slider(string locator, Double myvalue)
        {
            Slider myslider = getSlider(locator);
            myslider.Value = myvalue;
        }

        private Slider getSlider(string locator)
        {
            return getItemByLocator<Slider>(locator);
        }
    }
}
