using Match.lib;
using OpenQA.Selenium;
using System;

namespace Match.pageobjects
{
    public class Search
    {
        private Generic generic;
        private IWebDriver driver;

        public string SelectedUserName { get; set; }

        private By _Card = By.CssSelector("DIV#form-search-results>DIV.results>DIV.card");
        private By _UserName = By.CssSelector("DL>DD.card-bio>A");
        private By _AddUser = By.CssSelector("DIV.card-actions>A.button.button-primary");

        public Search(IWebDriver browser)
        {
            this.driver = browser;
            generic = new Generic(this.driver);
        }

        private IWebElement GetRandomUserCard()
        {
            Random r = new Random();
            return this.driver.FindElements(_Card)[r.Next(1, 12)]; ;
        }

        private string GetUserName(IWebElement Card)
        {
            return Card.FindElement(_UserName).GetAttribute("title");
        }

        private void AddUserToFav(IWebElement Card)
        {
            Card.FindElement(_AddUser).Click();
        }

        public void AddRandomUserToFav()
        {
            IWebElement currentCard = GetRandomUserCard();
            SelectedUserName = GetUserName(currentCard);
            AddUserToFav(currentCard);

        }
    }
}
