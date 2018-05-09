using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    /// <summary>
    /// Page Object To interact with any element of the search result grid
    /// </summary>
    public class GridElementPO : BasePageObject
    {
        private int _index = 0;
        private string _subjectNameClassName = "subjectTitle";
        private string _priceClassName = "add-price";
        private string _zoneClassName = "zone";



        public GridElementPO(IWebDriver driver, int index) : base(driver)
        {
            this._index = index;
        }

        /// <summary>
        /// Get the element subject name
        /// </summary>
        /// <returns>subject name</returns>
        public string GetElementSubjectName()
        {
            IWebElement element = GetElementsByClassName(_subjectNameClassName, defaultTimeOut)[_index];
            return element != null ? element.Text : string.Empty;
        }

        /// <summary>
        /// Get the element price
        /// </summary>
        /// <returns>price</returns>
        public string GetElementPrice()
        {
            IWebElement element = GetElementsByClassName(_priceClassName, defaultTimeOut)[_index];
            return element != null ? element.Text : string.Empty;
        }

        /// <summary>
        /// Get the element location
        /// </summary>
        /// <returns>subject location</returns>
        public string GetElementLocation()
        {
            IWebElement element = GetElementsByClassName(_zoneClassName, defaultTimeOut)[_index];
            return element != null ? element.Text : string.Empty;
        }

        /// <summary>
        /// Clicks on Subject name
        /// </summary>
        /// <returns> The element detail PO</returns>
        public ElementDetailPO ClickElementSubjectName()
        {
            GetElementsByClassName(_subjectNameClassName, defaultTimeOut)[_index].Click();
            return new ElementDetailPO(driver);
        }
    }
}
