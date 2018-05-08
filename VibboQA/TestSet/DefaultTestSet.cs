using log4net;
using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using VibboQA.Drivers;

namespace VibboQA.TestSet
{

    public class DefaultTestSet
    {
        protected static IWebDriver driver;
        protected static Initialization config = Initialization.Instace;
        private static readonly ILog _log = LogManager.GetLogger(typeof(DefaultTestSet));
        private string _className;

        public DefaultTestSet()
        {
            BasicConfigurator.Configure();
            _className = GetType().Name;
        }

        [SetUp]
        protected void BeforeTest()
        {
            _log.InfoFormat("CLASS: {0}: [SetUp]- METHOD: BeforeTest() ---- Start", _className);
            driver = config.Init();
            _log.InfoFormat("CLASS: {0}: [SetUp]- METHOD: BeforeTest() ---- End", _className);
        }

        [TearDown]
        protected void AfterTest()
        {
            _log.InfoFormat("CLASS: {0}: [TearDown]- METHOD: AfterTest() ---- Start", _className);
            if (driver != null)
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Close();
            }
            _log.InfoFormat("CLASS: {0}: [TearDown]- METHOD: AfterTest() ---- End", _className);
        }

        protected void Wait(TimeSpan time)
        {
            Thread.Sleep(time);
        }
    }
}
