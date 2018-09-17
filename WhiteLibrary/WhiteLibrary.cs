using CsDynamicLib;
using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace CSWhiteLibrary
{
    public class WhiteLibrary : CsLib
    {
        public Application App { get; set; }
        public Window Window { get; set; }
        public ItemFinder Finder { get; }

        public WhiteLibrary()
        {
            LibraryElements = InitializeLibraryElements();
            Finder = new ItemFinder(this);
        }

        private List<LibraryElement> InitializeLibraryElements()
        {
            var keywordClasses = GetRobotKeywordClasses();
            var libraryElements = new List<LibraryElement>();
            foreach (var keywordClass in keywordClasses)
            {
                libraryElements.Add((LibraryElement)Activator.CreateInstance(keywordClass, this));
            }
            return libraryElements;
        }
    }
}
