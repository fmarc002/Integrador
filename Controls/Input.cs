using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class Input : ClickableControl
    {

        public Input()
        {

        }

        public Input(By locator)
            :base(locator)
        {}

        public string Text => this.WebElement.Text;

        public void Clear()=> this.WebElement.Clear();

        public void Write(string value)
        {
            this.WebElement.SendKeys(value);
        }

    }
}
