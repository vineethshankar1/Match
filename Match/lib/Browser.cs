using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;

namespace Match.lib
{
    public class Browser
    {
        public IWebDriver Driver;

        public IWebDriver LaunchBrowser()
        {
            switch (ConfigurationManager.AppSettings["target_browser"].ToLower())
            {
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;

            }
            Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(600));
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(600));
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["base_url"]);
            return Driver;
        }
    }
}
