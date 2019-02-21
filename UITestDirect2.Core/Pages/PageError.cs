using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageError : PageBase
    {
        public PageError(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/error";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\error.jpg"; }
        }

        public IWebElement LblErrorText
        {
            get { return FindElement(By.CssSelector("div.text-holder > div.error-text")); }
        }
       
        public IWebElement BtnHomePage
        {
            get { return FindElement(By.Id("home-page-link")); }
        }

        public IWebElement BtnLogin
        {
            get { return FindElement(By.Id("login-page-link")); }
        }

    }
}
