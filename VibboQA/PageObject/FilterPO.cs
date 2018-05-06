using System;
using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    public class FilterPO : BasePageObject
    {
        public FilterPO(IWebDriver driver) : base(driver) { }

        public void PriceFrom(int price)
        {
            IWebElement priceFrom = GetElementById("sb_pricelistFrom", new TimeSpan(0, 0, 20));
            priceFrom.SendKeys(price.ToString());
        }

        public void PriceTo(int price)
        {
            IWebElement priceTo = GetElementById("sb_pricelistTo", new TimeSpan(0, 0, 20));
            priceTo.SendKeys(price.ToString());

        }

        public void PriceFromTo(int from, int to)
        {
            PriceFrom(from);
            PriceTo(to);
        }

        public void ClickApplyFilters()
        {
            IWebElement applyFilterButton = GetElementById("sb_searchbutton_filter", new TimeSpan(0, 0, 20));
            applyFilterButton.Click();
        }
    }
}
