using System;
using TechTalk.SpecFlow;
using Assignment_Aviva_BDD_SpecFlow.Helper;

namespace Assignment_Aviva_BDD_SpecFlow.StepDefination
{
    [Binding]
    public class GoogleSearchResultSteps
    {
        private SeleniumHelper googleSearchEngineResult = new SeleniumHelper();

        [Given(@"I launch '(.*)'")]
        public void GivenILaunch(string url)
        {
            googleSearchEngineResult.LaunchBrowser(url);
        }

        [When(@"I provide '(.*)' keyword to search")]
        public void WhenIProvideKeywordToSearch(string keyword)
        {
            googleSearchEngineResult.SetSearchKeyword(keyword);
        }

        [Then(@"I should get (.*)th result url")]
        public void ThenIShouldGetThResultUrl(int index)
        {
            try
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("The url of fifth result is : " + googleSearchEngineResult.GetSearchResult(index));
                Console.WriteLine("--------------------------------------------------------------------------------");
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
