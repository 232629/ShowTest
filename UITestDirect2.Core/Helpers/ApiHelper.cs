using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
 
using UITestDirect2.Core.Infrastructure;


namespace UITestDirect2.Core.Helpers
{
    public static class ApiHelper
    {
        public static HttpStatusCode SendRequest(string baseServiceUrl, string request, string method, string body, WebHeaderCollection headers, out string responseBody)
        {
            string uri = string.Format("{0}{1}", baseServiceUrl, request);

            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, policyErrors) => true;

            // create a request
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.KeepAlive = false;
            webRequest.ProtocolVersion = HttpVersion.Version11;
            webRequest.Method = method;
            if (headers != null)
            {
                webRequest.Headers.Add(headers);
            }

            Log.Info("Actual request uri. \n{0}", uri);

            if (webRequest.Method == "POST")
            {
                Log.Info("Actual request body. \n{0}", body);

                byte[] bodyBytes = Encoding.UTF8.GetBytes(body);

                webRequest.ContentType = "application/json";
                webRequest.ContentLength = bodyBytes.Length;
                Stream requestStream = webRequest.GetRequestStream();

                requestStream.Write(bodyBytes, 0, bodyBytes.Length);
                requestStream.Close();
            }

            try
            {
                using (var response = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    using (var reader = responseStream != null ? new StreamReader(responseStream) : null)
                    {
                        responseBody = reader != null ? reader.ReadToEnd() : null;
                        Log.Info("Actual response. \n{0}", responseBody);
                    }
                    return response.StatusCode;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                {
                    Log.Error("Error while sending API request. Response is null.\n{0}", ex);
                    throw;
                }
                using (var response = (HttpWebResponse)ex.Response)
                {
                    using (var responseStream = response.GetResponseStream())
                    using (var reader = responseStream != null ? new StreamReader(responseStream) : null)
                    {
                        responseBody = reader != null ? reader.ReadToEnd() : null;
                        Log.Info("Actual response. \n{0}", responseBody);
                    }
                    return response.StatusCode;
                }
            }
        }





        /// <summary>
        /// Check status MW
        /// </summary>
        /// <returns></returns>
        public static string GetStatusMW()
        {
            string baseServiceUrl = @"http://client-api.int.dev.direct.k8s.local";
            string request = string.Format("/status");
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            Assert.IsTrue(status == HttpStatusCode.OK, "MW is not available. Status = {0}", status);

            return responseBody;
        }

        /// <summary>
        /// Resset cache of ERP and MW
        /// </summary>
        /// <returns></returns>
        public static string ResetCache()
        {
            string baseServiceUrl = @"http://overlord.int.dev.direct.k8s.local";
            string request = string.Format("/solace-endpoint/FxPro/MW/Cache/Invalidate");
            string body = string.Format("{{\"key\":\"/api/Middleware/\"}}");
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "POST", body, headers, out responseBody);
            Assert.IsTrue(status == HttpStatusCode.OK, "ERP is not available. Status = {0}", status);

            return responseBody;
        }

        #region ERP Professional Information

        /// <summary>
        /// ERP: Update client
        /// </summary>
        /// <returns></returns>
        public static string UpdateClientErp(IWebDriver driver, string par, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string userId = (String)js.ExecuteScript("return localStorage.getItem('userId')");

            var headers = new WebHeaderCollection { };
            string baseServiceUrl = @"http://overlord.int.dev.direct.k8s.local";
            string request = string.Format("/solace-endpoint/FxPro/MW/Account/Update");
            string body = string.Format("{{\"uuid\": \"{0}\",\"{1}\": \"{2}\"}}", userId, par, value);
            string responseBody;
            
            var status = SendRequest(baseServiceUrl, request, "POST", body, headers, out responseBody);
            Assert.IsTrue(status == HttpStatusCode.OK, "ERP is not available. Status = {0}", status);

            ResetCache();

            return responseBody;
        }
        
        /// <summary>
        /// SetApprovedForAcceptance. ERP: Professional Information/Internally approved = true
        /// </summary>
        /// <returns></returns>
        public static string SetApprovedForAcceptance(IWebDriver driver)
        {
            return UpdateClientErp(driver, "approvedForAcceptance", "true");
        }

        /// <summary>
        /// SetReassessmentRequested. ERP: Professional Information/Reassessment Requested = true
        /// </summary>
        /// <returns></returns>
        public static string SetReassessmentRequested(IWebDriver driver)
        {
            return UpdateClientErp(driver, "reassessmentRequested", "true");
        }

        #endregion

        #region Obsolete (ApiTestDirest2)

        /// <summary>
        /// It deletes the file selected in JSon field 
        /// </summary>
        /// <param name="token">JObject</param>
        /// <param name="fields">Name deleted fields</param>

        public static void RemoveFields(JToken token, List<string> fields)
        {
            JContainer container = token as JContainer;
            if (container == null) return;

            List<JToken> removeList = new List<JToken>();
            foreach (JToken el in container.Children())
            {
                JProperty p = el as JProperty;
                if (p != null && fields.Contains(p.Name))
                    removeList.Add(el);
                RemoveFields(el, fields);
            }

            foreach (JToken el in removeList)
                el.Remove();
        }

