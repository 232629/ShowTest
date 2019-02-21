using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageLegalDocumentation : PageCommon
    {
        public PageLegalDocumentation(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/profile/downloads/legal-documentation";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\LegalDocumentation.jpg"; }
        }

        public IWebElement BtnClientAgreement 
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[0]; }
        }

        public IWebElement BtnClientAgreementAr
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[1]; }
        }

        public IWebElement BtnComplaintsHandlingProcedure
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[2]; }
        }

        public IWebElement BtnOrderExecutionPolicy
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[3]; }
        }

        public IWebElement BtnOrderExecutionPolicyAr
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[4]; }
        }

        public IWebElement BtnClientCategorisationNotice
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[5]; }
        }

        public IWebElement BtnConflictsOfInterestPolicy 
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[6]; }
        }

        public IWebElement BtnFxProWallet 
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[7]; }
        }

        public IWebElement BtnRiskDisclosure 
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[8]; }
        }

        public IWebElement BtnRiskDisclosureAr
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[9]; }
        }

        public IWebElement BtnRetailRiskDisclosure
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[10]; }
        }

        public IWebElement BtnTermsAndConditionsForFixedSpreadAccount 
        {
            get { return FindElements(By.CssSelector("a.btn.btn-green"))[11]; }
        }
    }
}
