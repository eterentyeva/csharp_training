using mantis_tests;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        private string BaseURL;
        public ManagementMenuHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            BaseURL = baseURL;
        }
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void MenuProjects()
        {
            OpenManagePage();
            GoToProjectsPage();
        }

        public void OpenManagePage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.26.0/manage_overview_page.php";
        }

        public void GoToProjectsPage()
        {
            driver.FindElement(By.LinkText("Проекты")).Click();
        }
        public void GoToManagePage()
        {
            driver.FindElement(By.XPath("//*[@id=\"sidebar\"]/ul/li[7]/a/span")).Click();
        }
        public void GoToProjectManagementPage()
        {
            if (driver.Url == BaseURL + "/manage_proj_page.php"
                && IsElementPresent(By.XPath("//input[@name='manage_proj_create_page_token']")))
            {
                return;
            }
            driver.Navigate().GoToUrl(BaseURL + "/manage_proj_page.php");
        }
    }
}
