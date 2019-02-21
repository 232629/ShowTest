using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Pages.Client_area;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Mena
    {
        [Test]
        [TestCase("en")]
        public void LegalDocumentation(string lng)
        {
            #region Test Data 

            string login = "875584@testing.test";
            string pas = "Password1";

            #endregion

            //Create user 
            LoginHelper.Login(webDriver, lng, login, pas);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.BtnMenuProfile.Click();
            pageTradingAccountsReal.LnkMenuMyProfile.Click();
            
            PageProfile pageProfile = new PageProfile(webDriver, lng);
            pageProfile.LnkLegalDocumentation.Click();

            PageLegalDocumentation pageLegalDocumentation = new PageLegalDocumentation(webDriver, lng);

            pageLegalDocumentation.BtnClientAgreement.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Client_Agreement.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnClientAgreementAr.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Client_Agreement_ar.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnComplaintsHandlingProcedure.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Complaints_Handling_Procedure.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnOrderExecutionPolicy.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Order_Execution_Policy.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnOrderExecutionPolicyAr.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Order_Execution_Policy_ar.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnClientCategorisationNotice.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Client_Categorisation_Notice.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnConflictsOfInterestPolicy.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Conflict_of_Interest_Policy.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnFxProWallet.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/FxPro_Wallet.pdf");
            pageLegalDocumentation.GoToBack(); 
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnRiskDisclosure.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Risk_Disclosure_Notice.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnRiskDisclosureAr.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Risk_Disclosure_Notice_ar.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnRetailRiskDisclosure.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Retail_FX_Risk_Disclosure_Statement.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

            pageLegalDocumentation.BtnTermsAndConditionsForFixedSpreadAccount.Click();
            Wait.UrlContains(webDriver, @"https://s3.eu-central-1.amazonaws.com/files-mrkt/datarepo/legal/mena/Terms_and_Conditions_for_Fixed_Spread_Account.pdf");
            pageLegalDocumentation.GoToBack();
            Wait.UrlContains(webDriver, pageLegalDocumentation.ExpectedUrl);

        }
    }
}
