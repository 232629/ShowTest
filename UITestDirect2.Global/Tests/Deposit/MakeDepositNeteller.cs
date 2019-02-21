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
        public void MakeDepositNeteller(string lng)
        {
            #region Test Data 

            string login = "209810@testing.test";
            string pas = "Password1";
            var currencies = new[] { "EUR", "GBP", "USD", "PLN", "JPY", "AUD" };

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMakeFirstDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);

            pageDeposit.BtnNeteller.Click();
            
            PageDepositNeteller pageDepositNeteller = new PageDepositNeteller(webDriver, lng);

            pageDepositNeteller.CmbTradingAccountNumber.SetValueAfterClick(0);
            pageDepositNeteller.CmbCurrency.GetValuesList().Should().BeEquivalentTo(currencies);
            pageDepositNeteller.CmbCurrency.SetValueAfterClick(new Random().Next(currencies.Length));
            pageDepositNeteller.TxtSendAmount.SendKeys("3000");

            pageDepositNeteller.BtnDeposit.Click();

            //redirect to Neteller
            //pageDepositNeteller.WaitLoadNoAngularPage(@"https://test.api.neteller.com");
            
        }
    }
}
