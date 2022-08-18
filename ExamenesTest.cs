using OpenQA.Selenium;
using Xunit;
using OpenQA.Selenium.Support.UI;


namespace Integrador
{
    public class ExamenesTest : BaseTest
    {
        private const String loginUrl = "http://hxv-evaluaciondev.interview.hexacta.com";

        public ExamenesTest()
        {

        }


        //Login to the candidate site platform with a username and password
        [Fact]
        public void test_Id_73028()
        {
            this.GoToUrl(loginUrl);
            var loginExamenes = new LoginExamenes();
            Assert.True(loginExamenes.HasLoaded());

            loginExamenes.Login("testingAcademy_040", "abc123");

            var resultExam = new ResultExam();
            Assert.True(resultExam.HasLoaded());

        }

        //Verify that the candidate has one or more exams but only one associated technical exam
        [Fact]
        public void test_Id_73073()
        {
            this.GoToUrl(loginUrl);
            var loginExamenes = new LoginExamenes();
            Assert.True(loginExamenes.HasLoaded());

            loginExamenes.Login("testingAcademy_040", "abc123");

            var resultExam = new ResultExam();
            Assert.True(resultExam.HasLoaded());

            //Verify that the candidate has one or more exams but only one associated technical exam
            Assert.True(resultExam.RowResultsList.Count() >= 1);
           
            //only one associated technical exam
            Assert.True(resultExam.ExamTecnicoList.Count().Equals(1));
            Assert.Contains<String>("Técnico", resultExam.TecnicoResultExam);

        }

        //The candidate has associated exams and selects one to take
        [Fact]
        public void test_Id_73075()
        {
            this.GoToUrl(loginUrl);
            var loginExamenes = new LoginExamenes();
            Assert.True(loginExamenes.HasLoaded());

            loginExamenes.Login("testingAcademy_040", "abc123");

            var resultExam = new ResultExam();
            Assert.True(resultExam.HasLoaded());

            //Verify that the candidate has one or more exams but only one associated technical exam
            Assert.True(resultExam.RowResultsList.Count() >= 1);

            resultExam.ClickResultExam("Técnico");

            var testSelection = new TestSelection();
            Assert.True(testSelection.HasLoaded());

            var alertMessage = new AlertMessage();
            Assert.True(alertMessage.HasLoaded());

            var showMessage = alertMessage.firstAlertNotif.GetAttributeOrEmpty("ng-show");
            Assert.Contains("stateStart", showMessage);

            var actualMessage = alertMessage.firstAlertNotif.GetAttributeOrEmpty("innerText").Trim().Replace("\r\n", " ");
            var expectedMessage = "EL TIEMPO DEL EXAMEN YA EMPEZÓ A CORRER . Si abandonás el examen, seguirá corriendo.";
            Assert.Contains(expectedMessage, actualMessage);

        }

