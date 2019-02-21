using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public abstract class PageTradingAccountsBase : PageCommon
    {
        public PageTradingAccountsBase(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public IWebElement LnkMyAccount
        {
            get { return FindElement(By.LinkText("My account")); }
        }

        public IWebElement LnkManageFunds
        {
            get { return FindElement(By.LinkText("Manage funds")); }
        }

        public IWebElement LnkPartners
        {
            get { return FindElement(By.LinkText("Partners")); }
        }

        public IWebElement LnkTradingAccounts
        {
            get { return FindElement(By.LinkText("Trading Accounts")); }
        }

        public IWebElement LnkDemoAccounts
        {
            get { return FindElement(By.LinkText("Demo Accounts")); }
        }

        public IWebElement MsgSuccess
        {
            get { return FindElement(By.CssSelector("div.ui-messages.ui-widget.ui-corner-all.ui-messages-success")); }
        }
        
        public IWebElement LnkCreateNewAccount
        {
            get { return FindElement(By.Id("create-account")); }
        }

        public IWebElement BtnUploadYourDocuments
        {
            get { return FindElement(By.Id("upload-doc-btn")); }                             
        }

        public IWebElement BtnCheckYourDocuments
        {
            get { return FindElement(By.Id("check-doc-btn")); }
        }

        public IWebElement BtnMakeFirstDeposit
        {
            get { return FindElement(By.Id("make-deposit-btn")); }                            
        }

    }
}
