using Match.lib;
using OpenQA.Selenium;
using System.Configuration;

namespace Match.pageobjects
{
    public class Registration
    {
        private Generic generic;
        private IWebDriver driver;

        private By _IamA = By.CssSelector("SELECT#genderGenderSeek");
        private By _Zip = By.CssSelector("INPUT#postalCode");
        private By _Continue_1 = By.CssSelector("FORM#progessive>DIV.registerView>FIELDSET.active>BUTTON.button.button-progressive");
        private By _Continue_2 = By.CssSelector("FORM#progessive>DIV.registerView>FIELDSET.active>DIV.terms>BUTTON.button.button-progressive");
        private By _Continue_3 = By.CssSelector("DIV#submit>BUTTON.button.button-progressive");
        private By _Email = By.CssSelector("FORM#progessive>DIV.registerView>FIELDSET.active>DIV.email>INPUT");
        private By _Password = By.CssSelector("FORM#progessive>DIV.registerView>FIELDSET.active>DIV.password>INPUT");
        private By _Month = By.CssSelector("SELECT#birthMonth");
        private By _Day = By.CssSelector("SELECT#birthDay");
        private By _Year = By.CssSelector("SELECT#birthYear");
        private By _UserName = By.CssSelector("DIV#submit>INPUT");
        private By _Home = By.CssSelector("DIV#header-nav>DIV.nav-primary.nav-primary>DIV.matchLogo.icon>A");


        public Registration(IWebDriver browser)
        {
            this.driver = browser;
            generic = new Generic(this.driver);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["registration_url"]);
        }

        public void SelectPreference(string Preference, string Zip)
        {
            generic.SelectByText(_IamA, Preference);
            generic.EnterText(_Zip, Zip);
            generic.Click(_Continue_1);
        }

        public void EnterPersonelDetails(string Email, string Password, string Month, string Day, string Year, string Username)
        {
            generic.EnterText(_Email, Email);
            generic.Click(_Continue_1);
            generic.EnterText(_Password, Password);
            generic.SelectByText(_Month, Month);
            generic.SelectByText(_Day, Day);
            generic.SelectByText(_Year, Year);
            generic.Click(_Continue_2);
            generic.EnterText(_UserName, Username);
            generic.Click(_Continue_3);
        }

        public void NavigateToHome()
        {
            generic.Click(_Home);
        }
    }
}