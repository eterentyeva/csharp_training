using mantis_tests;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void GoToManagePage()
        {
            driver.FindElement(By.XPath("//*[@id=\"sidebar\"]/ul/li[7]/a/span")).Click();
        }
    }
}
