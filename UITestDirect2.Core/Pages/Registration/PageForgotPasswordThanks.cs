using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageForgotPasswordThanks : PageCommon
    {
        public PageForgotPasswordThanks(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/forgot-password/thanks";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ForgotPasswordThanks.jpg"; }
        }

        public IWebElement LblThankyou
        {
            get { return FindElement(By.CssSelector("div.login-form-title")); }
        }

        public IWebElement BtnClose
        {
            get { return FindElement(By.CssSelector("a.close")); }
        }

    }
}
