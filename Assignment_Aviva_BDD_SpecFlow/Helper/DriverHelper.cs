using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Aviva_BDD_SpecFlow.Helper
{
    public class DriverHelper
    {
        public static IWebDriver driver;
        public static void SetBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public static void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
