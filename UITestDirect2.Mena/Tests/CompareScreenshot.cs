using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Mena
    {
        /// <summary>
        /// </summary>
        [Test]
        [Ignore("not finished")]
        [TestCase("en")]
        [TestCase("ar")]
        [Description("")]

        public void CompareScreenshot(string lng)
        {
            #region Test Data

            #endregion
            PageLogin pageLogin = new PageLogin(webDriver, lng);
            Assert.AreEqual(pageLogin.ExpectedUrl, webDriver.Url);
            //webDriver.WaitForAngular();
            AssertHelper.AssertScreenShot(webDriver, pageLogin.ScreenShot, 0);

            //LoginHelper.Login(webDriver, lng);
            //PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            //AssertHelper.AssertScreenShot(webDriver, pageTradingAccountsReal.ScreenShot, 3);

        }

    }



}
