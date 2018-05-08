using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace VibboQA.PageObject
{
    public class SearchResultGridPO : BasePageObject
    {
        private IWebElement _searchResultGrid;
        private List<GridElementPO> _searchResultElements;

        private string _resultGridId = "list_ads_table_container";
        private string _gridElementsClassName = "list_ads_row";


        public SearchResultGridPO(IWebDriver driver) : base(driver)
        {
            _searchResultGrid = GetElementById(_resultGridId, defaultTimeOut);
            UpdateSearchGrid();
        }

        public void UpdateSearchGrid()
        {
            _searchResultElements = new List<GridElementPO>();
            List<IWebElement> gridItems = new List<IWebElement>(_searchResultGrid.FindElements(By.ClassName(_gridElementsClassName)));

            for (int i = 0; i < gridItems.Count; i++)
            {
                _searchResultElements.Add(new GridElementPO(driver, i));
            }
        }

        public ElementDetailPO ClickElement(string subject)
        {
            ElementDetailPO elementDetailPO = null;

            foreach (GridElementPO element in _searchResultElements)
            {
                if (subject.Equals(element.GetElementSubjectName(), StringComparison.InvariantCultureIgnoreCase))
                {
                    elementDetailPO = element.ClickElementSubjectName();
                    break;
                }
            }

            return elementDetailPO;
        }

        public GridElementPO ElementWithName(string subject)
        {
            GridElementPO gridElementPO = null;
            foreach (GridElementPO element in _searchResultElements)
            {
                if (subject.Equals(element.GetElementSubjectName(), StringComparison.InvariantCultureIgnoreCase))
                {
                    gridElementPO = element;
                    break;
                }
            }

            return gridElementPO;
        }
    }
}
