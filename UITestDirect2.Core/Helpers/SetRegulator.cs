using System.Threading;
using OpenQA.Selenium;
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2.Core.Helpers
{
    public static class SetRegulator
    {
        public static void Set(IWebDriver webDriver, string baseUrl, string regulator)
        {
            switch (regulator.ToLower())
            {
                case "fca":
                    webDriver.Navigate().GoToUrl(baseUrl + "/en/register?c=cy&j=fca");
                    break;

                case "mena":
                    webDriver.Navigate().GoToUrl(baseUrl + "/en/register?c=sa&j=mena");
                    break;

                case "scb":
                    webDriver.Navigate().GoToUrl(baseUrl + "/en/register?c=cy&j=gm");
                    break;

                case "cysec":
                    webDriver.Navigate().GoToUrl(baseUrl + "/en/register?c=cy&j=cysec");
                    break;

                default:
                    Log.Error("Regulator was not set.");
                    break;
            }
            
            PageRegister pageRegister = new PageRegister(webDriver);
            Wait.ElementIsVisible(webDriver, pageRegister.LnkLogin);
            Thread.Sleep(4000);
            pageRegister.LnkLogin.Click();
            PageLogin pageLogin = new PageLogin(webDriver);
            Wait.UrlMatches(webDriver, pageLogin.ExpectedUrl);
            Thread.Sleep(4000);

        }

    }

}
       

