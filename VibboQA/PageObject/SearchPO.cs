using System;
using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    public class SearchPO : BasePageObject
    {
        public SearchPO(IWebDriver driver) : base(driver) { }

        public void ClickSearchButton()
        {
            IWebElement searchButton = GetElementById("sb_submit", new TimeSpan(0, 0, 20));
            searchButton.Click();
        }

        public void InputSearchTerm(string item)
        {
            IWebElement searchTerm = GetElementById("sb_searchtext", new TimeSpan(0, 0, 20));
            searchTerm.SendKeys(item);
        }

        public void InputSearchLocation(string location)
        {
            IWebElement searchLocation = GetElementById("sb_location", new TimeSpan(0, 0, 20));
            searchLocation.SendKeys(location);
            IWebElement searchLocationItem = GetElementByXpath(string.Format("//li//*/b[contains(text(),'{0}')]", location), new TimeSpan(0, 0, 20));
            searchLocationItem.Click();
        }
    }
}
