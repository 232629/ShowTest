using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageRregisterStep3 : PageCommon
    {
        public PageRregisterStep3(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/register/step3";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\registerStep3.jpg"; }
        }

        public CustomSelectElement CmbAccountType
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-account-type"))); }
        }

        public CustomSelectElement CmbLeverage
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-leverage"))); }
        }

        public CustomSelectElement CmbCurrencyBase
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-currency-base"))); }
        }
        
        public IWebElement BtnProClientInterestedYes
        {
            get { return FindElement(By.CssSelector("label#label-pro_client_interested-yes")); }
        }

        public IWebElement BtnProClientInterestedNo
        {
            get { return FindElement(By.CssSelector("label#label-pro_client_interested-no")); }
        }

        /// <summary>
        /// Verify your profile now? YES
        /// </summary>
        public IWebElement BtnVerifyYourProfileYes
        {
            get { return FindElement(By.Id("label-verify_profile-yes")); }
        }

        /// <summary>
        /// Verify your profile now? NO
        /// </summary>
        public IWebElement BtnVerifyYourProfileNo
        {
            get { return FindElement(By.Id("label-verify_profile-no")); }
        }

        public CustomCheckboxElement ChkReceiveCompanyNews
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=subscription-news]"))); }
        }

        public CustomCheckboxElement ChkReceiveTechnicalAnalysis
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=subscription-analysis]"))); }
        }

        public CustomSelectElement CmbLanguage
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-preferred-language"))); }
        }

        public CustomCheckboxElement ChkAcceptRisks
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=risk-aware]"))); }
        }
        public IWebElement LblSubmissionRiskAwareness
        {
            get { return FindElement(By.CssSelector("label#label-risk-aware>span.custom-control-description")); }
        }

        public CustomCheckboxElement ChkClientAgreement
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=terms-conditions]"))); }
        }
        public IWebElement LblSubmissionTermsConditions
        {
            get { return FindElement(By.CssSelector("label#label-terms-conditions>span.custom-control-description")); }
        }

        public IWebElement BtnPreviousStep
        {
            get { return FindElement(By.Id("back-step-4")); }
        }

        public IWebElement BtnComplete
        {
            get { return FindElement(By.Id("submit-step-4")); }
        }

    }
}
