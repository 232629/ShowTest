using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageEditPersonalDetails : PageCommon
    {
        public PageEditPersonalDetails(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/profile/details";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ProfileDetails.jpg"; }
        }

        public IWebElement TxtFirstName
        {
            get { return FindElement(By.Id("input-first-name")); }
        }

        public IWebElement TxtLastName
        {
            get { return FindElement(By.Id("input-last-name")); }
        }

        public IWebElement TxtPhone
        {
            get { return FindElement(By.Id("input-phone")); }
        }

        public IWebElement BtnSave
        {
            get { return FindElement(By.CssSelector("button.btn-green.arrow.btn")); }
        }

    }
}
