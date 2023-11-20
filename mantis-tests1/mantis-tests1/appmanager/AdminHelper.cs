using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Chrome;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        public string baseURL { get; }

        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager)
        {
            this.baseURL = baseUrl;
        }
        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> account = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php";
            IList<IWebElement> rows =  driver.FindElements(By.CssSelector("table tr.row21, table tr.row-2"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                account.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });

            }
            return account;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php?user_id=2" + account.Id;
            driver.FindElement(By.CssSelector("input[value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click();

        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = baseURL + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys(adminLogin.Name);
            driver.FindElement(By.Name("password")).SendKeys(adminLogin.Password);
            driver.FindElement(By.CssSelector("input.button")).Click();
            return driver;
        }
    }
}
