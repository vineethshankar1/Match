using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Match.lib
{
    public class Generic
    {
        private int GlobalTimeout = 120;
        private IWebDriver Driver;

        public Generic(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitForElementVisible(By by)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(GlobalTimeout)).Until(ExpectedConditions.ElementIsVisible((by)));
        }

        public void WaitForElementExists(By by)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(GlobalTimeout)).Until(ExpectedConditions.ElementExists((by)));
        }

        public void EnterText(By by, string Value)
        {
            WaitForElementExists(by);
            WaitForElementVisible(by);
            Driver.FindElement(by).Clear();
            Driver.FindElement(by).SendKeys(Value);
        }

        public void Click(By by)
        {
            WaitForElementExists(by);
            WaitForElementVisible(by);
            Driver.FindElement(by).Click();

        }

        public IWebElement WaitForElement(By by)
        {
            WaitForElementExists(by);
            WaitForElementVisible(by);
            return Driver.FindElement(by);
        }

        public void SelectByText(By by, string value)
        {
            WaitForElementExists(by);
            WaitForElementVisible(by);
            new SelectElement(Driver.FindElement(by)).SelectByText(value);
        }
    }
}
