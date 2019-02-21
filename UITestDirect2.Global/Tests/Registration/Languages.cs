using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages.Client_area;
using UITestDirect2.Core.Pages.Registration;


namespace UITestDirect2
{
    [TestFixture]
    public partial class UITestDirect2Global
    {
        [Test]
        [TestCase("en")]
        [Description("Changing all languages step by step")]
        public void Languages(string lng)
        {
            PageLogin pageLogin = new PageLogin(webDriver, lng);

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngAr.Click();
            Wait.UrlContains(webDriver, "/ar/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "تسجيل");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngTh.Click();
            Wait.UrlContains(webDriver, "/th/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "สมัครสมาชิก");         

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngPt.Click();
            Wait.UrlContains(webDriver, "/pt/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "Registo");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngRu.Click();
            Wait.UrlContains(webDriver, "/ru/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "Регистрация");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngJa.Click();
            Wait.UrlContains(webDriver, "/ja/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "登録");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngVi.Click();
            Wait.UrlContains(webDriver, "/vi/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "Đăng ký");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngId.Click();
            Wait.UrlContains(webDriver, "/id/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "Daftar");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngMs.Click();
            Wait.UrlContains(webDriver, "/ms/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "Mendaftar");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngZh.Click();
            Wait.UrlContains(webDriver, "/zh/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "注册");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngEs.Click();
            Wait.UrlContains(webDriver, "/es/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "Registro");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngKo.Click();
            Wait.UrlContains(webDriver, "/ko/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "등록");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngCs.Click();
            Wait.UrlContains(webDriver, "/cs/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "Zaregistrovat se");

            pageLogin.ShowLngPanel();
            pageLogin.BtnLngEn.Click();
            Wait.UrlContains(webDriver, "/en/login");
            Wait.TextToBePresentInElement(webDriver, pageLogin.LnkRegister, "Register");

        }
    }
}
