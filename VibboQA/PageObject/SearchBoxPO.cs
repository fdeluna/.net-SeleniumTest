using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace VibboQA.PageObject
{
    public class SearchBoxPO : BasePageObject
    {
        public SearchBoxPO(IWebDriver driver) : base(driver) { }

        public void ClickSearchButton()
        {
            IWebElement searchButton = GetElementById("sb_submit", new TimeSpan(0, 0, 20));
            searchButton.Click();
        }

        public void InputSearchTerm(string item)
        {
            IWebElement searchBox = GetElementById("sb_searchtext", new TimeSpan(0, 0, 20));
            searchBox.SendKeys(item);
        }

        public void InputSearchLocation(string location)
        {
            IWebElement searchBox = GetElementById("sb_location", new TimeSpan(0, 0, 20));
            searchBox.SendKeys(location);
        }
    }
}