        /// <summary>
        /// Длбавляем корневой объект data и парсим текстовый ответ в обект JObject.
        /// Ко всем expected должен быть добавлен корневой объект data
        /// </summary>
        /// <param name="response">ответ JSON текстом</param>
        /// <returns></returns>
        static JObject ParseInJObject(string response)
        {
            response = response.Trim(new char[] { '[', ']' });
            return JObject.Parse("{\"data\": [" + response + "]}");
        }

        public static HttpStatusCode GetConfig(string baseServiceUrl, string tokin, out JObject response)
        {
            string request = string.Format("api/registration/GetConfig");
            string responseBody;
            var headers = new WebHeaderCollection
            {
                {"Authorization", "Bearer " + tokin.Trim('"')}
            };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            //response = ParseInJObject(responseBody);
            response = JObject.Parse(responseBody);

            return status;
        }

        public static HttpStatusCode GetRegistrationJurisdictions(string baseServiceUrl, out JObject response)
        {
            string request = string.Format("api/Middleware/GetRegistrationJurisdictions");
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            response = ParseInJObject(responseBody);


            return status;
        }

        public static HttpStatusCode GetCurrency(string baseServiceUrl, string currency, string authority, out JObject response)
        {
            string request = string.Format("api/Middleware/getcurrency?currency={0}&authority={1}", currency, authority);
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            response = ParseInJObject(responseBody);

            return status;
        }

        public static HttpStatusCode GetCurrencies(string baseServiceUrl, string vault, out JObject response)
        {
            string request = string.Format("api/Middleware/GetCurrencies?vault={0}", vault);
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            response = ParseInJObject(responseBody);

            return status;
        }

        public static HttpStatusCode GetRegistrationFields(string baseServiceUrl, string authority, string country, out JObject response)
        {
            string request = string.Format("api/Middleware/GetRegistrationFields?authority={0}&country={1}", authority, country);
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            response = ParseInJObject(responseBody);

            return status;
        }

        public static HttpStatusCode GetTradingAccountSetup(string baseServiceUrl, string isReal, string isProfessional, string authority, string country, string platform, out JObject response)
        {
            string request = string.Format("api/Middleware/GetTradingAccountSetup?isReal={0}&isProfessional={1}&authority={2}&country={3}&platform={4}", isReal, isProfessional, authority, country, platform);
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            response = ParseInJObject(responseBody);

            return status;
        }

        public static HttpStatusCode GetPaymentMethods(string baseServiceUrl, string authority, string country, out JObject response)
        {
            string request = string.Format("api/Middleware/GetPaymentMethods?authority={0}&country={1}&sandbox=true", authority, country);
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            response = ParseInJObject(responseBody);

            return status;
        }

        public static HttpStatusCode GetExchangeRates(string baseServiceUrl, string fromCurrency, string toCurrency, out string response)
        {
            string request = string.Format("api/Middleware/getExchangeRates?fromCurrency={0}&toCurrency={1}", fromCurrency, toCurrency);
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out response);

            return status;
        }

        public static HttpStatusCode GetPlatformTradingAccountTypes(string baseServiceUrl, out JObject response)
        {
            string request = string.Format("api/Middleware/GetPlatformTradingAccountTypes");
            string responseBody;
            var headers = new WebHeaderCollection { };

            var status = SendRequest(baseServiceUrl, request, "GET", null, headers, out responseBody);
            response = ParseInJObject(responseBody);

            return status;
        }

        public static HttpStatusCode Login(string baseServiceUrl, string email, string pass, out string responseOut)    //out string responseOut сделать как в GET
        {
            string request = string.Format("api/profile/login");
            string body = string.Format("{{email: \"{0}\", password: \"{1}\"}}", email, pass);
            var headers = new WebHeaderCollection
            {
                {"Accept-Language", "en - US"}
            };

            var status = SendRequest(baseServiceUrl, request, "POST", body, headers, out responseOut);

            return status;
        }

        public static HttpStatusCode Email(string baseServiceUrl, string body, out string responseOut)
        {
            string request = string.Format("api/forgotPassword/sendEmail");

            var headers = new WebHeaderCollection
            {
                {"Accept-Language", "en - US"}
            };

            var status = SendRequest(baseServiceUrl, request, "POST", body, headers, out responseOut);

            return status;
        }

        public static HttpStatusCode CreateNewUser(string baseServiceUrl, string login, string password)
        {
            string request = "api/registration/test/simple";
            string body = string.Format("{{\"email\": \"{0}\",\"password\": \"{1}\"}}", login, password);
            string responseOut;
            var headers = new WebHeaderCollection
            {
                {"Accept-Language", "en - US"}
            };

            var status = SendRequest(baseServiceUrl, request, "POST", body, headers, out responseOut);
            Assert.IsTrue(status == HttpStatusCode.OK, "Create new user is failed. Status = {0}", status);

            return status;
        }
        #endregion


    }

}

