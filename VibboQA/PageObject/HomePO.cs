using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    /// <summary>
    /// Page Object To interact with any element in the home page
    /// </summary>
    public class HomePO : BasePageObject
    {        
        private SearchBoxPO _searchPO;
        public SearchBoxPO SearchPO
        {
            get { return _searchPO == null ? _searchPO = new SearchBoxPO(driver) : _searchPO; }
        }

        public HomePO(IWebDriver driver) : base(driver) { }
    }
}
