using Match.lib;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Configuration;

namespace Match.pageobjects
{
    public class Fav
    {
        private Generic generic;
        private IWebDriver driver;

        private By _FavRadio = By.CssSelector("FORM#list-page>DIV.list-nav-actions>LABEL>DIV.radio>SPAN>INPUT.radio.ui-click");
        private By _FavCard = By.CssSelector("DIV#tab-cnt-fave>DIV.cards.clr>DIV.card");
        private By _CardsCtrl = By.CssSelector("DIV#tab-cnt-fave>DIV.cards.clr");
        private By _SortBy = By.CssSelector("SELECT#sb");

        public Fav(IWebDriver browser)
        {
            this.driver = browser;
            generic = new Generic(this.driver);
            this.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["fav_url"]);
        }

        private void SelectMyFav()
        {
            this.driver.FindElements(_FavRadio)[0].Click();
        }

        public void VerifyAddedFavCard(string UserName)
        {
            generic.WaitForElementExists(_CardsCtrl);
            SelectMyFav();
            // need to replace with a generic browser sync handling async stuff
            System.Threading.Thread.Sleep(2000);
            IList<IWebElement> cards = this.driver.FindElements(_FavCard);
            foreach (IWebElement card in cards)
            {
                if (card.Text.ToLower().IndexOf(UserName.ToLower()) != -1)
                {
                    Assert.Pass("User " + UserName + " added to my favs");
                    return;
                }
            }
            Assert.Fail("User " + UserName + " not added to my favs");
        }
    }
}
