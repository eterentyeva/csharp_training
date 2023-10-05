﻿using System;
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

            return this;

        }
        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(v);
            InitGroupModification();
            FillingGroupPage(newData);
            SubmitGroupModification();
            ReturntoGroupPage();
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
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public bool IsGroupExist()
        {
            return IsElementPresent(By.ClassName("group"));
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
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
