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
        [Ignore("https://fxpropm.atlassian.net/browse/DUI-1254")]
        [TestCase("en")]
        public void MakeDepositTFTpay(string lng)
        {
            #region Test Data 

            string login = "ch050947@testing.test";
            string pas = "Password1";

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnQuickDeposit.Click();
            
            PageDeposit pageDeposit = new PageDeposit(webDriver, lng);
            pageDeposit.BtnTft.Click();
            
            #region redirect to Tft
            var mainWindow = webDriver.CurrentWindowHandle;
            bool popupShown = false;
            foreach (var window in webDriver.WindowHandles)
            {
                if (webDriver.SwitchTo().Window(window).Url == @"http://47.98.123.57:8080/fxpro/toView")
                {
                    webDriver.Close();
                    popupShown = true;
                    break;
                }
            }
            Assert.IsTrue(popupShown, "Pop up wasn't shown.");
            #endregion

            webDriver.SwitchTo().Window(mainWindow);
            //pageDeposit.WaitLoadPage();
        }
    }
}
