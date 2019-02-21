using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageRegister : PageCommon
    {
        public PageRegister(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get { return BaseUrl + "/" + Language + "/register"; }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\register.jpg"; }
        }

        public IWebElement LnkLang
        {
            get { return FindElement(By.CssSelector("a.nav-link.dropdown-toggle")); }
        }

        public IWebElement LnkLogin
        {
            get { return FindElement(By.Id("login-real-account")); }
        }

        public IWebElement TxtEmail
        {
            get { return FindElement(By.Id("register-input-email")); }
        }

        public IWebElement TxtPassword
        {
            get { return FindElement(By.Id("input-password")); }
        }
        
        public IWebElement TxtFirstName
        {
            get { return FindElement(By.Id("input-first-name")); }
        }

        public IWebElement TxtLastName
        {
            get { return FindElement(By.Id("input-last-name")); }
        }

        public CustomSelectElement CmbCountry
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-country"))); }
        }

        public CustomSelectElement CmbRegulator
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-jurisdiction"))); }
        }

        public IWebElement BtnRegister
        {
            get { return FindElement(By.Id("submit-step-1")); }
        }

    }
}
