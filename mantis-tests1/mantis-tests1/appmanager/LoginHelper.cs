using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            OpenMainPage();
            FillUserNameInput(account);
            SubmitLogin();
            FillPasswordInput(account);
            SubmitLogin();
        }

        public void LogOut()
        {
            driver.FindElement(By.ClassName("user-info")).Click();
            driver.FindElement(By.ClassName("fa-sign-out")).Click();
        }

        private void FillPasswordInput(AccountData accountData)
        {
            driver.FindElement(By.Id("password")).SendKeys(accountData.Password);
        }

        private void SubmitLogin()
        {
            driver.FindElement(By.CssSelector("input.bigger-110")).Click();
        }

        private void FillUserNameInput(AccountData accountData)
        {
            driver.FindElement(By.Id("username")).SendKeys(accountData.Name);
        }

        private void OpenMainPage()
        {
            driver.Url = "http://localhost:8080/mantisbt-2.24.3/login_page.php";
        }
    }
}
