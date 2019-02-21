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
        [Description("https://fxpropm.atlassian.net/wiki/spaces/BA/pages/141590603/Amount+limits+per+payment+method")]
        [TestCase("en")]
        public void MakeDepositIngenico(string lng)
        {
            #region Test Data 

            string login = "209810@testing.test";
            string pas = "Password1";
            var currencies = new[] {"EUR", "GBP", "USD", "PLN", "JPY", "AUD", "CHF"};

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMakeFirstDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);

            pageDeposit.BtnIngenico.Click();
            
            PageDepositIngenico pageDepositIngenico = new PageDepositIngenico(webDriver, lng);

            pageDepositIngenico.CmbTradingAccountNumber.SetValueAfterClick(0);
            pageDepositIngenico.CmbCurrency.GetValuesList().Should().BeEquivalentTo(currencies);
            pageDepositIngenico.CmbCurrency.SetValueAfterClick(new Random().Next(currencies.Length));
            pageDepositIngenico.TxtSendAmount.SendKeys("10000");

            pageDepositIngenico.BtnDeposit.Click();

            //redirect to Ingenico
            //pageDepositIngenico.WaitLoadNoAngularPage(@"https://payment.pay1.preprod.secured-by-ingenico.com/checkout/select-payment-product/");
            
        }
    }
}
