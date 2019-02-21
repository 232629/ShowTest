using OpenQA.Selenium;
using UITestDirect2.Core.Helpers;


namespace UITestDirect2.Core.Pages.Registration
{
    public class PageThankYou : PageCommon
    {
        public PageThankYou(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/register/thankyou";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\RegisterThankyou.jpg"; }
        }

        public IWebElement LnkContinueToFxPro
        {
            get { return FindElement(By.LinkText("")); }
        }
        
        public IWebElement LblWelcome
        {
            get
            {
                var el = FindElement(By.CssSelector("div.welcome-holder>h2"));
                Wait.ElementIsVisible(WebDriver, el);
                return el;
            }
        }
        

    }
}
