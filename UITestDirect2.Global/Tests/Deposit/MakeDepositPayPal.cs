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
        //[Ignore("wait fast reg")]
        [TestCase("en")]
        public void MakeDepositPayPal(string lng)
        {
            #region Test Data 

            string login = "209810@testing.test";
            string pas = "Password1";
            var currencies = new[] { "EUR", "GBP", "USD", "PLN", "JPY", "AUD", "CHF" };

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnQuickDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);

            pageDeposit.BtnPayPal.Click();
            
            PageDepositPayPal pageDepositPayPal = new PageDepositPayPal(webDriver, lng);

            pageDepositPayPal.CmbTradingAccountNumber.SetValueAfterClick(0);
            pageDepositPayPal.CmbCurrency.GetValuesList().Should().BeEquivalentTo(currencies);
            pageDepositPayPal.CmbCurrency.SetValueAfterClick(new Random().Next(currencies.Length));
            pageDepositPayPal.TxtSendAmount.SendKeys("10000");

            pageDepositPayPal.BtnDeposit.Click();

            //redirect to PayPal
            //pageDepositPayPal.WaitLoadNoAngularPage(@"https://www.sandbox.paypal.com/");
         
        }
    }
}
