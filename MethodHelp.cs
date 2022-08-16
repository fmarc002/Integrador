using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Integrador
{
    public static class MethodHelp
    {


        public static string GetAttributeOrEmpty(this IWebElement element, string attributeName)
        {
            try
            {
                string result = element.GetAttribute(attributeName) ?? string.Empty;
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static TimeOnly TimeExam(string[] dataTime)
        {
            var timeString = "00:" + dataTime[1] + ":" + dataTime[2];
            var time = TimeOnly.Parse(timeString);
            return time;
        }


        public static bool ExplicitWaitUntil(this IWebDriver driver, Func<bool> func, TimeSpan timeout)
        {
            try
            {
                return new WebDriverWait(driver,timeout).Until(x=>func());
            }
            catch
            {
                return false;
            }
        }
    }
}
