using OpenQA.Selenium;
using UITestDirect2.Core.Helpers;


namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageClosedAccount : PageBase
    {
        public PageClosedAccount(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/closed-account";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ClosedAccount.jpg"; }
        }

        public IWebElement LblHader
        {
            get
            {
                var el = FindElement(By.CssSelector("div.col-lg-6>h2"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

        public IWebElement LblBody
        {
            get
            {
                var el = FindElement(By.CssSelector("div.col-lg-6>div"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

        public IWebElement LnkLogout
        {
            get { return FindElement(By.CssSelector("a.border-link")); }
        }


    }
}
