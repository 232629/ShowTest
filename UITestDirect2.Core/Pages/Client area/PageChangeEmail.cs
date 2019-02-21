using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageChangeEmail : PageCommon
    {
        public PageChangeEmail(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/profile/email";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ProfileEmail.jpg"; }
        }

        public IWebElement TxtStreetNumber
        {
            get { return FindElement(By.Id("input-street_number")); }
        }

        public IWebElement TxtEmail
        {
            get { return FindElement(By.Id("input-email")); }
        }

        public IWebElement BtnConfirm
        {
            get { return FindElement(By.CssSelector("button.btn-green.arrow.btn")); }
        }

    }
}
