using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageFaq : PageCommon
    {
        public PageFaq(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/faq";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\faq.jpg"; }
        }

        public IWebElement LblVideo1
        {
            get { return FindElements(By.CssSelector("div.card"))[0]; }
        }

        public IWebElement AreaCloseVideo1
        {
            get { return FindElement(By.CssSelector("body.modal-open")); }
        }
       
        public IWebElement BtnCloseVideo1
        {
            get { return FindElement(By.Id("video-modal-0")).FindElement(By.CssSelector("button.close")); }
        }     


        public IWebElement LblVideo2
        {
            get { return FindElements(By.CssSelector("div.card"))[1]; }
        }

        public IWebElement BtnCloseVideo2
        {
            get { return FindElement(By.Id("video-modal-1")).FindElement(By.CssSelector("button.close")); }
        }

        public IWebElement LblVideo3
        {
            get { return FindElements(By.CssSelector("div.card"))[2]; }
        }

        public IWebElement BtnCloseVideo3
        {
            get { return FindElement(By.Id("video-modal-2")).FindElement(By.CssSelector("button.close")); }
        }

        public IWebElement LblVideo4
        {
            get { return FindElements(By.CssSelector("div.card"))[3]; }
        }

        public IWebElement BtnCloseVideo4
        {
            get { return FindElement(By.Id("video-modal-3")).FindElement(By.CssSelector("button.close")); }
        }


    }
}
