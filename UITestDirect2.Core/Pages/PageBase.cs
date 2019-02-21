using System;
using System.Collections.ObjectModel;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;

namespace UITestDirect2.Core.Pages
{
    public abstract class PageBase
    {
        private readonly IWebDriver webDriver;
        private static readonly string browser = ConfigurationManager.AppSettings["browser"];
        private static readonly string baseUrl = ConfigurationManager.AppSettings["serverAddress"];
        private static readonly string folderExpectedScreenShots = ConfigurationManager.AppSettings["folderExpectedScreenShots"];
        private string language;
        protected PageBase(IWebDriver driver, string lng = "en")
        {
            webDriver = driver;
            language = lng;
        }

        public bool WaitForAjaxScripts(int timeout = 10000)
        {
            return webDriver.WaitForAjaxScripts(timeout);
        }

        protected string Browser
        {
            get { return browser; }
        }

        public string BaseUrl
        {
            get { return baseUrl; }
        }

        protected string Language
        {
            get { return language; }
        }

        protected string FolderExpectedScreenShots
        {
            get { return folderExpectedScreenShots; }
        }

        protected internal IWebDriver WebDriver
        {
            get { return webDriver; }
        }

        public abstract string ExpectedUrl { get; }

        public abstract string ExpectedTitle { get; }

        public abstract string ScreenShot { get; }

        protected IWebElement FindElement(By by)
        {
            return Wait.ElementIsVisible(WebDriver, WebDriver.FindElement(by)); ;
        }

        protected ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return webDriver.FindElements(by);
        }

        public void GoToPage(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public void GoToBack()
        {
            webDriver.Navigate().Back();
        }
        
        public IAlert PopUpAlert
        {
            get { return webDriver.SwitchTo().Alert(); }
        }

    }
}
