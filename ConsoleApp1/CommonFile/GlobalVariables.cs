using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CommonFile
{
    internal class GlobalVariables
    {
        public static ExtentSparkReporter sparkReporter = null;
        public static ExtentReports eReports = null;
        public static ExtentTest eLogger = null;
        public static int iStep;
        public static string testCaseId="TestCase01", testCaseName= "TestCase01";
        public static IWebDriver driver;
        public static WebDriverWait wait;

    }
}
