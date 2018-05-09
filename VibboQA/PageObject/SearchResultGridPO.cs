using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace VibboQA.PageObject
{
    /// <summary>
    /// Page Object To interact with search result grid
    /// </summary>
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

        /// <summary>
        /// Update list of WebElements existing in the grid
        /// </summary>
        public void UpdateSearchGrid()
        {
            _searchResultElements = new List<GridElementPO>();
            List<IWebElement> gridItems = new List<IWebElement>(_searchResultGrid.FindElements(By.ClassName(_gridElementsClassName)));

            for (int i = 0; i < gridItems.Count; i++)
            {
                _searchResultElements.Add(new GridElementPO(driver, i));
            }
        }

        /// <summary>
        /// Click any element of the grid by subject name
        /// </summary>
        /// <param name="subject"></param>
        /// <returns>Element detail PO</returns>
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


        /// <summary>
        /// Return any element of the grid by subject name
        /// </summary>
        /// <param name="subject"></param>
        /// <returns>Grid Elemet PO</returns>
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
