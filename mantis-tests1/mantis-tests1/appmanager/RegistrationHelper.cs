using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper: HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) :base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
            

        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;


        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;   
            driver.FindElement(By.Name("password")).SendKeys(account.Name);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Name);
        }

        private void OpenRegistrationForm()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.26.0/signup_page.php";

            //driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        private void SubmitRegistration()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.26.0/signup_page.php";
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);

        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.26.0/account_page.php";

        }
    }
}
