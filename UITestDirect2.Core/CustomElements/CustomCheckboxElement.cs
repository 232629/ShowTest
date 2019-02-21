using System;
using OpenQA.Selenium;
 

namespace UITestDirect2.Core.CustomElements
{
    public class CustomCheckboxElement
    {
        private readonly IWebElement checkboxElement;

        /// <summary>
        /// Take element under input (label class="custom-checkbox d-flex align-items-center" for="knowledge-map-0"). 
        /// Format "label.custom-checkbox[for=knowledge-map-0]"
        /// </summary>
        /// <param name="checkbox"></param>
        public CustomCheckboxElement(IWebElement checkbox)
        {
            checkboxElement = checkbox;
        }

        public void Click()
        {
            checkboxElement.FindElements(By.TagName("span"))[0].Click();
        }

        public bool Selected
        {
            get { return checkboxElement.FindElement(By.TagName("input")).Selected; }
        }

        public bool Enabled
        {
            get { return checkboxElement.FindElement(By.TagName("input")).Enabled; }
        }

        public bool Displayed
        {
            get { return checkboxElement.FindElement(By.TagName("input")).Displayed; }
        }

    }
}
