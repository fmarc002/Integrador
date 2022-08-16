using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class AlertMessage :BasePageObject
    {
        public AlertMessage()
            :base(By.CssSelector(".caja-general-alerta"))
        {}

        public Label firstAlertNotif => this.Container.NewControl<Label>(By.CssSelector(".alert-secondary"));


        public Button btnCloseMessage => this.Container.NewControl<Button>(By.CssSelector(".alerta-aviso > span.alerta"));
   

    }
}
