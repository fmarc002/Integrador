using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Xunit;

namespace Integrador
{
    public class LoginExamenes : BasePageObject
    {
        public LoginExamenes()
            : base(By.XPath(".//section[contains(@class, 'login')]"))
        { }

        public Input InputUsername => this.Container.NewControl<Input>(By.XPath(".//*[contains(@id,'log-usuario')]"));

        public Input InputPassword => this.Container.NewControl<Input>(By.XPath(".//*[contains(@id,'log-pwd')]"));

        public Button btnIngresar => this.Container.NewControl<Button>(By.XPath(".//*[contains(@class, 'boton-ingreso')]"));

        public void Login(string user, string password)
        {
            InputUsername.Clear();
            Assert.Empty(InputUsername.Text);
            InputUsername.Write(user);

            InputPassword.Clear();
            Assert.Empty(InputPassword.Text);
            InputPassword.Write(password);

            Assert.True(btnIngresar.Displayed);
            btnIngresar.Click();
        }
    }

}
