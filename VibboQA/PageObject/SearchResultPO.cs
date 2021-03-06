﻿using OpenQA.Selenium;

namespace VibboQA.PageObject
{
    /// <summary>
    /// Page Object To interact with any element in the searh result page
    /// </summary>
    public class SearchResultPO : BasePageObject
    {
        private FilterBoxPO _filterPO;
        public FilterBoxPO FilterBoxPO
        {
            get { return _filterPO == null ? _filterPO = new FilterBoxPO(driver) : _filterPO; }
        }

        private SearchResultGridPO _searchResultGridPO;
        public SearchResultGridPO SearchResultGridPO
        {
            get { return _searchResultGridPO == null ? _searchResultGridPO = new SearchResultGridPO(driver) : _searchResultGridPO; }
        }

        public SearchResultPO(IWebDriver driver) : base(driver) { }
    }
}
