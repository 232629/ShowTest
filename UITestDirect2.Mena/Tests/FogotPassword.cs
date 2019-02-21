using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Mena
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        [TestCase("en")]
        public void FogotPassword(string lng)
        {
            #region Test Data

            var goodLogin = "544189@testing.test";
            var badLogin = "bad@bad.bad";

            #endregion

            PageLogin pageLogin = new PageLogin(webDriver, lng);
            pageLogin.LnkFogotPassword.Click();

            PageFogetPassword pageFogetPassword = new PageFogetPassword(webDriver, lng);
            pageFogetPassword.TxtEmail.SendKeys(badLogin);
            pageFogetPassword.BtnResetPassword.Click();
            Assert.AreEqual(@"Profile not exists. Check your email", pageFogetPassword.LblError.Text);

            pageFogetPassword.TxtEmail.Clear();
            pageFogetPassword.TxtEmail.SendKeys(goodLogin);
            pageFogetPassword.BtnResetPassword.Click();

            PageForgotPasswordThanks pageForgotPasswordThanks = new PageForgotPasswordThanks(webDriver, lng);
            Wait.TextToBePresentInElement(
                webDriver, 
                pageForgotPasswordThanks.LblThankyou, 
                "Thank you!\r\nAn email containing a link to resetting your password has been sent. Please check your mail and follow the instructions to restore password.");
            pageForgotPasswordThanks.BtnClose.Click();

            Wait.UrlContains(webDriver, pageLogin.ExpectedUrl);

        }
    }
}
