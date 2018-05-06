using OpenQA.Selenium;
using System;

namespace VibboQA.PageObject
{
    public class GridElementPO : BasePageObject
    {
        private int index = 0;
        public GridElementPO(IWebDriver driver, int index) : base(driver)
        {
            this.index = index;
        }

        public string GetElementSubjectName()
        {
            IWebElement element = GetElementsByClassName("subjectTitle", new TimeSpan(0, 0, 20))[index];
            return element != null ? element.Text : "";
        }

        public void ClickElementSubjectName()
        {
            GetElementsByClassName("subjectTitle", new TimeSpan(0, 0, 20))[index].Click();
        }

    }
}
