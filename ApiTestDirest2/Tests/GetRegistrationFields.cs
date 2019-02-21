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
        [TestCase("mena", "AE")]
        public void GetRegistrationFields(string authority, string country)
        {
            #region Test Data
            Dictionary<string, string> expList = new Dictionary<string, string>();

            expList.Add("mena_AE", System.IO.File.ReadAllText(jsonResponses + "GetRegistrationFields.authority=mena.country=AE.json", Encoding.Default));

            JObject expectedResponse = JObject.Parse(expList[authority + "_" + country]);


            #endregion

            JObject actualResponse;
            ApiHelper.GetRegistrationFields(BaseUrlApi, authority, country, out actualResponse);

            var resultDif = ObjectDiffPatch.GenerateDiff(expectedResponse, actualResponse);
            if (!resultDif.AreEqual)
                Log.Error(String.Format("\r\nExpected response \r\n {0}\r\n\r\nActual response \r\n{1}\r\n", expectedResponse, actualResponse));
            Assert.IsTrue(resultDif.AreEqual, String.Format("Expected response and Actual response see in log.\nOldValues:\n{0}\nNewValues:\n{1}", resultDif.OldValues, resultDif.NewValues));

        }
    }
}
