
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Mime;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITestDirect2.Core.Infrastructure;

namespace UITestDirect2.Core.Helpers
{
    /// <summary>
    /// https://seleniumhq.github.io/selenium/docs/api/dotnet/html/T_OpenQA_Selenium_Support_UI_ExpectedConditions.htm
    /// </summary>
    public static class Wait
    {
        public static void WaitUntil(IWebDriver webDriver, Func<IWebDriver, bool> action, double constTimeOut, string errorMesage)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(constTimeOut));
            wait.Message = errorMesage;

            try
            {
                wait.Until(action);
            }
            catch (WebDriverTimeoutException e)
            {
                Log.Error(wait.Message);
                throw;
            }
        }
        
        /// <summary>
        /// An expectation for the URL of the current page to be a specific URL.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="partUrl"></param>
        /// <param name="timeout"></param>
        public static void UrlContains(IWebDriver webDriver, string partUrl, double timeout = 20)
        {
            WaitUntil(webDriver, SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(partUrl), timeout, $"Url '{partUrl}' was not found. Current page is '{webDriver.Url}'");
        }

        /// <summary>
        /// An expectation for the URL of the current page to be a specific URL.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="partUrl"></param>
        /// <param name="timeout"></param>
        public static void UrlMatches(IWebDriver webDriver, string partUrl, double timeout = 20)
        {
            WaitUntil(webDriver, SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches(partUrl), timeout, $"Url '{partUrl}' was not found. Current page is '{webDriver.Url}'");
        }

        /// <summary>
        /// An expectation for checking if the given text is present in the specified element.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="element"></param>
        /// <param name="text"></param>
        /// <param name="timeout"></param>
        public static void TextToBePresentInElement(IWebDriver webDriver, IWebElement element, string text, double timeout = 10)
        {
            WaitUntil(webDriver, SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, text), timeout, $"Text '{text}' was not found for element '{element}'.");
        }

        /// <summary>
        /// An expectation for checking that a value attribute of element equal expected value.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="element"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        /// <param name="timeout"></param>
        public static void AttributeElementValue(IWebDriver webDriver, IWebElement element, string attributeName, string attributeValue, double timeout = 10)
        {
            ElementIsVisible(webDriver, element);
            WaitUntil(webDriver, (d) => element.GetAttribute(attributeName) == attributeValue, timeout, $"Attribute value '{attributeValue}' was not found for attribute name '{attributeName}'. Element '{element}'.");
        }

        /// <summary>
        /// An expectation for checking that an element is invisible.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="element"></param>
        /// <param name="timeout"></param>
        public static void ElementIsInvisible(IWebDriver webDriver, IWebElement element, double timeout = 10)
        {
            WaitUntil(webDriver, (d) => { return !element.Displayed; }, timeout, $"Elemen '{element}' is visible.");
        }

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page and visible. Visibility means that the element is not only displayed but also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="element"></param>
        /// <param name="timeout"></param>
        public static IWebElement ElementIsVisible(IWebDriver webDriver, IWebElement element, double timeout = 10)
        {
            var elements = new List<IWebElement> { element };
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            wait.Message = $"Elemen '{element}' is not visible.";
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements.AsReadOnly()));
                return element;
            }
            catch (WebDriverTimeoutException e)
            {
                Log.Error(wait.Message);
                throw;
            }

        }

    }
}
