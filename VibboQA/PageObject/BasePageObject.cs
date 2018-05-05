using System;
using log4net;
using log4net.Config;
using OpenQA.Selenium;
using VibboQA.Drivers;

namespace VibboQA.PageObject
{
    public class BasePageObject
    {
        protected IWebDriver driver;
        protected TimeSpan DefaultTimeOut = new TimeSpan(0, 0, 20);
        private static readonly ILog _log = LogManager.GetLogger(typeof(BasePageObject));

        public BasePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement GetElementById(String key, TimeSpan timeOut)
        {
            IWebElement element = null;

            if (!string.IsNullOrEmpty(key) && driver.WaitUntilVisible(By.Id(key), timeOut))
            {
                try
                {
                    element = driver.FindElement(By.Id(key));
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("Element with id: {0} is missing", key);
                    _log.Error(e);
                }
            }
            return element;
        }

        public IWebElement GetElementByName(String name, TimeSpan timeOut)
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
    }
}
