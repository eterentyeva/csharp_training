using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        private ApplicationManager app;

        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
            app = manager;
        }

        public void Create(ProjectData project)
        {
            InitCreateProject();
            FillProjectData(project);
            ConfirmProjectCreation();
            Proceed();
        }

        private void Proceed()
        {
            driver.FindElement(By.LinkText("Proceed")).Click();
        }

        private void ConfirmProjectCreation()
        {
            driver.FindElement(By.CssSelector(" div.widget-toolbox.padding-8.clearfix > input")).Click();
        }

        private void FillProjectData(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        private void InitCreateProject()
        {
            driver.FindElement(By.CssSelector("div.widget-toolbox.padding-8.clearfix > form > fieldset > button"))
                .Click();
        }

        public void GoToProjectPage()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }

        public void Remove()
        {
            SelectProjectToRemove();
            InitRemoveProject();
            ConfirmRemoveProject();
        }

        private void ConfirmRemoveProject()
        {
            driver.FindElement(By.ClassName("btn-round")).Click();
        }

        private void InitRemoveProject()
        {
            driver.FindElement(
                    By.CssSelector(
                        "#project-delete-form > fieldset > input.btn.btn-primary.btn-sm.btn-white.btn-round"))
                .Click();
        }

        private void SelectProjectToRemove()
        {
            var listProject = driver.FindElements(By.CssSelector(" td > a"));
            listProject[0].Click();
        }
    }
}
