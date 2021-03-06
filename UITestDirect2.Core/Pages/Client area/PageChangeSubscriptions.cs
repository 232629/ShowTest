﻿using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageChangeSubscriptions : PageCommon
    {
        public PageChangeSubscriptions(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/profile/subscriptions";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\ProfileSubscriptions.jpg"; }
        }

        public IWebElement ChkCompanyNews
        {
            get { return FindElement(By.CssSelector("label#label-subscription-news>span.custom-control-indicator")); }
        }

        public IWebElement ChkDailyTechnicalAnalysis
        {
            get { return FindElement(By.CssSelector("label#label-subscription-analysis>span.custom-control-indicator")); }
        }

        public IWebElement BtnSave
        {
            get { return FindElement(By.CssSelector("button.btn-green.arrow.btn")); }
        }

    }
}
