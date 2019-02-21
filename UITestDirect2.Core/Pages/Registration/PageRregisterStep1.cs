using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageRregisterStep1 : PageCommon
    {
        public PageRregisterStep1(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/register/step1";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\registerStep1.jpg"; }
        }

        public string UsedBrowser
        {
            get { return Browser; }
        }

        public IWebElement TxtAddress
        {
            get { return FindElement(By.Id("input-address")); }
        }

        public IWebElement TxtPostcode
        {
            get { return FindElement(By.Id("input-postcode")); }
        }
        
        public IWebElement TxtCity
        {
            get { return FindElement(By.Id("input-town")); }
        }

        /// <summary>
        /// Only for FCA (country: UK)
        /// </summary>
        public IWebElement TxtStreetName
        {
            get { return FindElement(By.Id("input-street_name")); }
        }
        
        /// <summary>
        /// Only for FCA (country: UK)
        /// </summary>
        public IWebElement TxtState
        {
            get { return FindElement(By.Id("input-state_province")); }
        }
        
        /// <summary>
        /// Only for FCA (country: UK)
        /// </summary>
        public IWebElement TxtYearMoved
        {
            get { return FindElement(By.Id("input-move_year")); }
        }
        
        /// <summary>
        /// Only for FCA (country: UK)
        /// </summary>
        public IWebElement TxtMiddleInitial
        {
            get { return FindElement(By.Id("input-middle_initial")); }
        }
        
        /// <summary>
        /// Only for FCA (country: UK)
        /// </summary>
        public IWebElement TxtMothersName
        {
            get { return FindElement(By.Id("input-maiden_name")); }
        }
        

        /// <summary>
        /// Field Emirate uses only by United Arab Emirates
        /// </summary>
        public CustomSelectElement CmbEmirate
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-emirate"))); }
        }

        public IWebElement TxtBirthdate
        {
            get { return FindElement(By.CssSelector("input[name = birthdate]")); }
        }

        public IWebElement TxtPhone
        {
            get { return FindElement(By.Id("input-phone")); }
        }

        /// <summary>
        /// Field QQ uses only by China
        /// </summary>
        public IWebElement TxtQq
        {
            get { return FindElement(By.Id("input-qq")); }
        }
        /// <summary>
        /// Field CmbChanneLearnAboutFxPro use only by China
        /// </summary>
        public CustomSelectElement CmbChanneLearnAboutFxPro
        {
            get { return new CustomSelectElement(FindElement(By.Id(""))); }
        }

        public CustomSelectElement CmbNationality
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-nationality"))); }
        }

        public IWebElement BtnNexStep
        {
            get { return FindElement(By.Id("submit-step-2")); }
        }

    }
}
