using System;
using TestStack.White.UIItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
    public class SliderKeywords : LibraryElement
    {
        public SliderKeywords(WhiteLibrary state) : base(state)
        {

        }

        [RobotKeyword]
        public bool set_slider(string locator, Double myvalue)
        {
            Slider myslider = getSlider(locator);
            myslider.Value = myvalue;
            return true;
        }

        private Slider getSlider(string locator)
        {
            return State.Finder.getItemByLocator<Slider>(locator);
        }

        [RobotKeyword]
        public Double verify_slider(string locator)
        {
            Slider mySlider = getSlider(locator);
            return mySlider.Value;
        }
    }
}
