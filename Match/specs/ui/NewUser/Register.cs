using Match.pageobjects;
using NUnit.Framework;
using System;
namespace Match.specs.ui.NewUser
{
    public class Register : UITestBase
    {
        public string CustomerId;
        public string EmailAddress;

        [TestFixtureSetUp]
        public void Init()
        {
            CustomerId = "matchdemo" + DateTime.Now.Ticks.ToString();
            EmailAddress = "vineeth" + DateTime.Now.Ticks.ToString() + "@gmail.com";
            Console.WriteLine("current email address:" + EmailAddress);
        }

        [Test, Description("Register as a new customer")]
        [Category("UI")]
        public void RegisterNewCustomer()
        {
            Registration reg = new Registration(Driver);
            reg.Navigate();
            reg.SelectPreference("Man seeking a Woman", "28201");
            reg.EnterPersonelDetails(EmailAddress, "asdf1234", "Jan", "1", "1985", CustomerId);
            reg.NavigateToHome();
            MyMatch myMatch = new MyMatch(Driver);
            myMatch.AssertWelcomeMessage(CustomerId);
        }
    }
}