        //The candidate completes an exam
        [Fact]
        public void test_Id_73077()
        {
            this.GoToUrl(loginUrl);
            var loginExamenes = new LoginExamenes();
            Assert.True(loginExamenes.HasLoaded());

            loginExamenes.Login("testingAcademy_041", "abc123");

            var resultExam = new ResultExam();
            Assert.True(resultExam.HasLoaded());

            //Verify that the candidate has one or more exams but only one associated technical exam
            Assert.True(resultExam.RowResultsList.Count() >= 1);

            resultExam.ClickResultExam("Técnico");

            var testSelection = new TestSelection();
            Assert.True(testSelection.HasLoaded());

            var alertMessage = new AlertMessage();
            Assert.True(alertMessage.HasLoaded());

            var actualMessage = alertMessage.firstAlertNotif.GetAttributeOrEmpty("innerText").Trim().Replace("\r\n", " ");
            var expectedMessage = "EL TIEMPO DEL EXAMEN YA EMPEZÓ A CORRER . Si abandonás el examen, seguirá corriendo.";
            Assert.Contains(expectedMessage, actualMessage);

            var btnCloseMessage = alertMessage.btnCloseMessage.GetAttributeOrEmpty("onclick");
            Assert.Contains("display='none'", btnCloseMessage);
            alertMessage.btnCloseMessage.Click();

            //calcular el primer tiempo del exam y compararlo a los 10seg con el nuevo tiempo, si es menor al segundo tiempo pasa
            TimeOnly firstActualDataTime = testSelection.Time();
            Assert.True(WaitForElapsedTime(firstActualDataTime, TimeSpan.FromSeconds(10)));

            //SECCIÓN 1
            String seccion_1 = "Sección I";
            Assert.Contains(seccion_1.ToUpper(), testSelection.lblSeccion_1.Text);

            //pregunta 1 - sección 1
            Assert.Contains("estructura de datos", testSelection.lbl_question_1.Text);

            String valueAnswer1_sec1 = testSelection.radSec1_3_Answ_1.GetAttributeOrEmpty("value");
            Assert.Contains("Arbol (Tree)", valueAnswer1_sec1);
            testSelection.radSec1_3_Answ_1.Click();

            //pregunta 5 - sección 1
            Assert.True(testSelection.lbl_question_1.Displayed);
            Assert.True(testSelection.imgSec1_question_5.Displayed);

            String valueAnswer5_sec1 = testSelection.radSec1_Answ_5.GetAttributeOrEmpty("value");
            Assert.Contains("12", valueAnswer5_sec1);
            testSelection.radSec1_Answ_5.Click();

            //botón "siguiente" y botón "atras"
            testSelection.btnNext.Click();
            testSelection.btnBack.Click();
            //verificar que estan seleccionado las respuestas
            Assert.True(testSelection.radSec1_3_Answ_1.Selected);
            Assert.True(testSelection.radSec1_Answ_5.Selected);

            //SECCIÓN 2
            testSelection.btnNext.Click();
            Assert.True(testSelection.HasLoaded());
            String seccion_2 = "Sección II";
            Assert.Contains(seccion_2.ToUpper(), testSelection.lblSeccion_2.Text);

            //pregunta 1 - sección 2
            Assert.Contains("POO", testSelection.lbl_question_1.Text);

            String valueAnswer1_sec2 = testSelection.radSec2_Answ_1.GetAttributeOrEmpty("value");
            Assert.Contains("Un paradigma de programación", valueAnswer1_sec2);
            testSelection.radSec2_Answ_1.Click();

            //pregunta 5 - sección 2
            Assert.True(testSelection.lbl_question_5.Displayed);

            //pregunta 5 - sección 2 - opc. a)
            Assert.True(testSelection.lblSec2_question5_1.Displayed);
            String valueAnswer5_sec2_a = testSelection.radSec2_qs5_answ1.GetAttributeOrEmpty("value");
            Assert.Contains("v", valueAnswer5_sec2_a);
            testSelection.radSec2_qs5_answ1.Click();

            //pregunta 5 - sección 2 - opc. b)
            Assert.True(testSelection.lblSec2_question5_2.Displayed);
            String valueAnswer5_sec2_b = testSelection.radSec2_qs5_answ2.GetAttributeOrEmpty("value");
            Assert.Contains("f", valueAnswer5_sec2_b);
            testSelection.radSec2_qs5_answ2.Click();

            //pregunta 5 - sección 2 - opc. c)
            Assert.True(testSelection.lblSec2_question5_3.Displayed);
            String valueAnswer5_sec2_c = testSelection.radSec2_qs5_answ3.GetAttributeOrEmpty("value");
            Assert.Contains("Ns/Nc", valueAnswer5_sec2_c);
            testSelection.radSec2_qs5_answ3.Click();

            //SECCIÓN 3
            testSelection.btnNext.Click();
            Assert.True(testSelection.HasLoaded());
            String seccion_3 = "Sección III";
            Assert.Contains(seccion_3.ToUpper(), testSelection.lblSeccion_3.Text);

            //pregunta 1 - sección 3
            Assert.Contains("base de datos", testSelection.lbl_question_1.Text);

            String valueAnswer1_sec3 = testSelection.radSec1_3_Answ_1.GetAttributeOrEmpty("value");
            Assert.Contains("Para reducir el espacio ocupado por la base", valueAnswer1_sec3);
            testSelection.radSec1_3_Answ_1.Click();

            //SECCIÓN 4
            testSelection.btnNext.Click();
            Assert.True(testSelection.HasLoaded());
            String seccion_4 = "Sección IV";
            Assert.Contains(seccion_4.ToUpper(), testSelection.lblSeccion_4.Text);

            //pregunta 1 - sección 4
            Assert.Contains("algoritmo de búsqueda", testSelection.lbl_question_1.Text);

            String valueAnswer1_sec4 = testSelection.radSec1_3_Answ_1.GetAttributeOrEmpty("value");
            Assert.Contains("Pruebo el algoritmo con una lista vacía", valueAnswer1_sec4);
            testSelection.radSec1_3_Answ_1.Click();

            //comentario
            String comentario = "Esta pregunta no está redactada";
            Assert.Empty(testSelection.comboxComment_sec4.Text);
            testSelection.comboxComment_sec4.Write(comentario);
            
            //Valido que el contenido del textarea tiene lo escribí en el paso anterior
            Assert.Contains("pregunta",testSelection.comboxComment_sec4.GetAttributeOrEmpty("value"));

            testSelection.btnSave.Click();

            //mensaje de fin del examen
            String finalExamExpected = "Gracias";
            Assert.Contains(finalExamExpected.ToUpper(), testSelection.lblFinalExam.Text);

            //The user click on "Volver a los exámenes" button.
            testSelection.btnFinalExam.Click();
            Assert.True(resultExam.CheckDoneResultExam("Técnico"));

        }

