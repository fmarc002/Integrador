using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class Row : ClickableControl
    {
        public Row()
        {

        }

        public Row(By locator)
            :base(locator)
        {}

        
    }
}
