using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Internal;

namespace mantis_tests
{
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FTPHelper FTPHelper { get; set; }
        public JamesHelper James { get;  set; }
        public MailHelper Mail { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; private set; }
        public LoginHelper Login { get; set; }

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
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-2.26.0";
            Registration = new RegistrationHelper(this);
            FTPHelper = new FTPHelper(this);
            James= new JamesHelper (this);
            Mail = new MailHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);
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
