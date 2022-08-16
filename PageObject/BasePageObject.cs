using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class BasePageObject
    {

        protected IWebDriver driver;
        protected By locator;
        
        public BasePageObject(By locator)
        {
            this.driver = DriverProvider.Driver;
            this.locator = locator;
            
        }

        public IWebElement Container
        {
            get
            {
                try
                {
                    return this.driver.FindElement(this.locator);
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool HasLoaded()
        {
            try
            {
                return this.Container.Displayed;
            }
            catch
            {
                return false;
            }
        }

    }
    public static class WebElementExtensions
    {
        public static T NewControl<T>(this IWebElement WebElement, By locator)
            where T : BaseControl, new()
        {
            T result = new();
            result.SetLocator(null);
            result.SetSource(WebElement.FindElement(locator));

            return result;
        }


    }

}
