using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageDepositMyBitWallet : PageDepositProviderBase
    {
        public PageDepositMyBitWallet(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/wallet/deposit/mybitwallet";
            }
        }
        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\WalletDepositMyBitWallet.jpg"; }
        }
        public IWebElement TxtEmail
        {
            get { return FindElement(By.Id("deposit-email")); }
        }

    }
}
