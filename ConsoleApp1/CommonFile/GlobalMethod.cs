using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.CommonFile
{
    internal class GlobalMethod
    {


     

        public static void InitializaFilePaths()
        {
            string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            EnvironmentVariables.filePath_TestResult = projectDir+"\\TestResult";
            EnvironmentVariables.FilePath_TestLogFile = projectDir + "\\TestResult\\log";
        }

        public static void SetUpExtentReporter()
        {
            try
            {
                

                if (!Directory.Exists(EnvironmentVariables.filePath_TestResult))
                {
                    Directory.CreateDirectory(EnvironmentVariables.filePath_TestResult);
                }
                string reportPath = $"{EnvironmentVariables.filePath_TestResult}\\{EnvironmentVariables.Project}.html";
                GlobalVariables.sparkReporter = new ExtentSparkReporter(reportPath);
                GlobalVariables.sparkReporter.Config.DocumentTitle = $"{EnvironmentVariables.Project}";
                GlobalVariables.sparkReporter.Config.ReportName = $"{EnvironmentVariables.Project}";
                GlobalVariables.eReports = new ExtentReports();
                GlobalVariables.eReports.AttachReporter(GlobalVariables.sparkReporter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void CreateTestLogFile(string testCaseID) // Create serilog file for testscript
        {
            string logfile = $"{EnvironmentVariables.FilePath_TestLogFile}\\{testCaseID}\\{testCaseID}_{DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt")}.txt";
            Log.Logger = new LoggerConfiguration().WriteTo.File(path: logfile).CreateLogger();
        }
        public static void CreateTestInExtentReporter(string testcaseID, string testcaseTitle)
        {
            GlobalVariables.eLogger = GlobalVariables.eReports.CreateTest($"{testcaseID} : {testcaseTitle}");

        }
        public static void FinalizeExtentReport()
        {
            //Clear extentReports obj
            GlobalVariables.eReports.Flush();
            Thread.Sleep(3000); //Required to get updated html report file.
        }
        public static void Logger(TestStatus status, string screenName, string message, [Optional] Exception e)
        {
            switch (status)
            {
                case TestStatus.Pass:
                    Log.Information($"{GlobalVariables.testCaseId} : {screenName} - {message} - {TestStatus.Pass}");

                    GlobalVariables.eLogger.Log(Status.Pass, $"<div style='color:green; font -weight:bold'>{screenName} : {message}</div>");

                    // GlobalVariables.iStep++;
                    break;

                case TestStatus.Info:
                    GlobalVariables.eLogger.Log(Status.Info, $"{screenName} : {message}");

                    GlobalVariables.iStep++;
                    break;

                case TestStatus.Fail:

                    GlobalVariables.eLogger.Log(Status.Fail, $"<div style='color:red; font -weight:bold'>{screenName} : {message}</div>");

                    throw new Exception(e.Message);
                case TestStatus.Warning:


                    GlobalVariables.eLogger.Log(Status.Warning, $"{screenName} : {message}");

                    GlobalVariables.iStep++;


                    break;
                default:

                    break;
            }
        }
    }
}
