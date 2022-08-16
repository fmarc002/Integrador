using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace Integrador
{
    public class BaseControl
    {

        protected By locator;
        protected IWebDriver driver;
        protected IWebElement source;

        protected Actions Actions => new Actions (this.driver);

        public BaseControl(By locator)
        {
            this.locator = locator;
            this.source = null;
            this.driver = DriverProvider.Driver;
        }

        public BaseControl(IWebElement source)
        {
            this.locator = null;
            this.source=source;
            this.driver = DriverProvider.Driver;
        }

        public BaseControl()
        {
            this.locator=null;
            this.source=null;
            this.driver=DriverProvider.Driver;
        }

        public void SetLocator(By locator)
        {
            this.locator = locator;
        }

        public void SetSource(IWebElement source)
        {
            this.source = source;
        }

        protected IWebElement WebElement
        {
            get
            {
                try
                {
                    if(this.locator is not null)
                    {
                        this.source = this.driver.FindElement(this.locator);
                    }
                    return this.source;
                }
                catch
                {
                    return null;
                }
            }
        } 
        public bool Displayed
        {
            get
            {
                try
                {
                    return this.WebElement.Displayed;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Enabled
        {
            get
            {
                try
                {
                    return this.WebElement.Enabled;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Selected
        {
            get
            {
                try
                {
                    return this.WebElement.Enabled;
                }
                catch
                {
                    return false;
                }
            }
        }

        public string GetAttributeOrEmpty(string attributeName)
        {
            return this.WebElement.GetAttributeOrEmpty(attributeName);
        }
    }
}
