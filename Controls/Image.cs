using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class Image : BaseControl
    {

        public Image()
        {

        }

        public Image(By locator)
            :base(locator)
        {}
    }
}
