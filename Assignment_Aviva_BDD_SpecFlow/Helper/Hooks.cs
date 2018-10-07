using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Assignment_Aviva_BDD_SpecFlow.Helper
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverHelper.SetBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverHelper.Close();
        }
    }
}
