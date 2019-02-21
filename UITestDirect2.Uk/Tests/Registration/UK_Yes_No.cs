using System;
using NUnit.Framework;
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
        /// Registration new UK user
        /// 
        /// 0 step: 
        /// Country > UK
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
            "1 step: Country > UK \n\r2 step: \n\r3 step: Do you have trading experience? > Yes \n\r4 step: Verify your profile now? > No")]
        public void UK_Yes_No(string lng)
        {
            #region Test Data

            var randomPart = RegistrationHelper.GetRandom(8);

            DataStep0 dataStep0 = new DataStep0();
            dataStep0.TxtEmail = randomPart + "@testing.test";
            Log.Info("Email new user = " + dataStep0.TxtEmail);
            dataStep0.TxtPassword = "Password1";
            Log.Info("Password new user = " + dataStep0.TxtPassword);
            dataStep0.TxtFirstName = "TestNameUK";
            dataStep0.TxtLastName = "TestLastNameUK";
            dataStep0.CmbCountry = "United Kingdom";
            dataStep0.BtnNexStep = true;

            DataStep1 dataStep1 = new DataStep1();
            dataStep1.TxtAddress = "Liverpool Street 1";
            dataStep1.TxtPostcode = "EC2M 7AY";
            dataStep1.TxtCity = "London";
            dataStep1.TxtBirthdate = "01/01/1990";
            dataStep1.TxtPhone = "440000000000";

            #region UK
            dataStep1.TxtStreetName = "Liverpool ";
            dataStep1.TxtState = "London state";
            dataStep1.TxtYearMoved = "1980";
            dataStep1.TxtMiddleInitial = "E";
            dataStep1.TxtMothersName = "Hurt";
            #endregion

            //dataStep1.CmbNationality = "United Kingdom";
            dataStep1.BtnNexStep = true;


            DataStep2 dataStep2 = new DataStep2();
            //Employment Information
            dataStep2.CmbEmployment = "Student";
            dataStep2.CmbEmploymentType = "Education";
            dataStep2.CmbLevelOfEducation = "High School";
            //Financial Information
            dataStep2.CmbAnnualIncome = "$0 - $50,000";
            dataStep2.CmbEstimatedNetWorth = "$50,000 - $100,000";
            dataStep2.CmbSourceOfIncome = "Other";
            dataStep2.TxtSourceOfIncomeOther = "Mama";
            dataStep2.CmbDeposit = "$10,000 - $50,000";
            dataStep2.ChkToTradeCFDs = true;
            //Trading Experience
            dataStep2.CmbTradingExperience = "Yes, I have traded on a real account";
                dataStep2.CmbExperience = "> 3 years";
                dataStep2.CmbHowManyTimesYouTraded = "Less than 10 per quarter";

            dataStep2.CmbQuestion1 = "500 EUR";
            dataStep2.CmbQuestion2 = "A take profit order";
            dataStep2.CmbQuestion3 = "Loss would be the same";
            dataStep2.CmbRiskQuestion1 = "I will be very upset and never trade CFDs again";

            dataStep2.BtnNexStep = true;


            DataStep3 dataStep3 = new DataStep3();
            dataStep3.CmbAccountType = "FxPro Edge";
            //dataStep3.CmbLeverage = "1:50";
            dataStep3.CmbCurrencyBase = "GBP";
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

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            Wait.UrlContains(webDriver, pageTradingAccountsReal.ExpectedUrl);

        }
    }
}
