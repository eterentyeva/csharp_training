using OpenQA.Selenium;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCashe = null;
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
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[" + index + "]/td[1]/input")).Click();
            contactCashe = null;
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCashe = null;

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

            contactCashe = null;

            return this;
        }

        private ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (v + 1) + "]")).Click();
            contactCashe = null;
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
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> entries = driver.FindElements(By.Name("entry"));
                foreach (IWebElement entry in entries)
                {
                    string firstName = entry.FindElements(By.TagName("td"))[2].Text;
                    string lastName = entry.FindElements(By.TagName("td"))[1].Text;
                    contactCashe.Add(new ContactData(firstName, lastName));
                }
            }
            return new List<ContactData>(contactCashe);
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

        public string ReverseContactInformationGromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            string contactData = driver.FindElements(By.Name("entry"))[index].Text;
            return Regex.Replace(contactData, @"[ ]", "");
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
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email
            };
        }
        public string ReverseGetContactInformationFromEditForm(int index)
        {
            ContactData contactDatas = GetContactInformationFromEditForm(index);
            string result = contactDatas.LastName + contactDatas.FirstName + contactDatas.AllPhones;
            return Regex.Replace(result, @"[ ]", "");
        }

        public string ReverseGetContactInformationFromEditFormForDetails(int index)
        {
            ContactData contactDatas = GetContactInformationFromEditForm(index);
            string phone = "";
            string[] phones = new string[3] { "","",""};
            string email = "";
            if (contactDatas.AllPhones != "")
            {
                phone += "\r\n";
                if (contactDatas.HomePhone!="")
                    phone += "\r\nH: " + contactDatas.HomePhone;
                if (contactDatas.MobilePhone != "")
                    phone += "\r\nM: " + contactDatas.MobilePhone;
                if (contactDatas.WorkPhone != "")
                    phone += "\r\nW: " + contactDatas.WorkPhone;
            }
            if (contactDatas.Email != "")
            {
                email = "\r\n\r\n" + contactDatas.Email;
            }
            return (contactDatas.FirstName +" " + contactDatas.LastName + phone + email);

        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

       public string ReverseGetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            IWebElement contactData = driver.FindElement(By.Id("content"));
            return contactData.Text;
        }
    }

}
