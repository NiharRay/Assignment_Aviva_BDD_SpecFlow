using Assignment_Aviva_BDD_SpecFlow.PageFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Aviva_BDD_SpecFlow.Actions
{
    public class GoogleSearchEngineAction
    {
        public void TriggerSearch(GoogleSearchEnginePage googlePage, string Keyword)
        {
            googlePage.SearchTextBox.SendKeys(Keyword);
            googlePage.SearchButton.Click();
        }
    }
}
