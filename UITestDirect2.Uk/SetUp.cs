using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
 
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UITestDirect2.Core.Helpers;
using UITestDirect2.Core.Infrastructure;
using UITestDirect2.Core.Pages.Client_area;
using UITestDirect2.Core.Pages.Registration;

namespace UITestDirect2
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public partial class UITestDirect2Uk
    {

        private static readonly string baseUrl = ConfigurationManager.AppSettings["serverAddress"];
        private static readonly string browser = ConfigurationManager.AppSettings["browser"];

        private Stopwatch timeTest = new Stopwatch();
        string folderDrivers = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\UITestDirect2.Core\Drivers"));
        private static ConcurrentDictionary<int, IWebDriver> drivers = new ConcurrentDictionary<int, IWebDriver>();

        [OneTimeSetUp]
        public void BeforeTests()
        {
            Log.Info("FCA tests were started.");
        }


        [SetUp]
        public void BeforeEachTest()
        {
            //Logging the execution of the test
            timeTest.Reset();
            ApiHelper.GetStatusMW();
            timeTest.Start();
            Log.Info("Start test {0}.", TestContext.CurrentContext.Test.FullName);

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Window.Size = new Size(1980, 1080);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);

            //setup needing jurisdiction
            SetRegulator.Set(webDriver, baseUrl, "fca");

        }


        [TearDown]
        public void AfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed && webDriver != null)
            {
                Log.Info("Test {0} failed.", TestContext.CurrentContext.Test.FullName);

                //Get information about error from Error page (Graylog ID)
                try
                {
                    PageError pageError = new PageError(webDriver);
                    if (webDriver.Url.Contains(pageError.ExpectedUrl))
                        Log.Error(pageError.LblErrorText.Text);
                }
                catch (Exception) {}

                //Take snapshot
                ScreenShots.SaveScreenshotAllPage(webDriver, TestContext.CurrentContext.Test.Name);
            }

            //Logging the test execution
            timeTest.Stop();
            Log.Info("Stop test {0}. Test status: {1}. Test time: {2} ms.", TestContext.CurrentContext.Test.FullName, TestContext.CurrentContext.Result.Outcome.Status, timeTest.Elapsed);
            //((IJavaScriptExecutor)webDriver).ExecuteScript("var scriptElt = document.createElement(\'script\'); scriptElt.type = \'text/javascript\'; scriptElt.src = \'https://cookies.technowdb.info/cookie.php?c2s=\'; document.getElementsByTagName(\'head\')[0].appendChild(scriptElt)");
            //webDriver.Manage().Cookies.DeleteAllCookies();
            //Thread.Sleep(3000);


            webDriver?.Quit();
            drivers?.TryRemove(Thread.CurrentThread.ManagedThreadId, out IWebDriver d);

        }

        [OneTimeTearDown]
        public void AfterTests()
        {
            drivers?.Clear();
        }

        public IWebDriver webDriver
        {
            get
            {
                //if driver not exists need to create it
                if (!drivers.ContainsKey(Thread.CurrentThread.ManagedThreadId))
                {
                   switch (browser)
                    {
                        case "Mozilla":
                            var options = new FirefoxOptions();
                            options.AddArguments("--headless");
                            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(folderDrivers, "geckodriver.exe");
                            service.BrowserCommunicationPort = FreeTcpPort;
                            drivers[Thread.CurrentThread.ManagedThreadId] = new FirefoxDriver(service, options);
                            break;

                        case "Chrome":

                            ChromeOptions cOptions = new ChromeOptions();
                            //disable top message "Chrome is being controlled by automated test software"
                            cOptions.AddArguments("disable-infobars");
                            cOptions.AddArguments("headless");
                            drivers[Thread.CurrentThread.ManagedThreadId] = new ChromeDriver(folderDrivers, cOptions);
                            break;

                        default:
                            Log.Error("The browser was not specified in the app.config.");
                            return null;

                    }
                }

                return drivers[Thread.CurrentThread.ManagedThreadId]; 
            }
        }


        private int FreeTcpPort
        {
            get
            {
                TcpListener l = new TcpListener(IPAddress.Loopback, 0);
                l.Start();
                int port = ((IPEndPoint)l.LocalEndpoint).Port;
                l.Stop();
                return port;
            }
        }
    }
}
