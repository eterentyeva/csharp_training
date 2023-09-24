using OpenQA.Selenium;
using System.Text.RegularExpressions;
using NUnit.Framework;
namespace WebAddressbookTests
{
    public class ContactHelper: HelperBase
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
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.Lastname);
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
            driver.FindElement(By.Id(index.ToString())).Click();
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
            InitContactModification();
            FillingContactPage(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        private ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
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

    }
}
