using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Integrador
{
    public class BaseTest: IDisposable
    {
        public BaseTest()
        {

        }

        protected IWebDriver Driver
        {
            get 
            {
                return DriverProvider.Driver;
            }
            
        }

        protected void GoToUrl(string url)
        {
            this.Driver.Navigate().GoToUrl(url);
        }

        public void Dispose()
        {
            DriverProvider.DestroyDriver();
        }

        public void ImplicitWait()
        {
            var defaultTimeOut = TimeSpan.FromSeconds(300);
            this.Driver.Manage().Timeouts().ImplicitWait = defaultTimeOut;
        }

        public bool WaitForElapsedTime(TimeOnly time1,TimeSpan timeout)
        {

            return this.Driver.ExplicitWaitUntil(() => {

                var testSelection = new TestSelection();
                TimeOnly time2 = testSelection.Time();
                return  time1 < time2;
            }, timeout);

        }


    }
}
