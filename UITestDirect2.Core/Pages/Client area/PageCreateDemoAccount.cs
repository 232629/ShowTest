using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageCreateDemoAccount : PageCommon
    {
        public PageCreateDemoAccount(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/accounts/demo/create";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\AccountsDemoCreate.jpg"; }
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

        public IWebElement TxtAmount
        {
            get { return FindElement(By.Id("amount")); }
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
