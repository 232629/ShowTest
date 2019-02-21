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
        public void MakeDepositSkrill(string lng)
        {
            #region Test Data 

            string login = "209810@testing.test";
            string pas = "Password1";
            var currencies = new[] { "EUR", "GBP", "USD", "PLN", "JPY", "CHF" };

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMakeFirstDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);

            pageDeposit.BtnSkrill.Click();
            
            PageDepositSkrill pageDepositSkrill = new PageDepositSkrill(webDriver, lng);

            pageDepositSkrill.CmbTradingAccountNumber.SetValueAfterClick(0);
            pageDepositSkrill.CmbCurrency.GetValuesList().Should().BeEquivalentTo(currencies);
            pageDepositSkrill.CmbCurrency.SetValueAfterClick(new Random().Next(currencies.Length));
            pageDepositSkrill.TxtSendAmount.SendKeys("10000");

            pageDepositSkrill.BtnDeposit.Click();

            //redirect to Skrill
            //pageDepositSkrill.WaitLoadNoAngularPage("https://pay.skrill.com/");
            
        }
    }
}
