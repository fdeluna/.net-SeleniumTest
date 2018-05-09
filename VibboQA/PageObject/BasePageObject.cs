using System;
using System.Collections.Generic;
using log4net;
using OpenQA.Selenium;
using VibboQA.Drivers;

namespace VibboQA.PageObject
{
    public class BasePageObject
    {
        protected IWebDriver driver;
        protected TimeSpan defaultTimeOut = new TimeSpan(0, 0, 20);
        private static readonly ILog _log = LogManager.GetLogger(typeof(BasePageObject));

        public BasePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Look for a WebElement by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeOut"></param>
        /// <returns>Found element</returns>
        protected IWebElement GetElementById(String id, TimeSpan timeOut)
        {
            IWebElement element = null;

            if (!string.IsNullOrEmpty(id) && driver.WaitUntilVisible(By.Id(id), timeOut))
            {
                try
                {
                    element = driver.FindElement(By.Id(id));
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Element with id: {0} is missing", id);
                    _log.Error(e);
                }
            }
            return element;
        }

        /// <summary>
        /// Look for all WebElements by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeOut"></param>
        /// <returns>List with elements Found</returns>
        protected IList<IWebElement> GetElementsById(String key, TimeSpan timeOut)
        {
            IList<IWebElement> element = null;

            if (!string.IsNullOrEmpty(key) && driver.WaitUntilVisible(By.Id(key), timeOut))
            {
                try
                {
                    element = driver.FindElements(By.Id(key));
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Element with id: {0} is missing", key);
                    _log.Error(e);
                }
            }
            return element;
        }


        /// <summary>
        /// Look for a WebElement by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="timeOut"></param>
        /// <returns>Found element</returns>
        protected IWebElement GetElementByName(String name, TimeSpan timeOut)
        {
            IWebElement element = null;

            if (!string.IsNullOrEmpty(name) && driver.WaitUntilVisible(By.Id(name), timeOut))
            {
                try
                {
                    element = driver.FindElement(By.Name(name));
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Element with name: {0} is missing", name);
                    _log.Error(e);
                }
            }
            return element;
        }

        /// <summary>
        /// Look for a WebElement by xpath
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="timeOut"></param>
        /// <returns>Found element</returns>
        protected IWebElement GetElementByXpath(String xpath, TimeSpan timeOut)
        {
            IWebElement element = null;

            if (!string.IsNullOrEmpty(xpath) && driver.WaitUntilVisible(By.XPath(xpath), timeOut))
            {
                try
                {
                    element = driver.FindElement(By.XPath(xpath));
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Element with xpath: {0} is missing", xpath);
                    _log.Error(e);
                }
            }
            return element;
        }


        /// <summary>
        /// Look for all WebElements by xpath
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="timeOut"></param>
        /// <returns>List with elements Found</returns>
        protected IList<IWebElement> GetElementsByXpath(String xpath, TimeSpan timeOut)
        {
            IList<IWebElement> element = null;

            if (!string.IsNullOrEmpty(xpath) && driver.WaitUntilVisible(By.XPath(xpath), timeOut))
            {
                try
                {
                    element = driver.FindElements(By.XPath(xpath));
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Elements with xpath: {0} is missing", xpath);
                    _log.Error(e);
                }
            }
            return element;
        }

        /// <summary>
        /// Look for a WebElement by classname
        /// </summary>
        /// <param name="className"></param>
        /// <param name="timeOut"></param>
        /// <returns>Found element</returns>
        protected IWebElement GetElementByClassName(String className, TimeSpan timeOut)
        {
            IWebElement element = null;

            if (!string.IsNullOrEmpty(className) && driver.WaitUntilVisible(By.ClassName(className), timeOut))
            {
                try
                {
                    element = driver.FindElement(By.ClassName(className));
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Element with ClassName: {0} is missing", className);
                    _log.Error(e);
                }
            }
            return element;
        }


        /// <summary>
        /// Look for all WebElements by className
        /// </summary>
        /// <param name="className"></param>
        /// <param name="timeOut"></param>
        /// <returns>List with elements Found</returns>
        protected IList<IWebElement> GetElementsByClassName(String className, TimeSpan timeOut)
        {
            IList<IWebElement> element = null;

            if (!string.IsNullOrEmpty(className) && driver.WaitUntilVisible(By.ClassName(className), timeOut))
            {
                try
                {
                    element = driver.FindElements(By.ClassName(className));
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Elements with ClassName: {0} is missing", className);
                    _log.Error(e);
                }
            }
            return element;
        }
    }
}


