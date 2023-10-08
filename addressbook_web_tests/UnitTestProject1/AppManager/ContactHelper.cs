using OpenQA.Selenium;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactHelper: HelperBase
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
            Type(By.Name("firstname"), contactData.Firstname);
            Type(By.Name("lastname"), contactData.Lastname);
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
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr["+index+"]/td[1]/input")).Click();
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
            InitContactModification();
            FillingContactPage(newData);
            SubmitContactModification();
            ReturnToHomePage();

            contactCashe = null;

            return this;
        }

        private ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
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
    }
    
}
