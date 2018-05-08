using OpenQA.Selenium;

namespace VibboQA.PageObject
{
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

        public string GetElementSubjectName()
        {
            IWebElement element = GetElementsByClassName(_subjectNameClassName, defaultTimeOut)[_index];
            return element != null ? element.Text : string.Empty;
        }

        public string GetElementPrice()
        {
            IWebElement element = GetElementsByClassName(_priceClassName, defaultTimeOut)[_index];
            return element != null ? element.Text : string.Empty;
        }

        public string GetElementLocation()
        {
            IWebElement element = GetElementsByClassName(_zoneClassName, defaultTimeOut)[_index];
            return element != null ? element.Text : string.Empty;
        }

        public ElementDetailPO ClickElementSubjectName()
        {
            GetElementsByClassName(_subjectNameClassName, defaultTimeOut)[_index].Click();
            return new ElementDetailPO(driver);
        }
    }
}
