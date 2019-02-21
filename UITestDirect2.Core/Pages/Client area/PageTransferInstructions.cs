using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageTransferInstructions : PageCommon
    {
        public PageTransferInstructions(IWebDriver driver, string lng = "en")
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
            get { return FolderExpectedScreenShots + "\\" + Language + "\\TransferInstructions.jpg"; }
        }

        public IWebElement LblName(int i)
        {
            return FindElement(By.CssSelector("div.bankwire-receipt")).FindElements(By.TagName("dt"))[i];
        }

        public IWebElement LblValue(int i)
        {
            return FindElement(By.CssSelector("div.bankwire-receipt")).FindElements(By.TagName("dd"))[i];
        }


        public IWebElement BtnPrint
        {
            get { return FindElement(By.Id("print-btn")); }
        }

    }
}
