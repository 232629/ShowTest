using OpenQA.Selenium;
using UITestDirect2.Core.Helpers;


namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageUploadDocuments : PageCommon
    {
        public PageUploadDocuments(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/profile/documents";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ProfileDocuments.jpg"; }
        }

        public IWebElement BtnIdCardOrPassport
        {
            get
            {
                var el = FindElement(By.Id("label-id-card"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

        public IWebElement BtnIdCardBack
        {
            get
            {
                var el = FindElement(By.Id("label-id-card-back"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

        public IWebElement BtnProofOfResidence
        {
            get
            {
                var el = FindElement(By.Id("label-residence-proof"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }

        public IWebElement LnkBack
        {
            get { return FindElement(By.LinkText("")); }
        }

    }
}
