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
    public class GroupHelper : HelperBase
    {
       
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillingGroupPage(group);
            SubmitGroupCreation();
            ReturntoGroupPage();
            Exit();

            return this;

        }
        public GroupHelper ReturntoGroupPage()
        {

            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper FillingGroupPage(GroupData group)
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
            return this;
        }
        public GroupHelper InitGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//input[5]")).Click();
            return this;
        }
        public GroupHelper Exit()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//span[" + index + "]/input")).Click();
            return this;
        }
    }
}