        [Fact]
        public void test_checkDoneTest()
        {
            this.GoToUrl(loginUrl);
            var loginExamenes = new LoginExamenes();
            Assert.True(loginExamenes.HasLoaded());

            loginExamenes.Login("testingAcademy_041", "abc123");

            var resultExam = new ResultExam();
            Assert.True(resultExam.HasLoaded());

            //Verify that the candidate has one or more exams but only one associated technical exam
            Assert.True(resultExam.RowResultsList.Count() >= 1);
            Assert.True(resultExam.CheckDoneResultExam("Técnico"));

        }


        [Fact]
        public void test_checkTimeTest()
        {
            this.GoToUrl(loginUrl);
            var loginExamenes = new LoginExamenes();
            Assert.True(loginExamenes.HasLoaded());

            loginExamenes.Login("testingAcademy_041", "abc123");

            var resultExam = new ResultExam();
            Assert.True(resultExam.HasLoaded());

            //Verify that the candidate has one or more exams but only one associated technical exam
            Assert.True(resultExam.RowResultsList.Count() >= 1);

            resultExam.ClickResultExam("Lógica");

            var testSelection = new TestSelection();
            Assert.True(testSelection.HasLoaded());

            var alertMessage = new AlertMessage();
            Assert.True(alertMessage.HasLoaded());

            var actualMessage = alertMessage.firstAlertNotif.GetAttributeOrEmpty("innerText").Trim().Replace("\r\n", " ");
            var expectedMessage = "EL TIEMPO DEL EXAMEN YA EMPEZÓ A CORRER . Si abandonás el examen, seguirá corriendo.";
            Assert.Contains(expectedMessage, actualMessage);

            var btnCloseMessage = alertMessage.btnCloseMessage.GetAttributeOrEmpty("onclick");
            Assert.Contains("display='none'", btnCloseMessage);
            alertMessage.btnCloseMessage.Click();

            //calcular el primer tiempo del exam y compararlo a los 10seg con el nuevo tiempo, si es menor al segundo tiempo pasa
            TimeOnly firstActualDataTime = testSelection.Time();
           Assert.True(WaitForElapsedTime(firstActualDataTime,TimeSpan.FromSeconds(10)));
        }

        }
}