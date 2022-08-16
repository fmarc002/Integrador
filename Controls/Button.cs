using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class Button : ClickableControl
    {
        public Button()
        {

        }

        public Button(By locator)
            :base(locator)
        {}

    }
}
