using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.CommonFile
{
    internal class Utility
    {

        public static void ClickMenu(string menu)
        {
            Actions action = new Actions(GlobalVariables.driver);

            action.MoveToElement(GlobalVariables.driver.FindElement(By.LinkText(menu))).Click().Perform();
            Thread.Sleep(300);
            
        }
        public static string GetFieldText(string fieldType, IWebElement sLocator)
        {
            string fieldValue = null;
            try
            {
                switch (fieldType)
                {
                    case "TextBox":
                        fieldValue = sLocator.GetAttribute("value");
                        break;

                    case "Button":
                        fieldValue = sLocator.GetAttribute("value");
                        break;

                    case "Label":
                        fieldValue = sLocator.Text;
                        break;

                    case "DropDown":
                        SelectElement sel = new SelectElement(sLocator);
                        fieldValue = sel.SelectedOption.Text;
                        break;

                    case "Span":
                        fieldValue = sLocator.Text;
                        break;
                }
            }
            catch (Exception)
            {
                fieldValue = null;
            }
            return fieldValue;
        }
        
       
        public static void FieldOperation(string sFieldType, IWebElement sLocator, string sValue)
        {
            try
            {
                switch (sFieldType)
                {
                    case "TextBox":
                        try
                        {
                            sLocator.Click();
                            sLocator.Clear();
                            sLocator.SendKeys(Keys.End + sValue);
                            sLocator.SendKeys(Keys.Tab);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            sLocator.SendKeys(Keys.Control + 'a');
                            sLocator.SendKeys(Keys.Backspace);
                            sLocator.SendKeys(sValue);
                            sLocator.SendKeys(Keys.Tab);
                        }
                        break;

                    case "CheckBox":
                        if (sValue.Equals("Check"))
                        {
                            if (!(sLocator.Selected))
                            {
                                sLocator.Click();
                            }
                        }
                        else if (sValue.Equals("Uncheck"))
                        {
                            if (sLocator.Selected)
                            {
                                sLocator.Click();
                            }
                        }
                        break;

                    case "DropDown":
                        SelectElement sel = new SelectElement(sLocator);
                        sel.SelectByText(sValue);
                        break;

                    case "Button":
                        try
                        {
                            sLocator.Click();
                        }
                        catch (ElementClickInterceptedException)
                        {
                            sLocator.SendKeys(Keys.Enter);
                        }
                        break;

                    case "ImageButton":
                        try
                        {
                            sLocator.Click();
                        }
                        catch (ElementClickInterceptedException)
                        {
                            sLocator.SendKeys(Keys.Enter);
                        }
                        break;
                    case "Date":
                        sLocator.Click();
                        sLocator.Clear();
                        sLocator.SendKeys(sValue + Keys.Tab);
                        break;
                }
                //return true;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                GlobalMethod.Logger(TestStatus.Fail, $"Utility.FieldOperation", $"Failed to set value : {e.Message}", e);
            }
        }
    }
}
