using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages.Client_area;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Uk
    {
        /// <summary>
        /// Login by Spain user, without the spanish acknowledge.
        /// Redirect to /regulatory-disclaimer.
        /// </summary>  
        [Test]
        //[Retry(3)]
        [TestCase("en")]
        [Description("Login by Spain user, without the spanish acknowledge")]
        //[Parallelizable(ParallelScope.Self)]
        public void LoginSpain(string lng)
        {

            #region Test Data 

            string login = "024590@testing.test";
            string pass = "Password1";

            #endregion

            LoginHelper.Login(webDriver, lng, login, pass);

            PageRegulatoryDisclaimer pageRegulatoryDisclaimer = new PageRegulatoryDisclaimer(webDriver, lng);
            Wait.UrlContains(webDriver, pageRegulatoryDisclaimer.ExpectedUrl);

        }
    }
}
