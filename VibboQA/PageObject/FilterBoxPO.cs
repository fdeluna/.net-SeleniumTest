using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    public class FilterBoxPO : BasePageObject
    {
        private string _priceFromId = "sb_pricelistFrom";
        private string _priceToId = "sb_pricelistTo";
        private string _applyFiltersId = "sb_searchbutton_filter";

        public FilterBoxPO(IWebDriver driver) : base(driver) { }

        public void PriceFrom(int price)
        {
            IWebElement priceFrom = GetElementById(_priceFromId, defaultTimeOut);
            priceFrom.SendKeys(price.ToString());
        }

        public void PriceTo(int price)
        {
            IWebElement priceTo = GetElementById(_priceToId, defaultTimeOut);
            priceTo.SendKeys(price.ToString());

        }

        public void PriceFromTo(int from, int to)
        {
            PriceFrom(from);
            PriceTo(to);
        }

        public void ClickApplyFilters()
        {
            IWebElement applyFilterButton = GetElementById(_applyFiltersId, defaultTimeOut);
            applyFilterButton.Click();
        }
    }
}