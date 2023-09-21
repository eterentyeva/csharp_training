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
    public class GroupHelper
    {
        private IWebDriver driver;

        public GroupHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ReturntoGroupPage()
        {

            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
        }
        public void FillingGroupPage(GroupData group)
        {
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Footer);
        }
        public void InitGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
        }
        public void RemoveGroup()
        {
            driver.FindElement(By.XPath("//input[5]")).Click();
        }
        public void Exit()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//span[" + index + "]/input")).Click();
        }
    }
}
