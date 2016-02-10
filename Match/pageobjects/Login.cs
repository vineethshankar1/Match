using Match.lib;
using OpenQA.Selenium;
using System.Configuration;

namespace Match.pageobjects
{
    public class Login
    {
        private Generic generic;
        private IWebDriver driver;

        private By _Welcome = By.CssSelector("DIV#header-secondary>DIV.notificationBar.nav-secondary>SPAN.welcomeMsg");
        private By _Email = By.CssSelector("INPUT#email");
        private By _Password = By.CssSelector("INPUT#password");
        private By _SignIn = By.CssSelector("DIV#app>DIV.app-container>DIV.content>DIV.row-fluid>SECTION.col-7>DIV.panel.form>DIV.panel-body>FORM.form>FIELDSET>BUTTON.btn.btn-primary.btn-large");
        private By _SignOut = By.CssSelector("A#ctl00_matchHeader_ctl00_PrimaryNavigationRepeater1_ctl09_Repeater1_ctl03_HyperLink4");


        public Login(IWebDriver browser)
        {
            this.driver = browser;
            generic = new Generic(this.driver);
            this.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["login_url"]);
        }

        public bool MatchLogin(string UserName, string Password)
        {
            generic.EnterText(_Email, UserName);
            generic.EnterText(_Password, Password);
            generic.Click(_SignIn);
            if (generic.WaitForElement(_Welcome).Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SignOut()
        {
            generic.Click(_SignOut);
        }
    }
}
