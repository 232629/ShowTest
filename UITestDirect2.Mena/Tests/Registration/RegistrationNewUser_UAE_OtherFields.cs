﻿using System;
using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages.Client_area;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Mena
    {
        /// <summary>
        /// Registration new UAE user
        /// 0 step: 
        /// DFSA
        /// Country > United Arab Emirates
        /// 1 step:
        /// 2 step:
        /// Use fields:
        /// Other industry
        /// Other Source of Wealth 
        /// Are you a US citizen or a US resident for tax purposes? > No
        /// Do you have trading experience? > No
        /// 3 step:
        /// Verify your profile now? > No
        /// </summary>
        [Test]
        //[Retry(3)]
        [TestCase("en")]
        [Description(
            "1 step: DFSA, Country > UnitedArabEmirates \n\r2 step: \n\r3 step: Are you a US citizen or a US resident for tax purposes? > No, Do you have trading experience? > No \n\r4 step: Verify your profile now? > No")]
        public void RegistrationNewUser_UAE_OtherFields(string lng)
        {
            #region Test Data

            var randomPart = RegistrationHelper.GetRandom(8);

            DataStep0 dataStep0 = new DataStep0();
            dataStep0.TxtEmail = randomPart + "@testing.test";
            Log.Info("Email new user = " + dataStep0.TxtEmail);
            dataStep0.TxtPassword = "Password1";
            Log.Info("Password new user = " + dataStep0.TxtPassword);
            dataStep0.TxtFirstName = "TestNameUAE";
            dataStep0.TxtLastName = "TestLastNameUAE";
            dataStep0.CmbCountry = "United Arab Emirates";
            dataStep0.BtnNexStep = true;

            DataStep1 dataStep1 = new DataStep1();
            dataStep1.TxtAddress = "Al Safa Street 1";
            dataStep1.TxtCity = "Dubai";
            dataStep1.CmbEmirate = "Dubai";
            dataStep1.TxtBirthdate = "01/01/1990";
            dataStep1.TxtPhone = "971500000000";
            dataStep1.CmbNationality = "United Arab Emirates";
            dataStep1.BtnNexStep = true;

            DataStep2 dataStep2 = new DataStep2();
            //Employment Information
            dataStep2.CmbEmployment = "Employed";
            dataStep2.CmbEmploymentType = "Other";
                dataStep2.TxtEmploymentOther = "Other-industry";
            dataStep2.CmbLevelOfEducation = "High School";
            //Financial Information
            dataStep2.CmbAnnualIncome = "> $1,000,000";
            dataStep2.CmbEstimatedNetWorth = "$1,000,000 - $5,000,000";
            dataStep2.CmbSourceOfIncome = "Other";
                dataStep2.TxtSourceOfIncomeOther = "Other-Source-of-Wealth";
            dataStep2.CmbDeposit = "> $1,000,000";
            dataStep2.ChkToTradeCFDs = true;
            dataStep2.UsCitizen = new DataStep2.DataUsCitizen(btnUScitizen: false);
            //Trading Experience
            dataStep2.CmbTradingExperience = "No";
                dataStep2.ChkHaveRelevantEducational = true;
                dataStep2.ChkIRegularlyMonitorNews = true;
                dataStep2.ChkIHaveReadMaterialOnTrading = true;

            dataStep2.CmbQuestion1 = "500 EUR";
            dataStep2.CmbQuestion2 = "A take profit order";
            dataStep2.CmbQuestion3 = "1:50";

            dataStep2.ChkProfessionalClientYes = true;
            dataStep2.CmbLeveragedProductExperience = "Other (please specify)";
            dataStep2.TxtLeveragedProductExperienceOther = "I am good";

            dataStep2.BtnNexStep = true;

            DataStep3 dataStep3 = new DataStep3();
            dataStep3.CmbAccountType = "MT4";
            dataStep3.CmbCurrencyBase = "EUR";
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
