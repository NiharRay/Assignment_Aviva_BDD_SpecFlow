using System;
using TechTalk.SpecFlow;
using Assignment_Aviva_BDD_SpecFlow.Helper;
using Assignment_Aviva_BDD_SpecFlow.PageFactory;
using Assignment_Aviva_BDD_SpecFlow.Actions;

namespace Assignment_Aviva_BDD_SpecFlow.StepDefination
{
    [Binding]
    public class GoogleSearchResultSteps
    {
        private GoogleSearchEnginePage googleSearchEnginePage = new GoogleSearchEnginePage();
        Validation validate = new Validation();
        bool isDataNotProper = false;

        [Given(@"I launch '(.*)'")]
        public void GivenILaunch(string url)
        {
            DriverHelper.driver.Navigate().GoToUrl(url);
            Console.WriteLine("");
        }

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

        [Then(@"I should get (.*)th result url")]
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
                    Console.WriteLine("The url of fifth result is : " + googleSearchEnginePage.SearchResult[index - 1].GetAttribute("href"));
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
    }
}
