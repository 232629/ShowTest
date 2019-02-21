﻿using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2.Core.Helpers
{
    public static class RegistrationHelper
    {
        public static string GetRandom(int length)
        {
            var g = Guid.NewGuid().ToString("N");
            length = (length < g.Length)? length: 10;
            
            return g.Substring(g.Length - length);
        }

        /// <summary>
        /// Registration Step 0.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="userDataStep0"></param>
        public static void RegistrationStep0(IWebDriver webDriver, DataStep0 userDataStep0, string lng)
        {
            PageRegister pageRegister = new PageRegister(webDriver, lng);
            //Assert.AreEqual(pageRegister.ExpectedUrl, webDriver.Url);

            pageRegister.TxtEmail.Clear();
            if (userDataStep0.TxtEmail != null)
                pageRegister.TxtEmail.SendKeys(userDataStep0.TxtEmail);

            pageRegister.TxtPassword.Clear();
            if (userDataStep0.TxtPassword != null)
                pageRegister.TxtPassword.SendKeys(userDataStep0.TxtPassword);

            pageRegister.TxtFirstName.Clear();
            if (userDataStep0.TxtFirstName != null)
                pageRegister.TxtFirstName.SendKeys(userDataStep0.TxtFirstName);

            pageRegister.TxtLastName.Clear();
            if (userDataStep0.TxtLastName != null)
                pageRegister.TxtLastName.SendKeys(userDataStep0.TxtLastName);

            if (userDataStep0.CmbCountry != null)
                pageRegister.CmbCountry.SetValueAfterClick(userDataStep0.CmbCountry);

            if (userDataStep0.BtnNexStep)
              pageRegister.BtnRegister.Click();

        }

        /// <summary>
        /// Registration Step 1.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="userDataStep1"></param>
        public static void RegistrationStep1(IWebDriver webDriver, DataStep1 userDataStep1, string lng)
        {
            PageRregisterStep1 pageRegisterStep1 = new PageRregisterStep1(webDriver, lng);
            //pageRegisterStep1.WaitLoadPage(pageRegisterStep1);

            pageRegisterStep1.TxtAddress.Clear();
            if (userDataStep1.TxtAddress != null)
                pageRegisterStep1.TxtAddress.SendKeys(userDataStep1.TxtAddress);

            #region MENA(UAE)

            if (userDataStep1.TxtPostcode != null)
            {
                pageRegisterStep1.TxtPostcode.Clear();
                pageRegisterStep1.TxtPostcode.SendKeys(userDataStep1.TxtPostcode);
            }

            #endregion 

            pageRegisterStep1.TxtCity.Clear();
            if (userDataStep1.TxtCity != null)
                pageRegisterStep1.TxtCity.SendKeys(userDataStep1.TxtCity);

            #region FCA

            if (userDataStep1.TxtStreetName != null)
            {
                pageRegisterStep1.TxtStreetName.Clear();
                pageRegisterStep1.TxtStreetName.SendKeys(userDataStep1.TxtStreetName);
            }
            
            if (userDataStep1.TxtState != null)
            {
                pageRegisterStep1.TxtState.Clear();
                pageRegisterStep1.TxtState.SendKeys(userDataStep1.TxtState);
            }

            if (userDataStep1.TxtYearMoved != null)
            {
                pageRegisterStep1.TxtYearMoved.Clear();
                pageRegisterStep1.TxtYearMoved.SendKeys(userDataStep1.TxtYearMoved);
            }

            if (userDataStep1.TxtMiddleInitial != null)
            {
                pageRegisterStep1.TxtMiddleInitial.Clear();
                pageRegisterStep1.TxtMiddleInitial.SendKeys(userDataStep1.TxtMiddleInitial);
            }

            if (userDataStep1.TxtMothersName != null)
            {
                pageRegisterStep1.TxtMothersName.Clear();
                pageRegisterStep1.TxtMothersName.SendKeys(userDataStep1.TxtMothersName);
            }

            #endregion

            if (userDataStep1.CmbEmirate != null)
                pageRegisterStep1.CmbEmirate.SetValueAfterClick(userDataStep1.CmbEmirate);

            if (userDataStep1.TxtBirthdate != null)
            {
                if (pageRegisterStep1.UsedBrowser == "Chrome")  
                    pageRegisterStep1.TxtBirthdate.Click();//need for Chrome           
                pageRegisterStep1.TxtBirthdate.SendKeys(userDataStep1.TxtBirthdate);
            }
         
            pageRegisterStep1.TxtPhone.Clear();
            if (userDataStep1.TxtPhone != null)
                pageRegisterStep1.TxtPhone.SendKeys(userDataStep1.TxtPhone);       

            if (userDataStep1.TxtQq != null)
            {
                pageRegisterStep1.TxtQq.Clear();
                pageRegisterStep1.TxtQq.SendKeys(userDataStep1.TxtQq);
            }

            if (userDataStep1.CmbNationality != null)
                pageRegisterStep1.CmbNationality.SetValueAfterClick(userDataStep1.CmbNationality);

            if (userDataStep1.BtnNexStep)
               pageRegisterStep1.BtnNexStep.Click();

        }

        /// <summary>
        /// Registration Step 2.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="userDataStep2"></param>
        public static void RegistrationStep2(IWebDriver webDriver, DataStep2 userDataStep2, string lng)
        {

            PageRregisterStep2 pageRegisterStep2 = new PageRregisterStep2(webDriver, lng);
            //pageRegisterStep2.WaitLoadPage(pageRegisterStep2);

            if (userDataStep2.CmbEmployment != null)
                pageRegisterStep2.CmbEmployment.SetValueAfterClick(userDataStep2.CmbEmployment);

            if(userDataStep2.CmbEmploymentPosition != null)
                pageRegisterStep2.CmbEmploymentPosition.SetValueAfterClick(userDataStep2.CmbEmploymentPosition);

            if (userDataStep2.CmbEmploymentType != null)
                pageRegisterStep2.CmbEmploymentType.SetValueAfterClick(userDataStep2.CmbEmploymentType);

                if (userDataStep2.TxtEmploymentOther != null)
                    pageRegisterStep2.TxtEmploymentOther.SendKeys(userDataStep2.TxtEmploymentOther);

            if (userDataStep2.CmbLevelOfEducation != null)
                pageRegisterStep2.CmbLevelOfEducation.SetValueAfterClick(userDataStep2.CmbLevelOfEducation);

            if (userDataStep2.CmbAnnualIncome != null)
                pageRegisterStep2.CmbAnnualIncome.SetValueAfterClick(userDataStep2.CmbAnnualIncome);

            if (userDataStep2.CmbEstimatedNetWorth != null)
                pageRegisterStep2.CmbEstimatedNetWorth.SetValueAfterClick(userDataStep2.CmbEstimatedNetWorth);

            if (userDataStep2.CmbSourceOfIncome != null)
                pageRegisterStep2.CmbSourceOfIncome.SetValueAfterClick(userDataStep2.CmbSourceOfIncome);

                if (userDataStep2.TxtSourceOfIncomeOther != null)
                    pageRegisterStep2.TxtSourceOfIncomeOther.SendKeys(userDataStep2.TxtSourceOfIncomeOther);

            #region Cysec
            if (userDataStep2.CmbCountryOfOrigin != null)
                pageRegisterStep2.CmbCountryOfOrigin.SetValueAfterClick(userDataStep2.CmbCountryOfOrigin);
            #endregion

            if (userDataStep2.CmbDeposit != null)
                pageRegisterStep2.CmbDeposit.SetValueAfterClick(userDataStep2.CmbDeposit);


            if (userDataStep2.ChkToTradeCFDs)
            {
                if (!pageRegisterStep2.ChkToTradeCFDs.Selected)
                    pageRegisterStep2.ChkToTradeCFDs.Click();
            }
            else
            {
                if (userDataStep2.ChkToTradeCFDsOnForex)
                    if (!pageRegisterStep2.ChkToTradeCFDsOnForex.Selected)
                        pageRegisterStep2.ChkToTradeCFDsOnForex.Click();
                if (userDataStep2.ChkToTradeCFDsOnShares)
                    if (!pageRegisterStep2.ChkToTradeCFDsOnShares.Selected)
                        pageRegisterStep2.ChkToTradeCFDsOnShares.Click();
                if (userDataStep2.ChkToTradeCFDsOnIndices)
                    if (!pageRegisterStep2.ChkToTradeCFDsOnIndices.Selected)
                        pageRegisterStep2.ChkToTradeCFDsOnIndices.Click();
            }

            if(userDataStep2.UsCitizen != null)
            { 
                if (userDataStep2.UsCitizen.BtnUScitizen)
                {
                    pageRegisterStep2.BtnUScitizenYes.Click();
                    pageRegisterStep2.TxtUsTaxCode.Clear();
                    if (userDataStep2.UsCitizen.TxtUsTaxCode != null)
                        pageRegisterStep2.TxtUsTaxCode.SendKeys(userDataStep2.UsCitizen.TxtUsTaxCode);
                }
                else
                {
                     pageRegisterStep2.BtnUScitizenNo.Click();
                }
            }


            #region Trading Experience

            if (userDataStep2.CmbTradingExperience != null)
                pageRegisterStep2.CmbTradingExperience.SetValueAfterClick(userDataStep2.CmbTradingExperience);

            //Trading Experience = Yes, I have traded on a real account
            if (userDataStep2.CmbExperience != null)
                pageRegisterStep2.CmbExperience.SetValueAfterClick(userDataStep2.CmbExperience);
            if (userDataStep2.CmbHowManyTimesYouTraded != null)
                pageRegisterStep2.CmbHowManyTimesYouTraded.SetValueAfterClick(userDataStep2.CmbHowManyTimesYouTraded);   //field is absent

            //Trading Experience = NO
            if (userDataStep2.ChkHaveRelevantEducational)
                if (!pageRegisterStep2.ChkHaveRelevantEducational.Selected)
                    pageRegisterStep2.ChkHaveRelevantEducational.Click();
            if (userDataStep2.ChkIRegularlyMonitorNews)
                if (!pageRegisterStep2.ChkIRegularlyMonitorNews.Selected)
                    pageRegisterStep2.ChkIRegularlyMonitorNews.Click();
            if (userDataStep2.ChkIHaveReadMaterialOnTrading)
                if (!pageRegisterStep2.ChkIHaveReadMaterialOnTrading.Selected)
                    pageRegisterStep2.ChkIHaveReadMaterialOnTrading.Click();
            if (userDataStep2.ChkAllOfAbove)
                if (!pageRegisterStep2.ChkAllOfAbove.Selected)
                    pageRegisterStep2.ChkAllOfAbove.Click();
            if (userDataStep2.ChkNoneOfAbove)
                if (!pageRegisterStep2.ChkNoneOfAbove.Selected)
                    pageRegisterStep2.ChkNoneOfAbove.Click();

            #endregion

            if (userDataStep2.CmbQuestion1 != null)
                pageRegisterStep2.CmbQuestion1.SetValueAfterClick(userDataStep2.CmbQuestion1);
            if (userDataStep2.CmbQuestion2 != null)
                pageRegisterStep2.CmbQuestion2.SetValueAfterClick(userDataStep2.CmbQuestion2);
            if (userDataStep2.CmbQuestion3 != null)
                pageRegisterStep2.CmbQuestion3.SetValueAfterClick(userDataStep2.CmbQuestion3);
            
            #region FCA

            if (userDataStep2.CmbRiskQuestion1 != null)
                pageRegisterStep2.CmbRiskQuestion1.SetValueAfterClick(userDataStep2.CmbRiskQuestion1);
            
            #endregion

            #region Professional UAE Client
            if (userDataStep2.ChkProfessionalClientYes)
            {
                //var f = pageRegisterStep2.ChkProfessionalClientYes;
                pageRegisterStep2.ChkProfessionalClientYes.Click();

                if (userDataStep2.CmbLeveragedProductExperience != null)
                    pageRegisterStep2.CmbLeveragedProductExperience.SetValueAfterClick(userDataStep2.CmbLeveragedProductExperience);

                pageRegisterStep2.TxtLeveragedProductExperienceOther.Clear();
                if (userDataStep2.TxtLeveragedProductExperienceOther != null)
                    pageRegisterStep2.TxtLeveragedProductExperienceOther.SendKeys(userDataStep2.TxtLeveragedProductExperienceOther);
            }

            if (userDataStep2.ChkProfessionalClientNo)
                pageRegisterStep2.ChkProfessionalClientNo.Click();
            #endregion

            if (userDataStep2.BtnNexStep)
                pageRegisterStep2.BtnNexStep.Click();


        }

        /// <summary>
        /// Registration Step 3.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="userDataStep3"></param>
        public static void RegistrationStep3(IWebDriver webDriver, DataStep3 userDataStep3, string lng)
        {
            PageRregisterStep3 pageRegisterStep3 = new PageRregisterStep3(webDriver, lng);
            //pageRegisterStep3.WaitLoadPage(pageRegisterStep3);

            if (userDataStep3.CmbAccountType != null)
                pageRegisterStep3.CmbAccountType.SetValueAfterClick(userDataStep3.CmbAccountType);
            if (userDataStep3.CmbLeverage != null)
                pageRegisterStep3.CmbLeverage.SetValueAfterClick(userDataStep3.CmbLeverage);
            if (userDataStep3.CmbCurrencyBase != null)
                pageRegisterStep3.CmbCurrencyBase.SetValueAfterClick(userDataStep3.CmbCurrencyBase);

            #region FCA Cysec

            if (userDataStep3.BtnProClientInterestedYes)
                pageRegisterStep3.BtnProClientInterestedYes.Click();

            if (userDataStep3.BtnProClientInterestedNo)
                pageRegisterStep3.BtnProClientInterestedNo.Click();

            #endregion

            if (userDataStep3.BtnVerifyYourProfileYes)
                pageRegisterStep3.BtnVerifyYourProfileYes.Click();

            if (userDataStep3.BtnVerifyYourProfileNo)
                pageRegisterStep3.BtnVerifyYourProfileNo.Click();

            if (userDataStep3.ChkReceiveCompanyNews)
                if (!pageRegisterStep3.ChkReceiveCompanyNews.Selected)
                    pageRegisterStep3.ChkReceiveCompanyNews.Click();


            if (userDataStep3.ChkReceiveTechnicalAnalysis)
                if (!pageRegisterStep3.ChkReceiveTechnicalAnalysis.Selected)
                    pageRegisterStep3.ChkReceiveTechnicalAnalysis.Click();


            if (userDataStep3.CmbLanguage != null)
                pageRegisterStep3.CmbLanguage.SetValueAfterClick(userDataStep3.CmbLanguage);

            if (userDataStep3.ChkAcceptRisks)
                if (!pageRegisterStep3.ChkAcceptRisks.Selected)
                    pageRegisterStep3.ChkAcceptRisks.Click();

            if (userDataStep3.ChkClientAgreement)
                if (!pageRegisterStep3.ChkClientAgreement.Selected)
                    pageRegisterStep3.ChkClientAgreement.Click();

            if (userDataStep3.BtnComplete)
            {
                pageRegisterStep3.BtnComplete.Click();
                PageThankYou pageThankYou = new PageThankYou(webDriver, lng);
                Wait.UrlContains(webDriver, pageThankYou.ExpectedUrl);
            }
            

        }

    }
}
       

