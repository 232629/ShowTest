using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageProDocuments : PageCommon
    {
        public PageProDocuments(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/pro-documents";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\pro-documents.jpg"; }
        }

        public IWebElement LblHeader
        {
            get { return FindElement(By.CssSelector("ng-component > div > div > h2")); }
        }

    }
}
