using System.Threading;
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
        [Ignore("Disabled")]
        [TestCase("en")]
        public void MakeDepositPaysec(string lng)
        {
            #region Test Data 

            string login = "826061@testing.test";
            string pas = "Password1";
            var currencies = new[] {"THB"};

            #endregion
            
            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMakeFirstDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);

            pageDeposit.BtnPaysec.Click();
            
            PageDepositPaysec pageDepositPaysec = new PageDepositPaysec(webDriver, lng);

            pageDepositPaysec.CmbTradingAccountNumber.SetValueAfterClick(0);
            pageDepositPaysec.CmbCurrency.SetValueAfterClick(0);
            pageDepositPaysec.TxtSendAmount.SendKeys("3000");

            pageDepositPaysec.BtnDeposit.Click();

            //redirect to Paysec
            Thread.Sleep(10000);
            //Assert.IsTrue(webDriver.Url.Contains(@"https://sandbox.zotapay.com/paynet/processor/"));
            
        }
    }
}
