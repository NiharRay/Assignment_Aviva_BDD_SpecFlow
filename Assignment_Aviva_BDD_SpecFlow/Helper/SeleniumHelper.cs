using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;
using System.Collections.ObjectModel;

namespace Assignment_Aviva_BDD_SpecFlow.Helper
{
    public class SeleniumHelper
    {
        private IWebDriver driver ;
        private string keyword = "";
        Validation validate = new Validation();

        /// <summary>
        /// Methods used to get the google search result URL.
        /// </summary>
        /// <param name="sequenceNo">Result sequence number.</param>
        /// <returns>Returns result url of sequence number provided</returns>
        public string GetSearchResult(int sequenceNo)
        {
            try
            {
                string validationMessageSearchKeyword = validate.ValidateSearchKeyword(keyword.Trim());
                if(validationMessageSearchKeyword!="0")
                {
                    throw new Exception(validationMessageSearchKeyword);
                }

                string validationMessageSequenceNumber = validate.ValidateSequenceNo(sequenceNo);
                if (validationMessageSequenceNumber != "0")
                {
                    throw new Exception(validationMessageSequenceNumber);
                }

                //IWebElement resultsPanel = driver.FindElement(By.Id("search"));

                // Get all the links only contained within the search result panel.
                ReadOnlyCollection<IWebElement> searchResults = driver.FindElements(By.XPath(".//div[@class='rc']/h3[@class='r']/a"));

                //Return the result URL
                if (searchResults.Count < sequenceNo)
                {
                    throw new Exception("We have search result upto : " + searchResults.Count );
                }
                else
                {
                    return searchResults[sequenceNo - 1].GetAttribute("href");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                driver.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Google search url</param>
        public void LaunchBrowser(string url)
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchKeyword">Keyword to be searched</param>
        public void SetSearchKeyword(string SearchKeyword)
        {
            this.keyword = SearchKeyword;
            IWebElement element = driver.FindElement(By.Id("lst-ib"));
            element.SendKeys(keyword);

            // Get the search results panel that contains the link for each result.
            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(2000);
        }
    }
}
