using OpenQA.Selenium;
using UITestDirect2.Core.Helpers;

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageLogin : PageCommon
    {
        public PageLogin(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }
        
        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/login";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\Login.jpg"; }
        }

        public IWebElement LnkRegister
        {
            get { return FindElement(By.CssSelector("a#login-real-account.border-link")); }
        }

        public IWebElement TxtEmail
        {
            get { return FindElement(By.Id("login-input-email")); }
        }

        public IWebElement TxtPassword
        {
            get { return FindElement(By.Id("login-input-password")); }
        }

        public IWebElement ChkStaySignedIn

        {
            get { return FindElement(By.CssSelector("span.custom-control-indicator")); }
        }

        public IWebElement BtnLogin
        {
            get { return FindElement(By.Id("login-signin-button")); }
        }

        public IWebElement MsgError
        {
            get
            {
                var el = FindElement(By.CssSelector("div.text-danger"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

        public IWebElement LnkFogotPassword
        {
            get { return FindElement(By.CssSelector("div.restore-pass-block>a")); }
        }
        
    }
}
