using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Aviva_BDD_SpecFlow.ConfigDataManipulation
{
    public class TestData : ConfigurationElement
    {
        private TestData() { }

        [ConfigurationProperty("id")]
        public int id
        {
            get { return (int)this["id"]; }
            set { this["id"] = value; }
        }
        [ConfigurationProperty("UserName")]
        public string UserName
        {
            get { return (string)this["UserName"]; }
            set { this["UserName"] = value; }
        }
        [ConfigurationProperty("Password")]
        public string Password
        {
            get { return (string)this["Password"]; }
            set { this["Password"] = value; }
        }
    }

    public class TestDatas : ConfigurationSection
    {
        private TestDatas() { }

        [ConfigurationProperty("TestData")]
        public TestData SectorConfig
        {
            get { return (TestData)this["TestData"]; }
        }
    }

    //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    //TestDatas testDatas = (TestDatas)config.Sections["TestDatas"];
    //string UserName = testDatas.SectorConfig.UserName;
    //TestData tetData = testDatas.SectorConfig.;

}
