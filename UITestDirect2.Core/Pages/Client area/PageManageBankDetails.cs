using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageManageBankDetails : PageCommon
    {
        public PageManageBankDetails(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/bank/details";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ManageBankDetails.jpg"; }
        }

        public IWebElement TxtBankName
        {
            get { return FindElement(By.Id("input-bank-name")); }
        }

        public IWebElement TxtBankAddress
        {
            get { return FindElement(By.Id("input-bank-address")); }
        }

        public IWebElement TxtAccountName
        {
            get { return FindElement(By.Id("input-account-name")); }
        }

        public CustomSelectElement CmbCurrency
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-account-currency"))); }
        }

        public IWebElement TxtIban
        {
            get { return FindElement(By.Id("input-account-iban")); }
        }

        public IWebElement TxtBic
        {
            get { return FindElement(By.Id("input-account-swift")); }
        }

        public IWebElement BtnSave
        {
            get { return FindElement(By.Id("create-detail-btn")); }
        }

        public IWebElement LnkBack
        {
            get { return FindElement(By.Id("back-link")); }
        }
    }
}
