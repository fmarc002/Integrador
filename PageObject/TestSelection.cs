using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class TestSelection : BasePageObject
    {
        public TestSelection()
            : base(By.CssSelector("body.ng-scope"))
        { }

        //RELOJ - TIME
        //public Label lblDataTime => this.Container.NewControl<Label>(By.XPath(".//*[contains(@class,'data-timer')]/p[contains(text(),'Tiempo')]"));
        public Label lblDataTime => this.Container.NewControl<Label>(By.CssSelector(".data-timer .ng-binding"));

        //SECCIONES
        //validar seccion 4
        public Label lblSeccion_4 => this.Container.NewControl<Label>(By.XPath(".//*[contains(text(),'Sección IV')]"));

        //validar seccion 3
        public Label lblSeccion_3 => this.Container.NewControl<Label>(By.XPath(".//*[contains(text(),'Sección III')]"));

        //validar seccion 2
        public Label lblSeccion_2 => this.Container.NewControl<Label>(By.XPath(".//*[contains(text(),'Sección II')]"));

        //validar seccion 1
        public Label lblSeccion_1 => this.Container.NewControl<Label>(By.XPath(".//*[contains(text(),'Sección I')]"));

        //PREGUNTAS

        //validar pregunta 1 seccion 1,2,3 Y 4
        public Label lbl_question_1 => this.Container.NewControl<Label>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][1]/p"));

        //validar pregunta 5 seccion 1 y 2
        public Label lbl_question_5 => this.Container.NewControl<Label>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5]/p"));


        //RESPUESTAS
        //sección 1 Y 3:
        //hacer click en el radio de la pregunta 1 y validar el contenido  "Arbol (Tree)"
        //hacer click en el radio de la pregunta 1 y validar el contenido  "Para reducir el espacio ocupado por la base"
        public RadioButton radSec1_3_Answ_1 => this.Container.NewControl<RadioButton>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][1]/descendant::input[1]"));

        //hacer click pregunta 5 seccion 1
        public RadioButton radSec1_Answ_5 => this.Container.NewControl<RadioButton>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5] //input[contains(@value,'12')]"));
        //otra forma de tomar la respuesta de la pregunta 5
        //public RadioButton radAnswer_5 => this.Container.NewControl<RadioButton>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5]/descendant::input[1]"));

        //sección 2:
        //hacer click en el radio de la pregunta 1 y validar el contenido  Un paradigma de programación
        public RadioButton radSec2_Answ_1 => this.Container.NewControl<RadioButton>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][1]/descendant::input[2]"));
        //pregunta 5, opcion a) respuesta verdadera
        public RadioButton radSec2_qs5_answ1 => this.Container.NewControl<RadioButton>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5] //div[contains(@class,'opcion-vof')][1] //input[contains(@value,'v')]"));

        //pregunta 5, opcion b) respuesta false
        public RadioButton radSec2_qs5_answ2 => this.Container.NewControl<RadioButton>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5] //div[contains(@class,'opcion-vof')][2] //input[contains(@value,'f')]"));

        //pregunta 5, opcion c) respuesta Ns/Nc
        public RadioButton radSec2_qs5_answ3 => this.Container.NewControl<RadioButton>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5] //div[contains(@class,'opcion-vof')][3] //input[contains(@value,'Ns/Nc')]"));


        //IMAGENES PREGUNTAS

        //validar imagen pregunta 5 seccion 1
        public Image imgSec1_question_5 => this.Container.NewControl<Image>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5] //pre[contains(@class,'codigo-pegado')][1]"));
        //otra forma de tomar la imagen
        //public Image image_question_5 => this.Container.NewControl<Image>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5]/descendant::pre[1]"));

        //BOTONES

        //button next seccion1
        public Button btnNext => this.Container.NewControl<Button>(By.XPath(".//button[contains(@class,'boton-next')]"));

        //button save seccion1
        public Button btnSave => this.Container.NewControl<Button>(By.XPath(".//button[contains(@class,'boton-save')]"));

        //button back seccion1
        public Button btnBack => this.Container.NewControl<Button>(By.XPath(".//button[contains(@class,'boton-back')]"));


        //PREGUNTAS INTERNAS
        //seccion 2, pregunta 5 opción a)
        public Label lblSec2_question5_1 => this.Container.NewControl<Label>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5] //div[contains(@class,'opcion-vof')][1]/p"));

        //seccion 2, pregunta 5 opción b)
        public Label lblSec2_question5_2 => this.Container.NewControl<Label>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5] //div[contains(@class,'opcion-vof')][2]/p"));

        //seccion 2, pregunta 5 opción c)
        public Label lblSec2_question5_3 => this.Container.NewControl<Label>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][5] //div[contains(@class,'opcion-vof')][3]/p"));


        //sección 4 - pregunta 1 comentario
        public Input comboxComment_sec4 => this.Container.NewControl<Input>(By.XPath(".//div[contains(@class,'preguntas-tecnicas')][1]/div/textarea"));


        //exam finalizado
        public Label lblFinalExam => this.Container.NewControl<Label>(By.XPath(".//h4[contains(@class,'h4-confirm')]"));
        public Button btnFinalExam => this.Container.NewControl<Button>(By.XPath(".//button[contains(@class,'boton-volver-confirm')]"));

        //time
        public TimeOnly Time(){
               var dataTime = lblDataTime.Text.Split(":");
               var time = MethodHelp.TimeExam(dataTime);
                return time;
            }

    }
}
