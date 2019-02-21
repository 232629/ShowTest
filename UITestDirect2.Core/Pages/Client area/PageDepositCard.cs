using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageDepositCard : PageCommon
    {
        public PageDepositCard(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/transactions/deposit/card";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\TransactionsDepositCard.jpg"; }
        }

        public CustomSelectElement CmbTradingAccountNumber
        {
            get { return new CustomSelectElement(FindElement(By.Id("account-number"))); }
        }

        public IWebElement BtnHint
        {
            get { return FindElement(By.Id("dropdownMenuButton")); }
        }
        
        public IWebElement TxtCardNumber
        {
            get { return FindElement(By.Id("card-number")); }
        }

        public IWebElement TxtCardName
        {
            get { return FindElement(By.Id("card-name")); }
        }

        public CustomSelectElement CmbMonth
        {
            get { return new CustomSelectElement(FindElement(By.Id("expiry-month"))); }
        }

        public CustomSelectElement CmbYear
        {
            get { return new CustomSelectElement(FindElement(By.Id("expiry-year"))); }
        }

        public CustomSelectElement CmbCountry
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-country"))); }
        }

        public IWebElement TxtAmount
        {
            get { return FindElement(By.Id("amount")); }
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
    }
}
