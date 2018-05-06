using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace VibboQA.PageObject
{
    public class SearchResultGridPO : BasePageObject
    {
        private IWebElement _searchResultGrid;
        private List<GridElementPO> _searchResultElements;

        public SearchResultGridPO(IWebDriver driver) : base(driver)
        {
            _searchResultGrid = GetElementById("list_ads_table_container", new TimeSpan(0, 0, 20));
            UpdateSearchGrid();
        }

        public void UpdateSearchGrid()
        {
            _searchResultElements = new List<GridElementPO>();
            List<IWebElement> gridItems = new List<IWebElement>(_searchResultGrid.FindElements(By.ClassName("list_ads_row")));

            for (int i = 0; i < gridItems.Count; i++)
            {
                _searchResultElements.Add(new GridElementPO(driver, i));
            }
        }

        public void ClickElement(string subject)
        {
            _searchResultElements.ForEach(x =>
            {
                if (subject.Equals(x.GetElementSubjectName(), StringComparison.InvariantCultureIgnoreCase))
                {
                    x.ClickElementSubjectName();
                    return;
                }
            });
        }        
    }
}
