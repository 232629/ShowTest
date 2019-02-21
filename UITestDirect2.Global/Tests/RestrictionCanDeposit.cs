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
        [Description("ERP: Can Deposit = No")]
        [TestCase("en")]
        public void RestrictionCanDeposit(string lng)
        {
            #region Test Data 

            string login = "cy374571@testing.test";
            string pas = "Password1";

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnQuickDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);
            pageDeposit.BtnIngenico.Click();
            
            PageDepositIngenico pageDepositIngenico = new PageDepositIngenico(webDriver, lng);
            Assert.AreEqual("Dear Client,\r\n\r\nYou're unable to make a deposit at the moment. Please make sure you provided all necessary documents for profile verification. If your profile is already verified and the issue persists please contact our customer support for assistance.", pageDepositIngenico.LblWarning.Text);
            
        }
    }
}
