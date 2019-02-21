using System;
using System.CodeDom;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITestDirect2.Core.Helpers;

namespace UITestDirect2.Core.Pages.Registration
{
    public abstract class PageCommon : PageBase
    {
        public PageCommon(IWebDriver driver, string lng)
            : base(driver, lng)
        { }

        #region Header
        public IWebElement BtnLng
        {
            get { return FindElement(By.CssSelector("language-switcher>div>ul")); }
        }

        public void ShowLngPanel()
        {
            BtnLng.Click();
            Wait.AttributeElementValue(WebDriver, WebDriver.FindElement(By.XPath("//*[@id='header']/div/nav/ul/li/language-switcher/div/ul/li")), "class", "dropdown show");
            Thread.Sleep(1100);
        }

        

        delegate int myDel(int i);
        
        static int FnkSum(int j)
        {
            return j + j;  
        }

        //static myDel mydlMyDel = new myDel(FnkSum);

        static myDel mydlMyDelSmp = i => FnkSum(i);

        //static myDel mydlMyDelSmp;
        private static myDel mydlMyDelSmp1 = i => { return i + i + i; };

        private int ff = mydlMyDelSmp.Invoke(6);

        private int ddd = mydlMyDelSmp(6);

        private int lll = mydlMyDelSmp1(2);








        public IWebElement BtnLngAr
        {
            get { return FindElement(By.Id("language-ar")); } 
        }

        public IWebElement BtnLngTh
        {
            get { return FindElement(By.Id("language-th")); }
        }

        public IWebElement BtnLngPt
        {
            get { return FindElement(By.Id("language-pt")); }
        }

        public IWebElement BtnLngRu
        {
            get { return FindElement(By.Id("language-ru")); }
        }

        public IWebElement BtnLngJa
        {
            get { return FindElement(By.Id("language-ja")); }
        }

        public IWebElement BtnLngVi
        {
            get { return FindElement(By.Id("language-vi")); }
        }

        public IWebElement BtnLngId
        {
            get { return FindElement(By.Id("language-id")); }
        }

        public IWebElement BtnLngMs
        {
            get { return FindElement(By.Id("language-ms")); }
        }

        public IWebElement BtnLngZh
        {
            get { return FindElement(By.Id("language-zh")); }
        }

        public IWebElement BtnLngEs
        {
            get { return FindElement(By.Id("language-es")); }
        }

        public IWebElement BtnLngKo
        {
            get { return FindElement(By.Id("language-ko")); }
        }

        public IWebElement BtnLngEn
        {
            get { return FindElement(By.Id("language-en")); }
        }

        public IWebElement BtnLngCs
        {
            get { return FindElement(By.Id("language-cs")); }
        }

        public IWebElement BtnLngClose
        {
            get { return FindElement(By.Id("close-language-list")); }
        }

        #endregion

        #region Footer

        public IWebElement LblRisk
        {
            get { return FindElement(By.CssSelector("#footer>div>div>div.col-lg-8>div")); }
        }

        private static myDel MydlMyDelSmp1 { get => mydlMyDelSmp1; set => mydlMyDelSmp1 = value; }

        #endregion
    }
}
