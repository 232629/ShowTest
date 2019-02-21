using System;
using System.Threading;
using FluentAssertions;
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
        [Description("ERP: Can Withdraw = No")]
        [TestCase("en")]
        public void RestrictionCanWithdraw(string lng)
        {
            #region Test Data 

            string login = "cy374571@testing.test";
            string pas = "Password1";

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.LnkWallet.Click();

            PageWallet pageWallet = new PageWallet(webDriver, lng);
            pageWallet.BtnWithdrawal.Click();

            PageWithdraw pageWithdraw = new PageWithdraw(webDriver, lng);

            Assert.AreEqual("Dear Client,\r\n\r\nYou're unable to make a withdrawal at the moment. Please make sure you provided all necessary documents for profile verification. If your profile is already verified and the issue persists please contact our customer support for assistance.", pageWithdraw.LblWarning.Text);

        }
    }
}
