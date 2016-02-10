using Match.lib;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Match.pageobjects
{
    public class MyMatch
    {
        private Generic generic;
        private IWebDriver driver;

        private By _Welcome = By.CssSelector("DIV#header-secondary>DIV.notificationBar.nav-secondary>SPAN.welcomeMsg");
        private By _SearchFor = By.CssSelector("SELECT#ggs");
        private By _SearchAge = By.CssSelector("SELECT#lAge");
        private By _SearchUpperAge = By.CssSelector("SELECT#uAge");
        private By _Distance = By.CssSelector("INPUT#dist");
        private By _Zip = By.CssSelector("INPUT#pc");
        private By _SearchNow = By.CssSelector("FORM#quick-search>FIELDSET>DIV.s-submit>BUTTON.ui-submit.button.button-primary");


        public MyMatch(IWebDriver browser)
        {
            this.driver = browser;
            generic = new Generic(this.driver);
        }

        public void AssertWelcomeMessage(string UserName)
        {
            if (generic.WaitForElement(_Welcome).Text.IndexOf(UserName.Substring(0, 14)) != -1)
            {
                Assert.Pass("welcome message with user name is displayed");
            }
            else
            {
                Assert.Fail("welcome message with user name is not displayed");
            }
        }

        public void SearchMatches(string LookingFor, string Age, string UpperAge, string Distance, string Zip)
        {
            generic.SelectByText(_SearchFor, LookingFor);
            generic.SelectByText(_SearchAge, Age);
            generic.SelectByText(_SearchUpperAge, UpperAge);
            generic.EnterText(_Distance, Distance);
            generic.EnterText(_Zip, Zip);
            generic.Click(_SearchNow);
        }
    }
}
