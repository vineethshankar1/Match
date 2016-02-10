using Match.lib;
using NUnit.Framework;
using OpenQA.Selenium;
namespace Match.specs.ui
{
    public class UITestBase
    {
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Browser currentBrowser = new Browser();
            Driver = currentBrowser.LaunchBrowser();
        }

        [TearDown]
        public void Teardown()
        {
            Driver.Quit();
        }
    }
}
