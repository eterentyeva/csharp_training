using OpenQA.Selenium;

namespace mantis_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;
        protected AccountData adminLogin = new AccountData("administrator", "root");

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;

            }
            catch { return false; };

        }
    }

}
