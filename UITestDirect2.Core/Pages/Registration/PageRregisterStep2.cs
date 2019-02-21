using System.Threading;
using OpenQA.Selenium;
 
using UITestDirect2.Core.CustomElements;

namespace UITestDirect2.Core.Pages.Registration
{
    public class PageRregisterStep2 : PageCommon
    {
        public PageRregisterStep2(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/register/step2";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\registerStep2.jpg"; }
        }

        /// <summary>
        /// Employment Status
        /// </summary>
        public CustomSelectElement CmbEmployment
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-employment"))); }
        }

            /// <summary>
            /// Employment position
            /// FCA and Cysec (if CmbEmploymentType = Employed or Self-Employed)
            /// </summary>
            public CustomSelectElement CmbEmploymentPosition
            {
                get { return new CustomSelectElement(FindElement(By.Id("select-employment-position"))); }
            }

        /// <summary>
        /// Industry
        /// </summary>
        public CustomSelectElement CmbEmploymentType
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-employment-type"))); }
        }

            /// <summary>
            /// Other Industry
            /// </summary>
            public IWebElement TxtEmploymentOther
            {
                get { return FindElement(By.Id("input-employment-other")); }
            }

        /// <summary>
        /// What is your level of education?
        /// </summary>
        public CustomSelectElement CmbLevelOfEducation
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-education-level"))); }
        }

        /// <summary>
        /// Annual Income
        /// </summary>
        public CustomSelectElement CmbAnnualIncome
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-annual-income"))); }
        }

        /// <summary>
        /// Estimated Net Worth excluding your primary residence
        /// </summary>
        public CustomSelectElement CmbEstimatedNetWorth
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-estimated-worth"))); }
        }

        /// <summary>
        /// Source of Wealth
        /// </summary>
        public CustomSelectElement CmbSourceOfIncome
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-income-source"))); }
        }

            /// <summary>
            /// Other Source of Wealth
            /// </summary>
            public IWebElement TxtSourceOfIncomeOther
            {
                get { return FindElement(By.Id("input-income-source-other")); }
            }

        /// <summary>
        /// Expected country of origin and destination of funds
        /// Cysec
        /// </summary>
        public CustomSelectElement CmbCountryOfOrigin
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-funds-origin-country"))); }
        }

        /// <summary>
        /// How much do you expect to deposit in next 12 months?
        /// </summary>
        public CustomSelectElement CmbDeposit
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-anticipate-deposit"))); }
        }

        /// <summary>
        /// To trade CFDs
        /// </summary>
        public CustomCheckboxElement ChkToTradeCFDs
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=join-reason-all]"))); }
        }
            /// <summary>
            /// To trade CFDs on Forex
            /// </summary>
            public CustomCheckboxElement ChkToTradeCFDsOnForex
            {
                get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=join-reason-0]"))); }
            }
            /// <summary>
            /// To trade CFDs on Shares
            /// </summary>
            public CustomCheckboxElement ChkToTradeCFDsOnShares
            {
                get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=join-reason-1]"))); }
            }
            /// <summary>
            /// To trade CFDs on Indices/Commodities
            /// </summary>
            public CustomCheckboxElement ChkToTradeCFDsOnIndices
            {
                get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=join-reason-2]"))); }
            }

        /// <summary>
        /// Are you a US citizen or a US resident for tax purposes?
        /// </summary>
        public IWebElement BtnUScitizenYes
        {
            get { return FindElement(By.CssSelector("label#label-uscitizen-yes")); }
        }

            /// <summary>
            /// US Tax Code
            /// </summary>
            public IWebElement TxtUsTaxCode
            {
                get { return FindElement(By.Id("input-us-tax-code")); }
            }

        /// <summary>
        /// Are you a US citizen or a US resident for tax purposes?
        /// </summary>
        public IWebElement BtnUScitizenNo
        {
            get { return FindElement(By.CssSelector("label#label-uscitizen-no")); }
        }

        #region Trading Experience

        /// <summary>
        /// Do you have any trading experience?
        /// </summary>
        public CustomSelectElement CmbTradingExperience
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-trading-experience"))); }
        }

            /// <summary>
            /// How much experience do you have with trading FX, CFDs, Spread Bets or other leveraged financial products?       
            /// </summary>
            public CustomSelectElement CmbExperience
            {
                get { return new CustomSelectElement(FindElement(By.Id("select-years-experience"))); }
            }

            /// <summary>
            /// How many times have you traded on the above products in the past 12 months?
            /// </summary>
            public CustomSelectElement CmbHowManyTimesYouTraded
            {
                //get { return new CustomSelectElement(FindElement(By.Id("select-trades-last-year-quarter")), IWebDriver); }
                get { return new CustomSelectElement(FindElement(By.Id("select-trades-last-year"))); }
            }


        /// <summary>
        /// I have a relevant educational/professional qualification
        /// </summary>
        public CustomCheckboxElement ChkHaveRelevantEducational
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=knowledge-map-0]"))); }
        }

        /// <summary>
        /// I regularly monitor the news/markets
        /// </summary>
        public CustomCheckboxElement ChkIRegularlyMonitorNews
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=knowledge-map-1]"))); }
        }

        /// <summary>
        /// I have read educational material on trading
        /// </summary>
        public CustomCheckboxElement ChkIHaveReadMaterialOnTrading
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=knowledge-map-2]"))); }
        }

        /// <summary>
        /// All of the above
        /// </summary>
        public CustomCheckboxElement ChkAllOfAbove
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=knowledge-all]"))); }
        }

        /// <summary>
        /// None of the above
        /// </summary>
        public CustomCheckboxElement ChkNoneOfAbove
        {
            get { return new CustomCheckboxElement(FindElement(By.CssSelector("label.custom-checkbox[for=knowledge-none]"))); }
        }

        #endregion

        /// <summary>
        /// What would be the required margin for 1 lot (100,000) EURUSD, if your leverage is 1:100?
        /// </summary>
        public CustomSelectElement CmbQuestion1
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-knowledge-1"))); }
        }

        /// <summary>
        /// What type of closing order can you choose to help limit losses when trading?
        /// </summary>
        public CustomSelectElement CmbQuestion2
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-knowledge-2"))); }
        }

        /// <summary>
        /// The market moves by 2%. Trading with how much leverage would lead to the largest potential profit or loss?
        /// </summary>
        public CustomSelectElement CmbQuestion3
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-knowledge-3")));}
        }

        /// <summary>
        /// Assuming your deposited capital is an amount you can afford to lose without affecting your capability to meet your financial obligations. How will you feel/react in case you lose that amount as a result of trading CFDs:
        /// FCA Cysec
        /// </summary>
        public CustomSelectElement CmbRiskQuestion1
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-risk-question-1"))); }
        }


        #region If regulator = DFSA and Country = UAE and Net worth >= 1 000 000
        /// <summary>
        /// Fields ChkprofessionalClient use only for regulator DFSA 
        /// </summary>
        public IWebElement ChkProfessionalClientYes
        {
            get { return FindElement(By.Id("label-professional-client-yes")); }
        }

        public IWebElement ChkProfessionalClientNo
        {
            get { return FindElement(By.Id("label-professional-client-no")); }
        }

        /// <summary>
        /// Field CmbLeveragedProductExperience uses only for regulator DFSA
        /// </summary>
        public CustomSelectElement CmbLeveragedProductExperience
        {
            get { return new CustomSelectElement(FindElement(By.Id("select-leveragedProductExperience"))); }
        }

        /// <summary>
        /// Field TxtLeveragedProductExperienceOther uses only for regulator DFSA
        /// </summary>
        public IWebElement TxtLeveragedProductExperienceOther
        {
            get { return FindElement(By.Id("input-leveragedProductExperienceOther")); }
        }
        #endregion


        public IWebElement BtnNexStep
        {
            get { return FindElement(By.Id("submit-step-3")); }
        }

        public IWebElement BtnPreviousStep
        {
            get { return FindElement(By.Id("back-step-3")); }
        }

    }
}
