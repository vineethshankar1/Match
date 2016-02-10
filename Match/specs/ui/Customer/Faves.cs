using Match.pageobjects;
using NUnit.Framework;
using System;
using System.Configuration;

namespace Match.specs.ui.Customer
{
    public class Faves : UITestBase
    {
        [Test, Description("Add a user to faves")]
        [Category("UI")]
        public void AddUserToFav()
        {
            Login login = new Login(Driver);
            Assert.True(login.MatchLogin(ConfigurationManager.AppSettings["login_email"], "asdf1234"));
            MyMatch myMatch = new MyMatch(Driver);
            Random r = new Random();
            string DynamicZip = "2820" + r.Next(1, 9).ToString();
            myMatch.SearchMatches("I am a MAN looking for WOMEN", "25", "35", "100", DynamicZip);
            Search mySearch = new Search(Driver);
            mySearch.AddRandomUserToFav();
            Fav myFav = new Fav(Driver);
            myFav.VerifyAddedFavCard(mySearch.SelectedUserName);
            login.SignOut();
        }
    }
}
