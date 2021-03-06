﻿using System;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VibboQA.Drivers
{
    public static class DriverExtensions
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(DriverExtensions));

        public static bool Wait(this IWebDriver driver, By selector, TimeSpan time)
        {            
            WebDriverWait w = new WebDriverWait(driver, time);
            bool elementExist = true;

            try
            {
                w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(selector));
            }
            catch (Exception e)
            {
                _log.ErrorFormat("The element: {0} is missing in the DOM. Waiting time: {1}", selector, time);
                _log.Error(e);
                elementExist = false;
            }            
            return elementExist;
        }

        public static bool WaitUntilVisible(this IWebDriver driver, By selector, TimeSpan time)
        {            
            WebDriverWait w = new WebDriverWait(driver, time);
            bool elementExist = true;

            try
            {
                w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(selector));
            }
            catch (Exception e)
            {
                _log.ErrorFormat("The element: {0} is not visible in the page. Waiting time: {1}", selector, time);
                _log.Error(e);
                elementExist = false;
            }            
            return elementExist;
        }
    }
}
