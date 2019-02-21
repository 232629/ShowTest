using System;
using System.Threading;
using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages.Client_area;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2.Cysec
{
    [TestFixture]
    public partial class UITestDirect2Cysec
    {
        /// <summary>
        /// https://fxpropm.atlassian.net/wiki/spaces/DIR2/pages/138248431/Dummy+partnerships
        /// Registration new Cyprus user
        /// 
        /// 0 step: 
        /// Country > Cyprus
        /// 1 step:
        /// 2 step:
        /// Do you have trading experience? > Yes
        /// 3 step:
        /// Verify your profile now? > No
        /// </summary>
        [Test]
        //[Retry(3)]
        [TestCase("en")]
        [Description(
            "1 step: Country > Cyprus \n\r2 step: \n\r3 step: Do you have trading experience? > No \n\r4 step: Verify your profile now? > No")]
        public void Cyprus_No_No_ReassessmentRequested(string lng)
        {
            #region Test Data

            var randomPart = RegistrationHelper.GetRandom(8);

            DataStep0 dataStep0 = new DataStep0();
            dataStep0.TxtEmail = randomPart + "@testing.test";
            Log.Info("Email new user = " + dataStep0.TxtEmail);
            dataStep0.TxtPassword = "Password1";
            Log.Info("Password new user = " + dataStep0.TxtPassword);
            dataStep0.TxtFirstName = "TestNameCy";
            dataStep0.TxtLastName = "TestLastNameCy";
            dataStep0.CmbCountry = "Cyprus";
            dataStep0.BtnNexStep = true;

            DataStep1 dataStep1 = new DataStep1();
            dataStep1.TxtAddress = "Parmenidou 8";
            dataStep1.TxtPostcode = "3022";
            dataStep1.TxtCity = "Germasogeia";
            dataStep1.TxtBirthdate = "01/01/1990";
            dataStep1.TxtPhone = "35700000000";

            dataStep1.BtnNexStep = true;


            DataStep2 dataStep2 = new DataStep2();
            //Employment Information
            dataStep2.CmbEmployment = "Student";                                                          
            dataStep2.CmbEmploymentType = "Education";
            dataStep2.CmbLevelOfEducation = "High School";
            //Financial Information
            dataStep2.CmbAnnualIncome = "$500,000 - $1,000,000";
            dataStep2.CmbEstimatedNetWorth = "$0 - $50,000";
            dataStep2.CmbSourceOfIncome = "Savings / Investments";
            dataStep2.CmbCountryOfOrigin = "Cyprus";
            dataStep2.CmbDeposit = "< $10,000";
            dataStep2.ChkToTradeCFDs = true;
            //Trading Experience
            dataStep2.CmbTradingExperience = "No";
            dataStep2.ChkAllOfAbove = true;

            dataStep2.CmbQuestion1 = "500 EUR";
            dataStep2.CmbQuestion2 = "A take profit order";
            dataStep2.CmbQuestion3 = "Loss would be the same";
            dataStep2.CmbRiskQuestion1 = "I will be very upset and never trade CFDs again";

            dataStep2.BtnNexStep = true;


            DataStep3 dataStep3 = new DataStep3();
            dataStep3.CmbAccountType = "MT4 Instant";
            dataStep3.CmbLeverage = "1:30";
            dataStep3.CmbCurrencyBase = "USD";
            dataStep3.BtnVerifyYourProfileNo = true;
            dataStep3.ChkReceiveCompanyNews = true;
            dataStep3.ChkReceiveTechnicalAnalysis = true;
            dataStep3.ChkAcceptRisks = true;
            dataStep3.CmbLanguage = "English";
            dataStep3.ChkClientAgreement = true;
            dataStep3.BtnComplete = true;

            #endregion

            //Login page
            PageLogin pageLogin = new PageLogin(webDriver, lng);
            pageLogin.LnkRegister.Click();

            //Registration Step 0
            RegistrationHelper.RegistrationStep0(webDriver, dataStep0, lng);

            //Registration Step 1
            RegistrationHelper.RegistrationStep1(webDriver, dataStep1, lng);

            //Registration Step 2
            RegistrationHelper.RegistrationStep2(webDriver, dataStep2, lng);

            //Registration Step 3
            RegistrationHelper.RegistrationStep3(webDriver, dataStep3, lng);

            //Reassessment Requested = true
            ApiHelper.SetReassessmentRequested(webDriver);

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.LnkProReassessment.Click();

            PageProReassessment pageProReassessment = new PageProReassessment(webDriver, lng);
            pageProReassessment.ChkQuestion1.Click();
            pageProReassessment.ChkQuestion2.Click();
            pageProReassessment.ChkQuestion3.Click();
            pageProReassessment.BtnProceed.Click();

            PageProDocuments pageProDocuments = new PageProDocuments(webDriver, lng);
            Wait.UrlContains(webDriver, pageProDocuments.ExpectedUrl);
        }
    }
}
