using System;
using FluentAssertions;
using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Pages.Client_area;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Mena
    {
        [Test]
        [TestCase("en")]
        public void BankTransferDeposit(string lng)
        {
            #region Test Data 

            string login = "839469@testing.test";
            string pas = "Password1";
            var currencies = new[] { "GBP", "USD" };

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnQuickDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);
            pageDeposit.BtnBankwire.Click();

            PageDepositBankWire pageDepositBankWire = new PageDepositBankWire(webDriver, lng);
            pageDepositBankWire.CmbAccountNumber.SetValueAfterClick(0);
            pageDepositBankWire.CmbBank.SetValueAfterClick("Emirates NBD");
            pageDepositBankWire.CmbCurrency.GetValuesList().Should().BeEquivalentTo(currencies);
            pageDepositBankWire.CmbCurrency.SetValueAfterClick(new Random().Next(currencies.Length));
            var currency = pageDepositBankWire.CmbCurrency.GetValue();
            pageDepositBankWire.BtnGetTransferDetails.Click();

            PageTransferInstructions pageTransferInstructions = new PageTransferInstructions(webDriver, lng);
            
            Assert.AreEqual("Beneficiary name", pageTransferInstructions.LblName(0).Text);
            Assert.AreEqual("Benificiary bank name", pageTransferInstructions.LblName(1).Text);
            Assert.AreEqual("Bank address", pageTransferInstructions.LblName(2).Text);
            Assert.AreEqual("SWIFT/BIC", pageTransferInstructions.LblName(3).Text);
            Assert.AreEqual("IBAN", pageTransferInstructions.LblName(4).Text);
            Assert.AreEqual("Payment details", pageTransferInstructions.LblName(5).Text);
            Assert.AreEqual("Currency", pageTransferInstructions.LblName(6).Text);

            Assert.AreEqual("FxPro Global Markets MENA Limited", pageTransferInstructions.LblValue(0).Text);
            Assert.AreEqual("Emirates NBD", pageTransferInstructions.LblValue(1).Text);
            Assert.AreEqual("P.O. Box 777 Baniyas Road, Dubai United Arab Emirates", pageTransferInstructions.LblValue(2).Text);
            Assert.AreEqual("EBILAEADXXX", pageTransferInstructions.LblValue(3).Text);
            Assert.IsTrue(pageTransferInstructions.LblValue(5).Text.Contains("FXPRO WALLET NUMBER:"));
            Assert.AreEqual(currency, pageTransferInstructions.LblValue(6).Text);

        }
    }
}
