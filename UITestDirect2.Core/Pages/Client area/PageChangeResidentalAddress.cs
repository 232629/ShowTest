using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageChangeResidentalAddress : PageCommon
    {
        public PageChangeResidentalAddress(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/profile/address";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ProfileAddress.jpg"; }
        }

        public IWebElement TxtStreetNumber
        {
            get { return FindElement(By.Id("input-street_number")); }
        }

        public IWebElement TxtPostCode
        {
            get { return FindElement(By.Id("input-postcode")); }
        }

        public IWebElement TxtCity
        {
            get { return FindElement(By.Id("input-town")); }
        }

        public IWebElement TxStreetName
        {
            get { return FindElement(By.Id("input-street_name")); }
        }

        public IWebElement TxtState
        {
            get { return FindElement(By.Id("input-state_province")); }
        }

        public IWebElement TxtMovedToCurrentAddress
        {
            get { return FindElement(By.Id("input-move_year")); }
        }

        public IWebElement BtnSave
        {
            get { return FindElement(By.CssSelector("button.btn-green.arrow.btn")); }
        }

    }
}
