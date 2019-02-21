using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageRegulatoryDisclaimer : PageCommon
    {
        public PageRegulatoryDisclaimer(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/regulatory-disclaimer";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\RegulatoryDisclaimer.jpg"; }
        }
        
        public IWebElement LblDisclaimer
        {
            get { return FindElement(By.CssSelector("")); }
        }
        
        public IWebElement TxtText
        {
            get { return FindElement(By.Id("client-text")); }
        }

        public IWebElement BtnClickToCopy
        {
            get { return FindElement(By.Id("copy-btn")); }
        }
        public IWebElement BtnContinue
        {
            get { return FindElement(By.Id("submit-btn")); }
        }

    }
}
