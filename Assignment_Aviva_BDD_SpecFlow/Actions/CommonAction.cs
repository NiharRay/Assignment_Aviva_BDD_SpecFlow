using Assignment_Aviva_BDD_SpecFlow.Helper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Aviva_BDD_SpecFlow.Actions
{
    public class CommonAction
    {
        public void TakeScreenShot()
        {
            Screenshot screenShot = ((ITakesScreenshot)DriverHelper.driver).GetScreenshot();
            string screenshotFileName = "Assignment_Aviva_BDD_SpecFlow_" + DateTime.UtcNow.ToString("yyyy-MM-d_HHmmss_fff", CultureInfo.InvariantCulture);
            screenShot.SaveAsFile(".\\" + screenshotFileName + ".png");
        }
    }
}
