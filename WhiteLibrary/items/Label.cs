using TestStack.White.UIItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
    public class LabelKeywords : LibraryElement
    {
        public LabelKeywords(WhiteLibrary state) : base(state)
        {

        }

        [RobotKeyword]
        public string verify_label(string locator)
        {
            Label label = getLabel(locator);
            return label.Text;
        }

        protected Label getLabel(string locator)
        {
            return State.Finder.getItemByLocator<Label>(locator);
        }

    }
}
