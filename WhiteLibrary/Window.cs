using System.Collections.Generic;
using TestStack.White.UIItems.WindowItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary
{
    [RobotKeywordClass]
    public class WindowKeywords : LibraryElement
    {
        public WindowKeywords(WhiteLibrary state) : base(state)
        {
        }

        [RobotKeyword]
        public void attach_window(string window)
        {
            State.Window = State.App.GetWindow(window);
        }

        [RobotKeyword]
        public void select_modal_window(string locator)
        {
            List<Window> modalWindows = State.Window.ModalWindows();
            State.Window = State.Window.ModalWindow(locator);
        }
    }
}
