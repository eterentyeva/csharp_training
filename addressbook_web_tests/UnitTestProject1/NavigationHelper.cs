using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Text;


namespace WebAddressbookTests
{
    public class NavigationHelper
    {
        private IWebDriver driver;
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL)
        {
            this.driver = driver;
            this.baseURL = baseURL;
        }
        public void GoToGroupPage()
        {

            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
