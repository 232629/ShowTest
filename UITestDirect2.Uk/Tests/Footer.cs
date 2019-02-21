using System;
using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages.Client_area;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Uk
    {
        [Test]
        [TestCase("en")]
        //[Parallelizable(ParallelScope.None)]
        public void Footer(string lng)
        {
            #region Test Data 

            string login = "153828@testing.test";
            string pas = "Password1";

            #endregion

            PageLogin pageLogin = new PageLogin(webDriver, lng);
            Assert.AreEqual("Trade Responsibly CFDs and Spread Betting are complex instruments and come with a high risk of losing money rapidly due to leverage. 79% of retail investor accounts lose money when trading CFDs and Spread Betting with this provider. You should consider whether you understand how CFDs and Spread Betting work and whether you can afford to take the high risk of losing your money. FxPro UK Limited is authorised and regulated by the Financial Conduct Authority (registration № 509956).", pageLogin.LblRisk.Text);

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            Assert.AreEqual("Trade Responsibly CFDs and Spread Betting are complex instruments and come with a high risk of losing money rapidly due to leverage. 79% of retail investor accounts lose money when trading CFDs and Spread Betting with this provider. You should consider whether you understand how CFDs and Spread Betting work and whether you can afford to take the high risk of losing your money. FxPro UK Limited is authorised and regulated by the Financial Conduct Authority (registration № 509956).", pageTradingAccountsReal.LblRisk.Text);

        }
    }
}
