using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using TechTalk.SpecFlow;
using BoDi;
using SpecFlowProject2.StepDefinitions;
using OpenQA.Selenium.Remote;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using SpecFlowProject2.utility;
using OpenQA.Selenium.Appium.Service;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace SpecFlowProject2.Hooks
{
    [Binding]
    public sealed class Hooks1 : ExtentReport
    {
       
        private AppiumDriver<AndroidElement> driver;
        private readonly IObjectContainer _container;//declares a private field named _container of type IObjectContainer
        public Hooks1(IObjectContainer container)//iobject container allows sharing of objects within specflow scenarios ,Constructor for the "Hooks1" class which takes an "IObjectContainer" parameter
        {
            _container = container;
        }
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {   
            var appiumOptions = new AppiumOptions();


            var capabilitiesJson = File.ReadAllText("C:\\Users\\iray3\\source\\repos\\SpecFlowProject2\\Capabilities.json");
            AppiumCapabilities capabilities = JsonConvert.DeserializeObject<AppiumCapabilities>(capabilitiesJson);
            appiumOptions.AddAdditionalCapability("platformName", capabilities.platformName);
            appiumOptions.AddAdditionalCapability("deviceName", capabilities.deviceName);
            appiumOptions.AddAdditionalCapability("udid", capabilities.udid);
            appiumOptions.AddAdditionalCapability("Appium Server Address", capabilities.AppiumServerAddress);
            appiumOptions.AddAdditionalCapability("app", capabilities.app);
            appiumOptions.AddAdditionalCapability("appPackage", capabilities.appPackage);
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(240);
            //var commandExecutor = new HttpCommandExecutor(new Uri("http://localhost:4723/wd/hub"),TimeSpan.FromSeconds(180));
            driver = new AndroidDriver<AndroidElement>( appiumOptions);
            _container.RegisterInstanceAs<AppiumDriver<AndroidElement>>(driver);//This allows other parts of the code to access and use the registered driver instance 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driverinstance._driver = driver;
            //steps step = new steps(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);

                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);

                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
            }
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
        public class AppiumCapabilities
        {
            public string platformName { get; set; }
            public string deviceName { get; set; }
            public string udid { get; set; }
            public string app { get; set; }
            public string appPackage { get; set; }

            public string AppiumServerAddress { get; set; }
        }
    }
}