using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageFogetPassword : PageCommon
    {
        public PageFogetPassword(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/login/forgot-password/email";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\LoginForgot-passwordEmail.jpg"; }
        }

        public IWebElement TxtEmail
        {
            get { return FindElement(By.CssSelector("input#input-email")); }
        }

        public IWebElement BtnResetPassword
        {
            get { return FindElement(By.Id("reset-password-button")); }
        }

        public IWebElement LblError
        {
            get { return FindElement(By.CssSelector("#forgot-password-form > fieldset > div > div.text-danger")); }
        }

        public IWebElement BtnClose
        {
            get { return FindElement(By.CssSelector("a.close")); }
        }

    }
}
