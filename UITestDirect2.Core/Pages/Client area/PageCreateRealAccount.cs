using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageCreateRealAccount : PageCommon
    {
        public PageCreateRealAccount(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/accounts/real/create";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\AccountsRealCreate.jpg"; }
        }

        public CustomSelectElement CmbSelectAccountType
        {
            get { return new CustomSelectElement(FindElement(By.CssSelector("ng-select#select-account-type"))); }
        }

        public CustomSelectElement CmbSelectLeverage
        {
            get { return new CustomSelectElement(FindElement(By.CssSelector("ng-select#select-leverage"))); }
        }

        public CustomSelectElement CmbSelectCurrencyBase
        {
            get { return new CustomSelectElement(FindElement(By.CssSelector("ng-select#select-currency-base"))); }
        }

        public CustomSelectElement CmbSelectPartnership
        {
            get { return new CustomSelectElement(FindElement(By.CssSelector("ng-select#select-partnership"))); }
        }

        public IWebElement BtnCreate
        {
            get { return FindElement(By.CssSelector("button.btn-green.arrow.btn")); }
        }

        public IWebElement LnkBack
        {
            get { return FindElement(By.LinkText("Back")); }
        }

    }
}
