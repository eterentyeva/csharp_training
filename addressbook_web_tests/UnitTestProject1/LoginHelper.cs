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
    public class LoginHelper
    {
        private IWebDriver driver;

        public LoginHelper(IWebDriver driver) 
        {
            this.driver = driver;
        }
        public void Login(AccountData account)
    {
        driver.FindElement(By.Name("user")).Click();
        driver.FindElement(By.Name("user")).Clear();
        driver.FindElement(By.Name("user")).SendKeys(account.Username);
        driver.FindElement(By.Name("pass")).Click();
        driver.FindElement(By.Name("pass")).Clear();
        driver.FindElement(By.Name("pass")).SendKeys(account.Password);
        driver.FindElement(By.XPath("//input[@value='Login']")).Click();
    }
}
}
