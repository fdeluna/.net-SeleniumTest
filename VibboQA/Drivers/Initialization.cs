using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using static VibboQA.Drivers.DriverExtensions;

namespace VibboQA.Drivers
{
    public class Initialization
    {
        public enum BrowserName { CHROME, FIREFOX, MICROSOFTEDGE };
        public enum OS { WINDOWS, LINUX, MACOS };

        public static Initialization Instace
        {
            get
            {
                if (_instance == null)
                    _instance = new Initialization();
                return _instance;
            }
        }
        private static Initialization _instance = null;

        private IWebDriver _driver;
        private BrowserName _browserName;
        private OS _os;
        private string _url;
        private static readonly ILog _log = LogManager.GetLogger(typeof(Initialization));



        private Initialization()
        {
            _url = ConfigurationManager.AppSettings["url"];
            _browserName = (BrowserName)Enum.Parse(typeof(BrowserName), ConfigurationManager.AppSettings["browserName"]);
            _os = (OS)Enum.Parse(typeof(OS), ConfigurationManager.AppSettings["os"]);
        }

        public IWebDriver Init()
        {
            switch (_browserName)
            {
                case BrowserName.CHROME:
                    ChromeOptions chromeOptions = new ChromeOptions();

                    chromeOptions.AddArgument("--user-agent=Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 66.0.3359.139 Safari / 537.36");

                    _driver = new ChromeDriver(chromeOptions);
                    break;
                case BrowserName.FIREFOX:
                    _driver = new FirefoxDriver();
                    break;
                case BrowserName.MICROSOFTEDGE:
                    _driver = new EdgeDriver();
                    break;
            }

            _driver.Manage().Window.FullScreen();
            _driver.Url = _url;

            return _driver;
        }
    }
}
