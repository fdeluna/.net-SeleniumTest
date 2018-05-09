using OpenQA.Selenium;
using VibboQA.Drivers;

namespace VibboQA.PageObject
{
    /// <summary>
    /// Page Object To interact with search Box
    /// </summary>
    public class SearchBoxPO : BasePageObject
    {
        private string _searchButtonId = "sb_submit";
        private string _searchTermId = "sb_searchtext";
        private string _searchLocationId = "sb_location";
        private string _locationDropdownXpath = "//li//*/b[contains(text(),'{0}')]";

        public SearchBoxPO(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Checks Search term box is visible
        /// </summary>
        /// <returns>if the search term box is visible</returns>
        public bool CheckSearchTermIsVisible()
        {
            return driver.WaitUntilVisible(By.Id(_searchTermId), defaultTimeOut);
        }

        /// <summary>
        /// Checks Search location box is visible
        /// </summary>
        /// <returns>if the search location box is visible</returns>
        public bool CheckLocationTermIsVisible()
        {
            return driver.WaitUntilVisible(By.Id(_searchLocationId), defaultTimeOut);
        }

        /// <summary>
        /// Checks Search button is visible
        /// </summary>
        /// <returns>if the search button is visible</returns>
        public bool CheckSearchButtonIsVisible()
        {
            return driver.WaitUntilVisible(By.Id(_searchButtonId), defaultTimeOut);
        }

        /// <summary>
        /// Checks if all elements of the search box are visiible
        /// </summary>
        /// <returns>If all elements are visible</returns>
        public bool SearchBoxIsReady()
        {
            bool isReady = CheckSearchTermIsVisible();
            isReady &= CheckSearchTermIsVisible();
            isReady &= CheckSearchButtonIsVisible();

            return isReady;
        }

        /// <summary>
        /// Click on search button
        /// </summary>
        /// <returns>Search result PO</returns>
        public SearchResultPO ClickSearchButton()
        {
            IWebElement searchButton = GetElementById(_searchButtonId, defaultTimeOut);
            searchButton.Click();
            return new SearchResultPO(driver);
        }

        /// <summary>
        /// Fills the search term
        /// </summary>
        /// <param name="item"></param>
        public void InputSearchTerm(string item)
        {
            IWebElement searchTerm = GetElementById(_searchTermId, defaultTimeOut);
            searchTerm.SendKeys(item);
        }

        /// <summary>
        /// Fills the search location
        /// </summary>
        /// <param name="location"></param>
        public void InputSearchLocation(string location)
        {
            IWebElement searchLocation = GetElementById(_searchLocationId, defaultTimeOut);
            searchLocation.SendKeys(location);
            IWebElement searchLocationItem = GetElementByXpath(string.Format(_locationDropdownXpath, location), defaultTimeOut);
            searchLocationItem.Click();
        }

        /// <summary>
        /// Search item and location
        /// </summary>
        /// <param name="item"></param>
        /// <param name="location"></param>
        /// <returns>Search Result PO</returns>
        public SearchResultPO SearchItemLocation(string item, string location)
        {
            InputSearchTerm(item);
            InputSearchLocation(location);
            return ClickSearchButton();
        }

    }
}