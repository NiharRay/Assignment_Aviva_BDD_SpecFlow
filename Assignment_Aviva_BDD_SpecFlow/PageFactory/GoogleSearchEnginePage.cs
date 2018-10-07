using Assignment_Aviva_BDD_SpecFlow.Helper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Aviva_BDD_SpecFlow.PageFactory
{
    public class GoogleSearchEnginePage
    {
        public IWebElement SearchTextBox 
        { 
            get
            {
                return DriverHelper.driver.FindElement(By.Id("lst-ib"));
            }
        }

        public ReadOnlyCollection<IWebElement> SearchResult
        {
            get
            {
                return DriverHelper.driver.FindElements(By.XPath(".//div[@class='rc']/div[@class='r']/a"));
            }
        }

        public IWebElement SearchButton
        {
            get
            {
                return DriverHelper.driver.FindElement(By.Name("btnK"));
            }
        }
    }
}
