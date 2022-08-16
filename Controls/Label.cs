using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class Label : BaseControl
    {
        public Label()
        {

        }

        public Label(By locator)
            :base(locator)
        {}
        //con esto me permite tomar el elemento ya creado en el metodo ExamTecnicoList
        public Label(IWebElement source)
            :base(source)
        { }

        public string Text => this.WebElement.Text;

    }
}
