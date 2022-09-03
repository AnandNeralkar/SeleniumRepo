using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.CommonFile
{
    internal class EnvironmentVariables
    {
        private static string sBrowser = "";
        private static string sUrl = "";
        private static string sfilePath_IE = string.Empty;
        private static string sfilePath_Excel = string.Empty;
        private static string sfilePath_TestResult = string.Empty;
        private static string sScenario = string.Empty;
        private static string sProject = string.Empty;
        private static string sProjectCode = string.Empty;
        private static string sVersion = string.Empty;
        private static String sfilePath_Excel_FailedTCs = string.Empty;
        private static string screenShotsFolderPath = "";
        private static string sHomeUrl = "";
        private static string sFilePath_Resources = "";
        private static string filePath_TestLogFile = string.Empty;
        private static string filePath_MainLogFile = string.Empty;
        private static string filePath_ScreenShotFile = string.Empty;
        public static string Browser
        {
            get { return sBrowser; }
            set { sBrowser = value; }
        }
       

        public static string Project
        {
            get { return sProject; }
            set { sProject = value; }
        }
        public static string ProjectCode
        {
            get { return sProjectCode; }
            set { sProjectCode = value; }
        }
        public static string HomeURL
        {
            get { return sHomeUrl; }
            set { sHomeUrl = value; }
        }
        public static string Version
        {
            get { return sVersion; }
            set { sVersion = value; }
        }

        public static string URL
        {
            get { return sUrl; }
            set { sUrl = value; }
        }
        public static string filePath_IE
        {
            get { return sfilePath_IE; }
            set { sfilePath_IE = value; }
        }
        public static string filePath_Excel
        {
            get { return sfilePath_Excel; }
            set { sfilePath_Excel = value; }
        }
        public static string filePath_TestResult
        {
            get { return sfilePath_TestResult; }
            set { sfilePath_TestResult = value; }
        }
        public static string Scenario
        {
            get { return sScenario; }
            set { sScenario = value; }
        }

        public static string ScreenShotsFolderPath
        {
            get { return screenShotsFolderPath; }
            set { screenShotsFolderPath = value; }
        }
        public static string filePath_Excel_FailedTCs
        {
            get { return sfilePath_Excel_FailedTCs; }
            set { sfilePath_Excel_FailedTCs = value; }
        }
        public static string FilePath_Resources
        {
            get { return sFilePath_Resources; }
            set { sFilePath_Resources = value; }

        }
        //public static string FilePath_TestResult
        //{
        //    get { return filePath_TestResult; }
        //    set { filePath_TestResult = value; }
        //}
        public static string FilePath_TestLogFile
        {
            get { return filePath_TestLogFile; }
            set { filePath_TestLogFile = value; }
        }
        public static string FilePath_MainLogFile
        {
            get { return filePath_MainLogFile; }
            set { filePath_MainLogFile = value; }
        }
        public static string FilePath_ScreenShotFile
        {
            get { return filePath_ScreenShotFile; }
            set { filePath_ScreenShotFile = value; }
        }
   }
}
