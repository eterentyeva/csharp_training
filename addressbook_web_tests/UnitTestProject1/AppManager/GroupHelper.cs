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
        private List<GroupData> groupCashe = null;
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
            groupCashe = null;
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
            groupCashe = null;
            return this;
        }
        public GroupHelper Exit()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//span[" + (index+1) + "]/input")).Click();
            groupCashe = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            groupCashe = null;
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null)
            {
                manager.Navigator.GoToGroupPage();

                groupCashe = new List<GroupData>();
                ICollection<IWebElement> elems = driver.FindElements(By.CssSelector("span.group"));

                foreach (IWebElement elem in elems)
                {
                    groupCashe.Add(new GroupData(null)
                    {
                        Id = elem.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCashe.Count - parts.Length;
                for (int i = 0; i < groupCashe.Count; i++)
                {
                    if (i < shift)
                        groupCashe[i].Name = "";
                    else
                        groupCashe[i].Name = parts[i - shift].Trim();
                    
                }
            }

            return new List<GroupData>(groupCashe);
        }

        public int GetGroupCount()
        {
            manager.Navigator.GoToGroupPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
