using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class RadioButton : ClickableControl
    {

        public RadioButton()
        {

        }

        public RadioButton(By locator)
            :base(locator)
        {}
    }
}
