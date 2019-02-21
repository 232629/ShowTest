using OpenQA.Selenium;
 

namespace UITestDirect2.Core.Pages.Client_area
{
    public class PageProfile : PageCommon
    {
        public PageProfile(IWebDriver driver, string lng = "en")
            : base(driver, lng)
        { }

        public override string ExpectedUrl
        {
            get
            {
                return BaseUrl + "/" + Language + "/profile";
            }
        }

        public override string ExpectedTitle
        {
            get { return "FxPro"; }
        }

        public override string ScreenShot
        {
            get { return FolderExpectedScreenShots + "\\" + Language + "\\Profile.jpg"; }
        }

        #region Personal details

        public IWebElement LnkEditPersonalDetails
        {
            get { return FindElement(By.Id("profile_menu_item_details")); }
        }

        public IWebElement LnkChangeResidentalAddress
        {
            get { return FindElement(By.Id("profile_menu_item_change_address")); }
        }

        #endregion

        #region Log in details & security

        public IWebElement LnkChangePassword
        {
            get { return FindElement(By.Id("profile_menu_item_change_password")); }
        }

        #endregion

        #region Profile verification

        public IWebElement LnkUploadDocuments
        {
            get { return FindElement(By.Id("profile_menu_item_upload_documents")); }
        }

        public IWebElement LnkManageBankDetails
        {
            get { return FindElement(By.Id("profile_menu_item_manage_bank_details")); }
        }
        #endregion

        #region Downloads

        public IWebElement LnkLegalDocumentation
        {
            get { return FindElement(By.Id("profile_menu_legal_documentation")); }
        }

        #endregion
    }
}
