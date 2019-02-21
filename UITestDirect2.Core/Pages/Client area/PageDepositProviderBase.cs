using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Client_area
{
    public abstract class PageDepositProviderBase : PageCommon
    {
        public PageDepositProviderBase(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public CustomSelectElement CmbTradingAccountNumber
        {
            get { return new CustomSelectElement(FindElement(By.Id("account-number"))); }
        }

        public IWebElement TxtConvertedAmount
        {
            get { return FindElement(By.Id("amountToReceive")); }
        }
        
        public IWebElement TxtSendAmount
        {
            get { return FindElement(By.Id("amountToSend")); }
        }

        public IWebElement LblMinimum
        {
            get { return FindElement(By.CssSelector("div:nth-child(1) > div > strong > span")); }
        }

        public IWebElement LblMaximum
        {
            get { return FindElement(By.CssSelector("div:nth-child(2) > div > strong > span")); }
        }

        public CustomSelectElement CmbCurrency
        {
            get { return new CustomSelectElement(FindElement(By.Id("currency"))); }
        }

        public IWebElement BtnDeposit
        {
            get { return FindElement(By.Id("deposit-submit")); }
        }

        public IWebElement LnkBack
        {
            get { return FindElement(By.Id("back-link")); }
        }
        
        public IWebElement LblHeader
        {
            get { return FindElement(By.CssSelector("deposit-form > h2")); }
        }


        public IWebElement LblWarning
        {
            get { return FindElement(By.CssSelector("deposit-form > div > p")); }
        }


    }
}
