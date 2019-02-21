using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageProAcceptance : PageCommon
    {
        public PageProAcceptance(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/pro-acceptance";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\pro-acceptance.jpg"; }
        }

        public IWebElement LblHeader
        {
            get { return FindElement(By.CssSelector("ng-component > div > div > h2")); }
        }

        /// <summary>
        /// I hereby acknowledge this content I understand the benefits I will keep and those I will lose due to my re-categorisation from a retail client to a professional client.
        /// </summary>
        public IWebElement ChkAcknowledgementRecategorisation
        {
            get { return FindElement(By.CssSelector("label.custom-checkbox[for=question-0]")); } // get { return Wait.ElementIsVisible(WebDriver, FindElement(By.CssSelector("label.custom-checkbox[for=question-0]"))); }
        }

        public IWebElement BtnProceed
        {
            get { return FindElement(By.Id("submit-acceptance")); }
        }

        public IWebElement LnkBack
        {
            get { return FindElement(By.Id("back-link")); }
        }
    }
}
