using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        protected IWebDriver driver;
        protected string baseURL;

        public IWebDriver Driver 
        { get
            {  return driver; }
            set {  driver = value; }     
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }
        public LoginHelper Auth
        { get { return loginHelper; } } 
        public NavigationHelper Navigator
        { get { return navigationHelper; } }
        public GroupHelper Group 
        { get {  return groupHelper; } }
        public ContactHelper Contact
        { get { return contactHelper; } }

       
    }
}
