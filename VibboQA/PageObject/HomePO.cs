using OpenQA.Selenium;

namespace VibboQA.PageObject
{
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
