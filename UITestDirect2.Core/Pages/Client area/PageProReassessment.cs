using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageProReassessment : PageCommon
    {
        public PageProReassessment(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/pro-reassessment";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\pro-reassessment.jpg"; }
        }

        public IWebElement LblHeader
        {
            get { return FindElement(By.CssSelector("ng-component > div > div > h2")); }
        }

        /// <summary>
        /// The size of your financial instruments portfolio, defined as including cash deposits and financial instruments, exceeds $500000
        /// </summary>
        public IWebElement ChkQuestion1
        {
            get { return FindElement(By.CssSelector("label.custom-checkbox[for=question-0]")); }
        }

        /// <summary>
        /// You have carried out transactions, in significant size, on the relevant market at an average frequency of 10 per quarter over the previous four quarters (with FxPro or other providers)
        /// </summary>
        public IWebElement ChkQuestion2
        {
            get { return FindElement(By.CssSelector("label.custom-checkbox[for=question-1]")); }
        }

        /// <summary>
        /// You work or have worked in the financial sector for at least one year in a professional position, which requires knowledge of the transactions or services envisaged
        /// </summary>
        public IWebElement ChkQuestion3
        {
            get { return FindElement(By.CssSelector("label.custom-checkbox[for=question-2]")); }
        }


        public IWebElement BtnProceed
        {
            get { return FindElement(By.Id("submit-reassessment")); }
        }

        public IWebElement LnkBack
        {
            get { return FindElement(By.Id("back-link")); }
        }

    }
}
