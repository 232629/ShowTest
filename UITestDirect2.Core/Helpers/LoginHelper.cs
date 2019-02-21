using System;
using NUnit.Framework;
using OpenQA.Selenium;
 
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2.Core.Helpers
{
    public static class LoginHelper
    {
        public static void Login(IWebDriver webDriver, string lng, string login = null, string pass = null)
        {

            PageLogin pageLogin = new PageLogin(webDriver, lng);

            if (login == null)
            {
                login = "fst" + RegistrationHelper.GetRandom(10) + "@testing.test";
                Log.Info("Email new user = " + login);
                pass = "Password1";
                Log.Info("Password new user = " + pass);
                ApiHelper.CreateNewUser(pageLogin.BaseUrl, login, pass);
            }

            pageLogin.GoToPage(pageLogin.ExpectedUrl);

            pageLogin.TxtEmail.Clear();
            pageLogin.TxtEmail.SendKeys(login);
            pageLogin.TxtPassword.Clear();
            pageLogin.TxtPassword.SendKeys(pass);
            pageLogin.ChkStaySignedIn.Click();
            //System.Threading.Thread.Sleep(3000);            //bad decision
            pageLogin.BtnLogin.Click();           

        }

    }

}
       

