using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
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
        public void GetRegistrationJurisdictions()
        {
            #region Test Data
            JObject expectedResponse = JObject.Parse(System.IO.File.ReadAllText(jsonResponses + "GetRegistrationJurisdictions.json"));
            #endregion

            JObject actualResponse;
            ApiHelper.GetRegistrationJurisdictions(BaseUrlApi, out actualResponse);

            var resultDif = ObjectDiffPatch.GenerateDiff(expectedResponse, actualResponse);
            if (!resultDif.AreEqual)
                Log.Error(String.Format("\r\nExpected response \r\n {0}\r\n\r\nActual response \r\n{1}\r\n", expectedResponse, actualResponse));
            Assert.IsTrue(resultDif.AreEqual, String.Format("Expected response and Actual response see in log.\nOldValues:\n{0}\nNewValues:\n{1}", resultDif.OldValues, resultDif.NewValues));

        }
    }
}
