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
        public void MakeDepositMyBitWallet(string lng)
        {
            #region Test Data 

            string login = "jp182841@testing.test";
            string pas = "Password1";
            var currencies = new[] { "EUR", "USD", "JPY" };

            #endregion
            
            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMakeFirstDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);

            pageDeposit.BtnMyBitWallet.Click();
            
            PageDepositMyBitWallet pageDepositMyBitWallet = new PageDepositMyBitWallet(webDriver, lng);

            pageDepositMyBitWallet.CmbTradingAccountNumber.SetValueAfterClick(0);
            pageDepositMyBitWallet.CmbCurrency.GetValuesList().Should().BeEquivalentTo(currencies);
            pageDepositMyBitWallet.TxtEmail.SendKeys("a.komukhin@fxpro.com");
            pageDepositMyBitWallet.CmbCurrency.SetValueAfterClick(new Random().Next(currencies.Length));
            pageDepositMyBitWallet.TxtSendAmount.SendKeys("5000");

            pageDepositMyBitWallet.BtnDeposit.Click();

            //redirect to MyBitWallet
            //pageDepositMyBitWallet.WaitLoadNoAngularPage(@"https://devsecure.bitwallet.com/merchant/signin");
            
        }
    }
}
