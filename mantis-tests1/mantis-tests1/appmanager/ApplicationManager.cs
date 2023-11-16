using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace mantis_tests
{
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FTPHelper FTPHelper { get; private set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public LoginHelper Login { get; }

        public ProjectManagementHelper Project { get; }
        public ManagementMenuHelper ManagementMenu { get; set; }

        public IWebDriver Driver 
        { 
            get {  return driver; }
            set {  driver = value; }     
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.26.0/account_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            FTPHelper = new FTPHelper(this);
            James= new JamesHelper (this);
            Mail = new MailHelper(this);
        }

        ~ApplicationManager()
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
    }
}
