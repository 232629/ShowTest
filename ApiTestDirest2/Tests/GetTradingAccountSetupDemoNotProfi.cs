using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;

namespace ApiTestDirest2
{
    [TestFixture]
    public partial class ApiTestDirect2
    {
        [Test]
        [TestCase("mena", "AE", "mt4m")]
        [TestCase("mena", "AE", "xtrader")]

        public void GetTradingAccountSetupDemoNotProfi(string authority, string country, string platform)
        {
            #region Test Data
            Dictionary<string, string> expList = new Dictionary<string, string>();
            expList.Add("mena_AE_mt4m", System.IO.File.ReadAllText(jsonResponses + "GetTradingAccountSetupDemoNotProfi.authority=mena.country=AE.platform=mt4m.json", Encoding.Default));
            expList.Add("mena_AE_xtrader", System.IO.File.ReadAllText(jsonResponses + "GetTradingAccountSetupDemoNotProfi.authority=mena.country=AE.platform=xtrader.json", Encoding.Default));

            JObject expectedResponse = JObject.Parse(expList[authority + "_" + country + "_" + platform]);
            #endregion

            JObject actualResponse;
            ApiHelper.GetTradingAccountSetup(BaseUrlApi, "false", "false", authority, country, platform, out actualResponse);

            var resultDif = ObjectDiffPatch.GenerateDiff(expectedResponse, actualResponse);
            if (!resultDif.AreEqual)
                Log.Error(String.Format("\r\nExpected response \r\n {0}\r\n\r\nActual response \r\n{1}\r\n", expectedResponse, actualResponse));
            Assert.IsTrue(resultDif.AreEqual, String.Format("Expected response and Actual response see in log.\nOldValues:\n{0}\nNewValues:\n{1}", resultDif.OldValues, resultDif.NewValues));

        }
    }
}
