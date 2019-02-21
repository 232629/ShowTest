using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Pages.Client_area;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Mena
    {
        [Test]
        [TestCase("en")]
        public void Footer(string lng)
        {
            #region Test Data 

            string login = "875584@testing.test";
            string pas = "Password1";

            #endregion

            PageLogin pageLogin = new PageLogin(webDriver, lng);
            Assert.AreEqual("Trade Responsibly: Trading CFDs involves significant risk of loss. Read FxPro\'s ‘Risk Disclosure Statement’. FxPro Global Markets MENA Limited is authorised and regulated by the Dubai Financial Services Authority (reference no. F003333).", pageLogin.LblRisk.Text);

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            Assert.AreEqual("Trade Responsibly: Trading CFDs involves significant risk of loss. Read FxPro\'s ‘Risk Disclosure Statement’. FxPro Global Markets MENA Limited is authorised and regulated by the Dubai Financial Services Authority (reference no. F003333).", pageTradingAccountsReal.LblRisk.Text);
            
        }
    }
}
