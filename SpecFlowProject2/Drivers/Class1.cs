using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using SpecFlowProject2.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Drivers
{
    public class Class1
    {
        public static AppiumLocalService Service;

        public void startappiumserver(AppiumLocalService service)
        {
            service = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            service.Start();
        }
        public void stopappiumserver(AppiumLocalService service)
        {
            if (service == null)
            {
                service.Dispose();
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
           public static void capabilities()
           {
               var appiumOptions = new AppiumOptions();
               var capabilitiesJson = File.ReadAllText("C:\\Users\\iray3\\source\\repos\\SpecFlowProject2\\Capabilities.json");
               AppiumCapabilities capabilities = JsonConvert.DeserializeObject<AppiumCapabilities>(capabilitiesJson);
               appiumOptions.AddAdditionalCapability("platformName", capabilities.platformName );
               appiumOptions.AddAdditionalCapability("deviceName", capabilities.deviceName);
               appiumOptions.AddAdditionalCapability("udid",capabilities.udid );
               appiumOptions.AddAdditionalCapability("Appium Server Address", capabilities.AppiumServerAddress);
               appiumOptions.AddAdditionalCapability("app", capabilities.app);
               appiumOptions.AddAdditionalCapability("appPackage",capabilities.appPackage);
               var httpClient = new HttpClient();
                 {
                httpClient.Timeout = TimeSpan.FromSeconds(120);
                 }
                var commandExecutor = new HttpCommandExecutor(new Uri("http://localhost:4723/wd/hub"), TimeSpan.FromSeconds(120));
                driverinstance._driver = new AndroidDriver<AndroidElement>(commandExecutor, appiumOptions);

        }
           
    }
}
    

