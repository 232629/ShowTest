using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageDepositNganLuong : PageDepositProviderBase
    {
        public PageDepositNganLuong(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/wallet/deposit/nganluong";
            }
        }
        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\WalletDepositNganLuong.jpg"; }
        }

        public CustomSelectElement CmbPaymentMethod
        {
            get { return new CustomSelectElement(FindElement(By.Id("payment-method"))); }
        }

        public CustomSelectElement CmbBankCode
        {
            get { return new CustomSelectElement(FindElement(By.Name("bank-code"))); }
        }

    }
}
