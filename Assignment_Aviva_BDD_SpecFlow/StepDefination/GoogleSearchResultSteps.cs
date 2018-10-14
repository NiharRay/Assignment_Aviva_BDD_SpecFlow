using System;
using TechTalk.SpecFlow;
using Assignment_Aviva_BDD_SpecFlow.Helper;
using Assignment_Aviva_BDD_SpecFlow.PageFactory;
using Assignment_Aviva_BDD_SpecFlow.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Assignment_Aviva_BDD_SpecFlow.StepDefination
{
    [Binding]
    public class GoogleSearchResultSteps
    {
        private GoogleSearchEnginePage googleSearchEnginePage = new GoogleSearchEnginePage();
        Validation validate = new Validation();
        bool isDataNotProper = false;

        //[Given(@"I launch '(.*)'")]
        //public void GivenILaunch(string url)
        //{
        //    url = ConfigurationManager.AppSettings["googleSearchPage"];
        //    DriverHelper.driver.Navigate().GoToUrl(url);
        //    Console.WriteLine("");
        //}

        [When(@"I provide '(.*)' keyword to search")]
        public void WhenIProvideKeywordToSearch(string keyword)
        {
            try
            {
                string validationMessageSearchKeyword = validate.ValidateSearchKeyword(keyword.Trim());
                if (validationMessageSearchKeyword != "0")
                {
                    isDataNotProper = true;
                    throw new Exception(validationMessageSearchKeyword);
                }
                new GoogleSearchEngineAction().TriggerSearch(googleSearchEnginePage, keyword);
            }
            catch(Exception ex)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }

        [Then(@"I should get (.*)th result")]
        public void ThenIShouldGetThResultUrl(int index)
        {
            try
            {
                if (!isDataNotProper)
                {
                    string validationMessageSequenceNumber = validate.ValidateSequenceNo(index);
                    if (validationMessageSequenceNumber != "0")
                    {
                        throw new Exception(validationMessageSequenceNumber);
                    }
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("The url of fifth result is : " + googleSearchEnginePage.SearchResult[index - 1].Text);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    new CommonAction().TakeScreenShot();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }
        [Then(@"I should see (.*) links in the first search page")]
        public void ThenIShouldSeeLinksInTheFirstSearchPage(int LinkCount)
        {
            try
            {
                if (!isDataNotProper)
                {
                    int resultsCount = googleSearchEnginePage.SearchResult.Count;
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Number of search result returned: " + resultsCount);
                    Assert.IsTrue(LinkCount == resultsCount);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }
        [Then(@"I should not see (.*) links in the first search page")]
        public void ThenIShouldNotSeeLinksInTheFirstSearchPage(int LinkCount)
        {
            try
            {
                if (!isDataNotProper)
                {
                    int resultsCount = googleSearchEnginePage.SearchResult.Count;
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Number of search result returned: " + resultsCount);
                    Assert.AreNotEqual(LinkCount, resultsCount);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }
        [Given(@"I launch GoogleHomePage")]
        public void GivenILaunchGoogleHomePage()
        {
            string url = ConfigurationManager.AppSettings["googleSearchPage"];
            DriverHelper.driver.Navigate().GoToUrl(url);
        }

    }
}
