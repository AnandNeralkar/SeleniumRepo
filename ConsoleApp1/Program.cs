using ConsoleApp1.CommonFile;
using ConsoleApp1.TestScripts;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnvironmentVariables.Project = "Demo";
            GlobalMethod.InitializaFilePaths();
            GlobalMethod.SetUpExtentReporter();
            GlobalMethod.CreateTestLogFile(GlobalVariables.testCaseId);
            GlobalMethod.CreateTestInExtentReporter(GlobalVariables.testCaseId, GlobalVariables.testCaseName);

            GlobalVariables.driver = new ChromeDriver();
            GlobalVariables.wait = new OpenQA.Selenium.Support.UI.WebDriverWait(GlobalVariables.driver, TimeSpan.FromSeconds(20));

            TestCase01 testCase01 = new TestCase01();
            testCase01.GetDemo();
            GlobalMethod.FinalizeExtentReport();
            GlobalVariables.driver.Quit();
         
        }
    }
}
