using OpenQA.Selenium;
using UITestDirect2.Core.Helpers;


namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageWallet : PageCommon
    {
        public PageWallet(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/wallet";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\Wallet.jpg"; }
        }

        public IWebElement BtnDeposit
        {
            get
            {
                var el = FindElement(By.CssSelector("div.transaction-type > div > div:nth-child(1) > a"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

        public IWebElement BtnTransfer
        {
            get
            {
                var el = FindElement(By.CssSelector("div.transaction-type > div > div:nth-child(2) > a"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

        public IWebElement BtnWithdrawal
        {
            get
            {
                var el = FindElement(By.CssSelector("div.transaction-type > div > div:nth-child(3) > div"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

    }
}
