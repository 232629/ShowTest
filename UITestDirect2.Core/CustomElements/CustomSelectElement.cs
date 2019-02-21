using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using OpenQA.Selenium;
using UITestDirect2.Core.Infrastructure;


namespace UITestDirect2.Core.CustomElements
{
    public class CustomSelectElement
    {
        private readonly IWebElement selectElement;

        public CustomSelectElement(IWebElement @select)
        {
            selectElement = select;
        }

        public string GetValue()
        {
            return selectElement.Text.Replace("\r\n▼", "");
        }

        public string GetValueAfterClick()
        {
            //Clicking and waiting when dictionary was showed
            selectElement.Click();
            var arrTagLi = selectElement.FindElement(By.CssSelector("select-dropdown>div>div.options")).FindElements(By.TagName("li"));

            foreach (var i in arrTagLi)
            {
                if (i.GetAttribute("class") == "highlighted selected")
                {
                    return i.Text; 
                }
            }
            return null;
        }

        public void SetValueAfterClick(string value)
        {
            //Clicking and waiting when dictionary was showed
            string list = "";
            selectElement.Click();
            var arrTagLi = selectElement.FindElement(By.CssSelector("select-dropdown>div>div.options")).FindElements(By.TagName("li"));

            foreach (var i in arrTagLi)
            {
                if (i.Text.Equals(value))
                {
                    i.Click();            
                    //((IJavaScriptExecutor) webDriver).ExecuteScript("arguments[0].click();", i);
                    return;
                }
                list += "\r\n'" + i.Text + "'";
            }
            var errMsg = "Element is '" + value + "' not found in dropdown. List: " + list;
            Log.Error(errMsg);
            throw new Exception(errMsg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetValueAfterClick(int value)
        {
            //Clicking and waiting when dictionary was showed
            selectElement.Click();
            var arrTagLi = selectElement.FindElement(By.CssSelector("select-dropdown>div>div.options")).FindElements(By.TagName("li"));
            for (int i=0; i<arrTagLi.Count; i++)
            {
                if (i == value)
                {
                    arrTagLi[i].Click();  
                    //((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", arrTagLi[i]);
                    return;
                }
            }
            throw new Exception("Element is number = " + value + " not found in dropdown.");
        }

        public int Count()
        {
            //Clicking and waiting when dictionary was showed
            selectElement.Click();
            var count = selectElement.FindElement(By.CssSelector("select-dropdown>div>div.options")).FindElements(By.TagName("li")).Count;
            selectElement.Click();
            return count;
        }

        public bool IsExist(string value)
        {
            //open list
            selectElement.Click();
            var arrTagLi = selectElement.FindElement(By.CssSelector("select-dropdown>div>div.options")).FindElements(By.TagName("li"));

            foreach (var i in arrTagLi)
            {
                if (i.Text == value)
                {
                    //close list
                    selectElement.Click();
                    return true;
                }
            }
            //close list
            selectElement.Click();
            return false;
        }


        public List<string> GetValuesList()
        {
            //open list
            selectElement.Click();
            var arrTagLi = selectElement.FindElement(By.CssSelector("select-dropdown>div>div.options")).FindElements(By.TagName("li"));
            List<string> arrValuesList  = new List<string>();

            foreach (var i in arrTagLi)
            {
                arrValuesList.Add(i.Text);
            }
            //close list
            selectElement.Click();
            return arrValuesList;
        }


    }
}
