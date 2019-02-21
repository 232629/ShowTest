using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageWithdraw : PageCommon
    {
        public PageWithdraw(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/Withdraw";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\Withdraw.jpg"; }
        }
        public IWebElement LnkBack
        {
            get { return FindElement(By.Id("back-link")); }
        }

        public IWebElement LblHeader
        {
            get { return FindElement(By.CssSelector("ng-component > div > h2")); }
        }

        public IWebElement LblWarning
        {
            get { return FindElement(By.CssSelector("withdraw > div > div > p")); }
        }

    }
}
