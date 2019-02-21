 

using OpenQA.Selenium;

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageTradingAccountsDemo : PageTradingAccountsBase
    {
        public PageTradingAccountsDemo(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/accounts/demo";
            }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\AccountsDemo.jpg"; }
        }

    }
}
