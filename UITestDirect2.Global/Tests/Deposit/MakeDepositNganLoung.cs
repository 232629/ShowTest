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
        [TestCase("en", "NganLuong wallet")]
        [TestCase("en", "Internet banking")]
        [TestCase("en", "ATM Online")]
        public void MakeDepositNganLuong(string lng, string paymentMethod)
        {
            #region Test Data 

            string login = "209810@testing.test";
            string pas = "Password1";
            var currencies = new[] { "VND" };
            var bankCodesIB = new[] { "Vietcombank", "DongA Bank", "Techcombank", "BIDV", "ACB", "VietinBank" };
            var bankCodesATM = new[] { "ACB", "Vietcombank", "DongA Bank", "Techcombank", "Military JSC Bank", "VIB", "VietinBank", "Eximbank", "HDBank", "MariTimeBank", "NaviBank", "VietA Bank", "VPBank", "Sacombank", "GPBank", "Agribank", "BIDV", "OceanBank", "PGBank", "SHB", "TienPhong Bank", "Nam A Bank", "Saigon Bank", "Bac A Bank" };

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMakeFirstDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);

            pageDeposit.BtnNganLuong.Click();
            
            PageDepositNganLuong pageDepositNganLuong = new PageDepositNganLuong(webDriver, lng);

            pageDepositNganLuong.CmbTradingAccountNumber.SetValueAfterClick(0);
            pageDepositNganLuong.CmbCurrency.GetValuesList().Should().BeEquivalentTo(currencies);
            pageDepositNganLuong.CmbCurrency.SetValueAfterClick(new Random().Next(currencies.Length));

            if (paymentMethod == "ATM Online")
            {
                pageDepositNganLuong.CmbPaymentMethod.SetValueAfterClick("ATM Online");
                pageDepositNganLuong.CmbBankCode.GetValuesList().Should().BeEquivalentTo(bankCodesATM);
                pageDepositNganLuong.CmbBankCode.SetValueAfterClick(new Random().Next(bankCodesATM.Length));
            }

            if (paymentMethod == "Internet banking")
            {
                pageDepositNganLuong.CmbPaymentMethod.SetValueAfterClick("Internet banking");
                pageDepositNganLuong.CmbBankCode.GetValuesList().Should().BeEquivalentTo(bankCodesIB);
                pageDepositNganLuong.CmbBankCode.SetValueAfterClick(new Random().Next(bankCodesIB.Length));
            }

            if (paymentMethod == "NganLuong wallet")
                pageDepositNganLuong.CmbPaymentMethod.SetValueAfterClick("NganLuong wallet");

            pageDepositNganLuong.TxtSendAmount.SendKeys("2000000");

            pageDepositNganLuong.BtnDeposit.Click();

            //redirect to NganLuong
            //pageDepositNganLuong.WaitLoadNoAngularPage(@"https://sandbox.nganluong.vn:8088/");
            
        }
    }
}
