using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageDepositBankWire : PageCommon
    {
        public PageDepositBankWire(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/wallet/deposit/bankwire";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\WalletDepositBankwire.jpg"; }
        }

        public CustomSelectElement CmbAccountNumber
        {
            get { return new CustomSelectElement(FindElement(By.Id("account-number"))); }
        }

        public CustomSelectElement CmbCountry
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-country"))); }
        }

        public CustomSelectElement CmbBank
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-bank"))); }
        }

        public CustomSelectElement CmbCurrency
        {
            get { return new CustomSelectElement(FindElement(By.Id("currency"))); }
        }

        public IWebElement BtnGetTransferDetails
        {
            get { return FindElement(By.Id("deposit-submit")); }
        }

        public IWebElement LnkBack
        {
            get { return FindElement(By.Id("back-link")); }
        }
    }
}
