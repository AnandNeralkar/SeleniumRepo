using ConsoleApp1.CommonFile;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TestScripts
{
    internal class TestCase01
    {
       
        public void GetDemo()
        {
            GlobalVariables.testCaseName = "TestCase01";
            EnvironmentVariables.URL = "https://www.liberis.com/";
            
            try
            {
               
                //go to URL
                GlobalVariables.driver.Navigate().GoToUrl(EnvironmentVariables.URL);
                GlobalVariables.driver.Manage().Window.Maximize();
                GlobalVariables.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Your Global Partner For Embedded Business Finance | Liberis"));
                GlobalVariables.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div/a[@class='btn']")));
                Utility.FieldOperation("Button", GlobalVariables.driver.FindElement(By.XPath("//div/a[@class='btn']")), "");
                GlobalVariables.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Become A Partner | Liberis"));
                GlobalVariables.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div/a[@class='btn']")));
                Utility.FieldOperation("Button", GlobalVariables.driver.FindElement(By.XPath("//a[@class='btn btn--medium js-partner-hero-button']")), "");
                // //div[@class='ph-error-inner']
                string message=Utility.GetFieldText("Label", GlobalVariables.driver.FindElement(By.XPath("//div[@class='ph-error-inner']")));
                if (message.Equals("Please select a type of partner"))
                {
                    GlobalMethod.Logger(TestStatus.Pass, "Demo", $"Validation Message Display On Screen:{message}");
                }
                else
                {
                    GlobalMethod.Logger(TestStatus.Fail, "Deom", "validation Message not Display on GetDeom Screen");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                GlobalMethod.Logger(TestStatus.Fail, "Demo", ex.Message, ex);
            }
        }
    }
}
