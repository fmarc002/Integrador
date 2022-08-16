using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Integrador
{
    public class ResultExam : BasePageObject
    {
        public ResultExam()
            : base(By.XPath(".//div[contains(@id, 'result')]"))
        { }

        public Row rowBoxExam => this.Container.NewControl<Row>(By.XPath(".//*[contains(@class,'col-md-4ng-scope')]"));


        public IEnumerable<Row> RowResultsList
        {
            get
            {
                var xpath = ".//*[contains(@class,'col-md-4 ng-scope')]";
                var result = new List<Row>();
                var element = this.Container.FindElements(By.XPath(".//*[contains(@class,'col-md-4 ng-scope')]"));
                var count = element.Count();

                for (int i = 0; i < count; i++)
                {
                    result.Add(new Row(By.XPath($"{xpath}[{i + 1}]")));
                }

                return result;
            }

        }

        public IEnumerable<Label> ExamTecnicoList
        {
            get
            {
                var elements = this.Container.FindElements(By.XPath(".//h3[contains(@class,'ng-binding')]"));

                var count = elements.Count();
                var resultTecnico = new List<Label>();

                foreach (var element in elements)
                {
                    //creo una variable elementText para que no tenga que ir varias veces al browser a buscarlo
                    var elementText = element.Text;
                    if (elementText.Contains("Técnico") || elementText.Contains("Testing") || elementText.Contains("Testing Técnico"))
                    {
                        resultTecnico.Add(new Label(element));
                    }
                }

                //otra forma era
                //for (int i = 0; i < count; i++)
                //{
                //    var elementText = elements[i].Text;
                //    if (elementText.Contains("Técnico") || elementText.Contains("Testing") || elementText.Contains("Testing Técnico"))
                //    {
                //        resultTecnico.Add((Row)elements[i]);
                //    }
                //}

                return resultTecnico;
            }
        }

        public IEnumerable<String> TecnicoResultExam
        {
            get
            {
                var elements = this.Container.FindElements(By.XPath(".//h3[contains(@class,'ng-binding')]"));

                var count = elements.Count();
                var resultTecnico = new List<String>();

                foreach (var element in elements)
                {
                    //creo una variable elementText para que no tenga que ir varias veces al browser a buscarlo
                    var elementText = element.Text;
                    if (elementText.Contains("Técnico") || elementText.Contains("Testing") || elementText.Contains("Testing Técnico"))
                    {
                        resultTecnico.Add(elementText);
                    }
                    //else if (elementText.Contains("Lógica") || elementText.Contains("Inglés"))
                    //{
                    //    resultTecnico.Add(elementText);
                    //}
                }

                return resultTecnico;

            }
        }

        public void ClickResultExam(String test)
        {

            var elements = this.Container.FindElements(By.XPath(".//h3[contains(@class,'ng-binding')]"));
            var resultExam = new List<Label>();

            foreach (var element in elements)
            {
                var elementText = element.Text;
                
                 if (elementText.Contains(test))
                {
                    resultExam.Add(new Label(element));
                    var elementoClick = element.NewControl<Button>(By.XPath(".//following-sibling::button"));
                    elementoClick.Click();
                   
                }
            }
        }

        public bool CheckDoneResultExam(String test)
        {

            
            var elements = this.Container.FindElements(By.XPath(".//h3[contains(@class,'ng-binding')]"));
            var resultExam = new List<Label>();

            foreach (var element in elements)
            {
                var elementText = element.Text;

                if (elementText.Contains(test))
                {
                    resultExam.Add(new Label(element));
                    
                    var elementoDone= element.NewControl<Label>(By.XPath(".//following-sibling::div[contains(@class,'examen-realizado')]/p"));
                    if (elementoDone.Text.Contains("Completado"))
                    {
                        return true;
                    }                       

                }
            }
            return false;
        }
       
    }
}
