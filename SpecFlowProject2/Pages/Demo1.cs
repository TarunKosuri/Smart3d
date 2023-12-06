using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SpecFlowProject2.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Pages
{
    public class Demo1
    {
        private AppiumDriver<AndroidElement> driver;

        //public Demo1(AppiumDriver<AndroidElement> driver)
        //{ 
        //    this.driver = driver; 
        //}

        public Demo1()

        {
            driver = driverinstance._driver;
        }
        By clickdemo =By.Id("dk.resound.smart3d:id/demo_button");
        
        public popuppage demomode()//clicks on take me to demo mode
        {
            // driver.FindElement(clickdemo).Click();
            ControlHelpers.ButtonClick(clickdemo);
            return new popuppage(driver);
        }
        
    }
}
