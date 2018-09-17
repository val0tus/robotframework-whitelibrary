using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace CSWhiteLibrary
{
    public class ItemFinder
    {
        private WhiteLibrary state;
        private Dictionary<string, string> strategies = new Dictionary<string, string>
        {
            {"id", "ByAutomationId"},
            {"text", "ByText"},
        };

        public ItemFinder(WhiteLibrary state)
        {
            this.state = state;
        }

        public T getItemByLocator<T>(string locator) where T : IUIItem
        {
            var locatorParts = getLocatorParts(locator);
            string searchStrategy = locatorParts[0];
            string locatorValue = locatorParts[1];

            if (searchStrategy == "partial_text")
            {
                return getItemByPartialText<T>(locatorValue);
            }

            return getItemBySearchCriteria<T>(searchStrategy, locatorValue);
        }

        private string[] getLocatorParts(string locator)
        {
            if (!locator.Contains("="))
            {
                // use automation id as default search strategy if no strategy is defined
                locator = "id=" + locator;
            }
            return locator.Split('=');
        }

        private T getItemByPartialText<T>(string partialText) where T : IUIItem
        {
            IUIItem[] items = state.Window.GetMultiple(SearchCriteria.All);
            return (T)items.First(x => x.GetType() == typeof(T) && x.Name.Contains(partialText));
        }

        private T getItemBySearchCriteria<T>(string searchStrategy, string locatorValue) where T : IUIItem
        {
            SearchCriteria searchCriteria = getSearchCriteria(searchStrategy, locatorValue);
            return state.Window.Get<T>(searchCriteria);
        }

        private SearchCriteria getSearchCriteria(string searchStrategy, string locatorValue)
        {
            if (searchStrategy == "index")
            {
                int index = int.Parse(locatorValue);
                return SearchCriteria.Indexed(index);
            }

            strategies.TryGetValue(searchStrategy, out string methodName);
            MethodInfo searchMethod = typeof(SearchCriteria).GetMethod(methodName);
            var methodParameters = new string[] { locatorValue };
            return (SearchCriteria)searchMethod.Invoke(null, methodParameters);
        }
    }
}
