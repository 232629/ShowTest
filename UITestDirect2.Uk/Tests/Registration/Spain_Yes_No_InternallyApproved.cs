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
        /// Country > ES
        /// 1 step:
        /// Without UK fields
        /// 2 step:
        /// Do you have trading experience? > Yes
        /// Professional = Yes
        /// 3 step:
        /// Verify your profile now? > No
        /// </summary>  
        [Test]
        //[Retry(3)]
        [TestCase("en")]
        [Description(
            "1 step: Country > Spain \n\r2 step: \n\r3 step: Do you have trading experience? > Yes \n\r4 step: Verify your profile now? > No")]
        //[Parallelizable(ParallelScope.Self)]
        public void Spain_Yes_No_InternallyApproved(string lng)
        {
            #region Test Data

            var randomPart = RegistrationHelper.GetRandom(8);

            DataStep0 dataStep0 = new DataStep0();
            dataStep0.TxtEmail = randomPart + "@testing.test";
            Log.Info("Email new user = " + dataStep0.TxtEmail);
            dataStep0.TxtPassword = "Password1";
            Log.Info("Password new user = " + dataStep0.TxtPassword);
            dataStep0.TxtFirstName = "TestNameSP";
            dataStep0.TxtLastName = "TestLastNameSP";
            dataStep0.CmbCountry = "Spain";
            dataStep0.BtnNexStep = true;

            DataStep1 dataStep1 = new DataStep1();
            dataStep1.TxtAddress = "Barcelona Hiribidea 1";
            dataStep1.TxtPostcode = "20014";
            dataStep1.TxtCity = "Donostia";
            dataStep1.TxtBirthdate = "01/01/1990";
            dataStep1.TxtPhone = "34000000000";
            dataStep1.BtnNexStep = true;


            DataStep2 dataStep2 = new DataStep2();
            //Employment Information
            dataStep2.CmbEmployment = "Employed";                                                           
            dataStep2.CmbEmploymentType = "Financial Services (eligible for professional clients)";         
            dataStep2.CmbEmploymentPosition = "Senior management";
            dataStep2.CmbLevelOfEducation = "High School";
            //Financial Information
            dataStep2.CmbAnnualIncome = "$500,000 - $1,000,000";
            dataStep2.CmbEstimatedNetWorth = "> $1,000,000 (eligible for professional clients)";
            dataStep2.CmbSourceOfIncome = "Savings / Investments";
            //dataStep2.CmbCountryOfOrigin = "Cyprus";
            dataStep2.CmbDeposit = "> $1,000,000";
            dataStep2.ChkToTradeCFDs = true;
            //Trading Experience
            dataStep2.CmbTradingExperience = "Yes, I have traded on a real account";
            dataStep2.CmbExperience = "> 3 years";
            dataStep2.CmbHowManyTimesYouTraded = "More than 10 per quarter (eligible for professional clients)";

            dataStep2.CmbQuestion1 = "500 EUR";
            dataStep2.CmbQuestion2 = "A take profit order";
            dataStep2.CmbQuestion3 = "Loss would be the same";
            dataStep2.CmbRiskQuestion1 = "I will be very upset and never trade CFDs again";

            dataStep2.BtnNexStep = true;
            

            DataStep3 dataStep3 = new DataStep3();
            dataStep3.CmbAccountType = "MT5";
            dataStep3.CmbLeverage = "1:30";
            dataStep3.CmbCurrencyBase = "EUR";

            dataStep3.BtnProClientInterestedYes = true;

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

            //Internally Approved = true
            ApiHelper.SetApprovedForAcceptance(webDriver);
            
            PageRegulatoryDisclaimer pageRegulatoryDisclaimer = new PageRegulatoryDisclaimer(webDriver, lng);
            pageRegulatoryDisclaimer.BtnClickToCopy.Click();
            pageRegulatoryDisclaimer.BtnContinue.Click();

            PageTradingAccountsReal pageTradingAccountsReal = new PageTradingAccountsReal(webDriver, lng);
            pageTradingAccountsReal.LnkProAcceptance.Click();

            PageProAcceptance pageProAcceptance = new PageProAcceptance(webDriver, lng);
            pageProAcceptance.ChkAcknowledgementRecategorisation.Click();
            pageProAcceptance.BtnProceed.Click();

            //pageTradingAccountsReal.WaitLoadPage();
            Assert.AreEqual("Your acceptance has been received successfully. You will shortly be categorized as professional client.", pageTradingAccountsReal.MsgSuccess.Text);


        }
    }
}
