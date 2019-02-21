using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UITestDirect2.Core.Infrastructure;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using UITestDirect2.Core.Helpers;

namespace ApiTestDirest2
{
    [TestFixture]
    public partial class ApiTestDirect2
    {
        [Test]
        [Ignore("Obsolate")]
        public void GetConfig()
        {
            #region Test Data
            string email = "848521@testing.test";
            string pass = "Password1";
            JObject expectedResponse = JObject.Parse(System.IO.File.ReadAllText(@"C:\Users\e.kovalenko\Visual Studio 2017\Projects\UITestDirest2\ApiTestDirect2\Resources\Json responses\GetConfig.json"));
            #endregion

            string resposeOut;

            //получаем токин пользователя bb@bb.bb
            ApiHelper.Login(BaseUrlApi, email, pass, out resposeOut);
            

            //звапрашиваем GetConfig для пользователя bb@bb.bb
            JObject actualResponse;
            ApiHelper.GetConfig(BaseUrlApi, resposeOut, out actualResponse);

            var resultDif = ObjectDiffPatch.GenerateDiff(expectedResponse, actualResponse);
            if (!resultDif.AreEqual)
                Log.Error(String.Format("\r\nExpected response \r\n {0}\r\n\r\nActual response \r\n{1}\r\n", expectedResponse, actualResponse));
            Assert.IsTrue(resultDif.AreEqual, String.Format("Expected response and Actual response see in log.\nOldValues:\n{0}\nNewValues:\n{1}", resultDif.OldValues, resultDif.NewValues));

        }
    }
}
