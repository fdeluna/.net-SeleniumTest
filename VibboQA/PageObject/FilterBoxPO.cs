using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    /// <summary>
    /// Page Object To interact with Filter Box at Search Result Grid
    /// </summary>
    public class FilterBoxPO : BasePageObject
    {
        private string _priceFromId = "sb_pricelistFrom";
        private string _priceToId = "sb_pricelistTo";
        private string _applyFiltersId = "sb_searchbutton_filter";

        public FilterBoxPO(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Fill filter with price from
        /// </summary>
        /// <param name="price"></param>
        public void PriceFrom(int price)
        {
            IWebElement priceFrom = GetElementById(_priceFromId, defaultTimeOut);
            priceFrom.SendKeys(price.ToString());
        }


        /// <summary>
        /// Fill filter with price to
        /// </summary>
        /// <param name="price"></param>
        public void PriceTo(int price)
        {
            IWebElement priceTo = GetElementById(_priceToId, defaultTimeOut);
            priceTo.SendKeys(price.ToString());

        }


        /// <summary>
        /// Fill filter with price from - to
        /// </summary>
        /// <param name="price"></param>
        public void PriceFromTo(int from, int to)
        {
            PriceFrom(from);
            PriceTo(to);
        }


        /// <summary>
        /// Apply filter
        /// </summary>
        /// <param name="price"></param>
        public void ClickApplyFilters()
        {
            IWebElement applyFilterButton = GetElementById(_applyFiltersId, defaultTimeOut);
            applyFilterButton.Click();
        }
    }
}