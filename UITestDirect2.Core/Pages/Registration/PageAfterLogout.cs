 

using OpenQA.Selenium;

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageAfterLogout : PageCommon
    {
        public PageAfterLogout(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/after-logout";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\AfterLogout.jpg"; }
        }       

    }
}
