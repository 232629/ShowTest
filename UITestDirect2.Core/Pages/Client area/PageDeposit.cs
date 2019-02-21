using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageDeposit : PageCommon
    {
        public PageDeposit(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/wallet/deposit";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\WalletDeposit.jpg"; }
        }

        public IWebElement BtnBankwire
        {
            get {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("bankwire"))
                        return btn;
                }
                return null;
            }
        }

        public IWebElement BtnIngenico
        {
            get
            {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("ingenico"))
                        return btn;
                }
                return null;
            }
        }

        public IWebElement BtnZotapay
        {
            get
            {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("zotapay"))
                        return btn;
                }
                return null;
            }
        }

        public IWebElement BtnPaysec
        {
            get
            {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("paysec"))
                        return btn;
                }
                return null;
            }
        }

        public IWebElement BtnPayPal
        {
            get
            {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("paypal"))
                        return btn;
                }
                return null;
            }
        }

        public IWebElement BtnNeteller
        {
            get
            {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("neteller"))
                        return btn;
                }
                return null;
            }
        }

        public IWebElement BtnNganLuong
        {
            get
            {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("nganluong"))
                        return btn;
                }
                return null;
            }
        }

        public IWebElement BtnSkrill
        {
            get
            {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("skrill"))
                        return btn;
                }
                return null;
            }
        }

        public IWebElement BtnTft
        {
            get
            {
                return (FindElements(By.CssSelector("a.method.deposit-row")))[0];
            }
        }

        public IWebElement BtnMyBitWallet
        {
            get
            {
                foreach (var btn in FindElements(By.CssSelector("a.method.deposit-row")))
                {
                    if (btn.GetAttribute("href").Contains("mybitwallet"))
                        return btn;
                }
                return null;
            }
        }



    }
}
