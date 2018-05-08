using OpenQA.Selenium;
using VibboQA.Drivers;

namespace VibboQA.PageObject
{
    public class SearchBoxPO : BasePageObject
    {
        private string _searchButtonId = "sb_submit";
        private string _searchTermId = "sb_searchtext";
        private string _searchLocationId = "sb_location";
        private string _locationDropdownXpath = "//li//*/b[contains(text(),'{0}')]";

        public SearchBoxPO(IWebDriver driver) : base(driver) { }

        public bool CheckSearchTermIsVisible()
        {
            return driver.WaitUntilVisible(By.Id(_searchTermId), defaultTimeOut);
        }

        public bool CheckLocationTermIsVisible()
        {
            return driver.WaitUntilVisible(By.Id(_searchLocationId), defaultTimeOut);
        }

        public bool CheckSearchButtonIsVisible()
        {
            return driver.WaitUntilVisible(By.Id(_searchButtonId), defaultTimeOut);
        }

        public bool SearchBoxIsReady()
        {
            bool isReady = CheckSearchTermIsVisible();
            isReady &= CheckSearchTermIsVisible();
            isReady &= CheckSearchButtonIsVisible();

            return isReady;
        }

        public SearchResultPO ClickSearchButton()
        {
            IWebElement searchButton = GetElementById(_searchButtonId, defaultTimeOut);
            searchButton.Click();
            return new SearchResultPO(driver);
        }

        public void InputSearchTerm(string item)
        {
            IWebElement searchTerm = GetElementById(_searchTermId, defaultTimeOut);
            searchTerm.SendKeys(item);
        }

        public void InputSearchLocation(string location)
        {
            IWebElement searchLocation = GetElementById(_searchLocationId, defaultTimeOut);
            searchLocation.SendKeys(location);
            IWebElement searchLocationItem = GetElementByXpath(string.Format(_locationDropdownXpath, location), defaultTimeOut);
            searchLocationItem.Click();
        }

        public SearchResultPO SearchItemLocation(string item, string location)
        {
            InputSearchTerm(item);
            InputSearchLocation(location);
            return ClickSearchButton();
        }

    }
}