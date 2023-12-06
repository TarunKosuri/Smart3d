using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.utility
{
    public class ControlHelpers
    {

        public static void ButtonClick(By locator)
        {
            driverinstance._driver.FindElement(locator).Click();
        }

        public static void EnterText(By locator,string entertext)
        {
            driverinstance._driver.FindElement(locator).SendKeys(entertext);
        }

        public static string GetText(By locator)
        {
          return  driverinstance._driver.FindElement(locator).Text;
        }

        public static void ValidateSlider(string volume,By Sliderlocator, By slidertext)
        {
            Actions action = new Actions(driverinstance._driver);
            AndroidElement slide4 = driverinstance._driver.FindElement(Sliderlocator);
            action.ClickAndHold(slide4).Perform();
            action.MoveByOffset(1, 0).Perform();
            string actual_value = driverinstance._driver.FindElement(slidertext).Text;
            Assert.AreEqual(actual_value, volume);
            action.Release().Perform();
        }
    }
}
