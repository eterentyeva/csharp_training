using OpenQA.Selenium;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactPage();
            FillingContactPage(contact);
            SubmittingContactCreation();
            return this;
        }

        public ContactHelper Return()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private void SubmittingContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillingContactPage(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("lastname"), contactData.LastName);
        }

        private void AddingNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public ContactHelper Exit()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[" + (index + 1) + "]/td[1]/input")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));

            return this;
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                alert.Accept();

                return alertText;
            }
            catch { return null; }
        }

        public ContactHelper Modify(ContactData newData)
        {
            InitContactModification(0);
            FillingContactPage(newData);
            SubmitContactModification();
            ReturnToHomePage();

            return this;
        }

        private ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (v + 1) + "]")).Click();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("entry"));
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();
            ICollection<IWebElement> entries = driver.FindElements(By.Name("entry"));
            foreach (IWebElement entry in entries)
            {
                string firstName = entry.FindElements(By.TagName("td"))[2].Text;
                string lastName = entry.FindElements(By.TagName("td"))[1].Text;
                contacts.Add(new ContactData(firstName, lastName));
            }
            
            return new List<ContactData>(contacts);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(v);
            RemoveContact();
            return this;
        }
        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }

}
