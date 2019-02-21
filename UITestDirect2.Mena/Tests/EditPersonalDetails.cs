using NUnit.Framework;
using OpenQA.Selenium;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Pages.Client_area;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Mena
    {
        [Test]
        [Description("Testing Edit Personal Details")]
        [TestCase("en")]
        public void EditPersonalDetails(string lng)
        {
            #region Test Data 

            string login = "875584@testing.test";
            string pas = "Password1";

            #endregion

            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMenuProfile.Click();
            pageTradingAccountsReal.LnkMenuMyProfile.Click();
            
            PageProfile pageProfile = new PageProfile(webDriver, lng);
            //pageTradingAccountsReal.WaitLoadPage(pageProfile);
            pageProfile.LnkEditPersonalDetails.Click();
            PageEditPersonalDetails pageEditPersonalDetails = new PageEditPersonalDetails(webDriver, lng);
            //pageEditPersonalDetails.WaitLoadPage(pageEditPersonalDetails);
            //check and save old values
            Assert.AreEqual("TestNameUAE", pageEditPersonalDetails.TxtFirstName.GetAttribute("value"));
            Assert.AreEqual("TestLastNameUAE", pageEditPersonalDetails.TxtLastName.GetAttribute("value"));
            Assert.AreEqual("+971-50-000-0000", pageEditPersonalDetails.TxtPhone.GetAttribute("value"));
            pageEditPersonalDetails.BtnSave.Click();
            //pageTradingAccountsReal.WaitLoadPage(pageProfile);

            pageProfile.LnkEditPersonalDetails.Click();
            //check old values
            Assert.AreEqual("TestNameUAE", pageEditPersonalDetails.TxtFirstName.GetAttribute("value"));
            Assert.AreEqual("TestLastNameUAE", pageEditPersonalDetails.TxtLastName.GetAttribute("value"));
            Assert.AreEqual("+971-50-000-0000", pageEditPersonalDetails.TxtPhone.GetAttribute("value"));

            //input new values
            pageEditPersonalDetails.TxtFirstName.Clear();
            pageEditPersonalDetails.TxtFirstName.SendKeys("newTestNameUAE");
            pageEditPersonalDetails.TxtLastName.Clear();
            pageEditPersonalDetails.TxtLastName.SendKeys("newTestLastNameUAE");
            pageEditPersonalDetails.TxtPhone.Clear();
            pageEditPersonalDetails.TxtPhone.SendKeys("+971-50-000-0001");
            pageEditPersonalDetails.BtnSave.Click();

            //check successfully message
            //pageTradingAccountsReal.WaitLoadPage(pageTradingAccountsReal);
            Assert.AreEqual("Your request was successfully received. We will review it and let you know about the results. If it is necessary, we will contact you for details.", pageTradingAccountsReal.MsgSuccess.Text);

            pageTradingAccountsReal.BtnMenuProfile.Click();
            pageTradingAccountsReal.LnkMenuMyProfile.Click();
            pageProfile.LnkEditPersonalDetails.Click();
            //pageEditPersonalDetails.WaitLoadPage(pageEditPersonalDetails);
            //check new values
            Assert.AreEqual("TestNameUAE", pageEditPersonalDetails.TxtFirstName.GetAttribute("value"));
            Assert.AreEqual("TestLastNameUAE", pageEditPersonalDetails.TxtLastName.GetAttribute("value"));
            Assert.AreEqual("+971-50-000-0000", pageEditPersonalDetails.TxtPhone.GetAttribute("value"));

        }
    }
}
