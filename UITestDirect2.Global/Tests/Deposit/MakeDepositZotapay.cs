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
        [TestCase("en")]
        public void MakeDepositZotapay(string lng)
        {
            #region Test Data 

            string login = "209810@testing.test";
            string pas = "Password1";
            var currencies = new[] { "VND" };

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMakeFirstDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);

            pageDeposit.BtnZotapay.Click();
            
            PageDepositZotapay pageDepositZotapay = new PageDepositZotapay(webDriver, lng);

            pageDepositZotapay.CmbTradingAccountNumber.SetValueAfterClick(0);
            pageDepositZotapay.CmbCurrency.GetValuesList().Should().BeEquivalentTo(currencies);
            pageDepositZotapay.CmbCurrency.SetValueAfterClick(new Random().Next(currencies.Length));
            pageDepositZotapay.TxtSendAmount.SendKeys("2000000");

            pageDepositZotapay.BtnDeposit.Click();

            //redirect to Zotapay
            //pageDepositZotapay.WaitLoadNoAngularPage(@"https://sandbox.zotapay.com/paynet/");
            
        }
    }
}
