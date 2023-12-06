using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.utility
{
    public class driverinstance
    {
        public static AppiumDriver<AndroidElement> _driver
        {
            get; set; 
        }
    }
}

