using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Pages.Client_area;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Mena
    {
        /// <summary>
        /// https://fxpropm.atlassian.net/wiki/spaces/BA/pages/106233857/Supported+Trading+Account+Types+and+Currencies+Int
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="lng"></param>
        [Test]
        [Ignore("Fast registration is broken")]
        [TestCase("MT4", "en")]
        [TestCase("MT5", "en")]
        [TestCase("cTrader", "en")]
        public void CreateRealAccount(string accountType, string lng)
        {
            #region Test Data

            List <string> CurrencyList = new List<string>();
            switch (accountType)
            {
                case "MT4":
                    CurrencyList.Add("EUR");
                    CurrencyList.Add("GBP");
                    CurrencyList.Add("USD");
                    break;
                case "MT5":
                    CurrencyList.Add("EUR");
                    CurrencyList.Add("GBP");
                    CurrencyList.Add("USD");
                    break;
                case "cTrader":
                    CurrencyList.Add("EUR");
                    CurrencyList.Add("GBP");
                    CurrencyList.Add("USD");
                    break;
                default:
                    break;
            }

            #endregion

            LoginHelper.Login(webDriver, lng);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            PageCreateRealAccount pageCreateRealAccount = new PageCreateRealAccount(webDriver, lng); 
            
            for (int i = 0; i < CurrencyList.Count; i++)
            {
                pageTradingAccountsReal.LnkCreateNewAccount.Click();
                pageCreateRealAccount.CmbSelectAccountType.SetValueAfterClick(accountType);
                pageCreateRealAccount.CmbSelectLeverage.SetValueAfterClick(0);
                //checking currencies' list
                pageCreateRealAccount.CmbSelectCurrencyBase.GetValuesList().Should().BeEquivalentTo(CurrencyList);
                pageCreateRealAccount.CmbSelectCurrencyBase.SetValueAfterClick(i);
                pageCreateRealAccount.BtnCreate.Click();
                Thread.Sleep(3000);
            }
        }
    }
}