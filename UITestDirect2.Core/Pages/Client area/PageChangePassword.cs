using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageChangePassword : PageCommon
    {
        public PageChangePassword(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/profile/password";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ProfilePassword.jpg"; }
        }

        public IWebElement TxtCurrentPassword
        {
            get { return FindElement(By.Id("input-current-password")); }
        }

        public IWebElement TxtNewPassword
        {
            get { return FindElement(By.Id("input-new-password")); }
        }

        public IWebElement TxtRepeatPassword
        {
            get { return FindElement(By.Id("input-confirm-password")); }
        }

        public IWebElement BtnChange
        {
            get { return FindElement(By.CssSelector("button.btn-green.arrow.btn")); }
        }

    }
}
