using OpenQA.Selenium;
using UITestDirect2.Core.Helpers;


namespace UITestDirect2.Core.Pages.Client_area
{
    public abstract class PageCommon : PageBase
    {
        public PageCommon(IWebDriver driver, string lng)
            : base(driver, lng)
        { }

        #region Header
        public IWebElement BtnMenuProfile
        {
            get { return FindElement(By.Id("dropdownMenuButtonProfile")); }
        }

            public IWebElement LnkMenuMyProfile
            {
                get { return FindElement(By.CssSelector("header#header>div>nav:nth-of-type(2)>ul>li>div")).FindElement(By.LinkText("My profile")); }
            }
            public IWebElement LnkMenuLogout
            {
                get { return FindElement(By.CssSelector("header#header>div>nav:nth-of-type(2)>ul>li>div")).FindElement(By.LinkText("Logout")); }
            }

        public IWebElement BtnMenuSettings
        {
            get { return FindElement(By.Id("dropdownMenuButtonSettings")); }
        }

        public IWebElement BtnNotification
        {
            get { return FindElement(By.Id("dropdownMenuButtonProfile")); }
        }

        public IWebElement LblFxProDirect
        {
            get { return FindElement(By.CssSelector("a.navbar-brand")); }
        }

        public IWebElement LnkAccounts
        {
            get { return FindElement(By.Id("nav_menu_item_accounts")); }
        }

        public IWebElement LnkWallet
        {
            get { return FindElement(By.Id("nav_menu_item_manage_funds")); }
        }

        public IWebElement LnkHistory
        {
            get { return FindElement(By.Id("nav_menu_item_history")); }
        }

        public IWebElement LnkProAcceptance
        {
            get
            {
                return Wait.ElementIsVisible(WebDriver, FindElement(By.Id("nav_menu_item_pro_acceptance")));
            }
        }

        public IWebElement LnkProReassessment
        {
            get { return FindElement(By.Id("nav_menu_item_pro_reassessment")); }
        }

        public IWebElement LnkFaq
        {
            get { return FindElement(By.Id("nav_menu_item_faq")); }
        }

        public IWebElement BtnQuickDeposit
        {
            get { return FindElement(By.Id("quick-deposit")); }
        }
        #endregion

        #region Footer
        public IWebElement LnkLiveChat
        {
            get { return FindElement(By.LinkText("Live chat")); }
        }

        public IWebElement LblRisk
        {
            get { return FindElement(By.CssSelector("#footer>div>div>div.col-lg-8>div")); }
        }

        public IWebElement LnkGetCall
        {
            get { return FindElement(By.LinkText("Get a Call")); }
        }
        #endregion
    }
}
