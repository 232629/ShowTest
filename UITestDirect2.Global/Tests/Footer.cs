using System.Threading;
using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages.Client_area;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Global
    {
        [Test]
        [TestCase("en")]
        public void Footer(string lng)
        {
            #region Test Data 

            string login = "209810@testing.test";
            string pas = "Password1";
            var currencies = new[] {"THB"};

            #endregion

            PageLogin pageLogin = new PageLogin(webDriver, lng);
            Assert.AreEqual("Trade Responsibly: Trading CFDs involves significant risk of loss. Read FxPro\'s ‘Risk Disclosure Statement’. FxPro Global Markets Ltd is regulated by the SCB (license no. SIA-F184) and is part of FxPro Group Limited. Other subsidiaries of FxPro Group Limited are regulated by the CySEC, FCA and DFSA.", pageLogin.LblRisk.Text);

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            Assert.AreEqual("Trade Responsibly: Trading CFDs involves significant risk of loss. Read FxPro\'s ‘Risk Disclosure Statement’. FxPro Global Markets Ltd is regulated by the SCB (license no. SIA-F184) and is part of FxPro Group Limited. Other subsidiaries of FxPro Group Limited are regulated by the CySEC, FCA and DFSA.", pageTradingAccountsReal.LblRisk.Text);

        }
    }
}
