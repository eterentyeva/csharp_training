using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void CreateProject(ProjectData project)
        {
            InitCteateProject();
            FillProjectForm(project);
            SubmitCreation();
        }

        public void DeleteProject(AccountData account, int id)
        {
            OpenProject(id);
            InitDeleteProject();
            SubmitRemoval();
        }
        public void InitCteateProject()
        {
            driver.FindElement(By.XPath("//input[@value='Create New Project']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }

        public void SubmitCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
        }

        public void ProjectExistanceCheck(AccountData account)
        {
            if (manager.API.GetProjects(account).Count() == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "AutoProjectName",
                    Description = "AutoDescription"
                };
                manager.API.CreateProjectForRemove(account, project);
                manager.Driver.Url = "http://localhost/mantisbt-2.4.1/manage_proj_page.php";
            };
        }

        public void OpenProject(int id)
        {
            driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("a"))[id].Click();
        }

        public void InitDeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

        public void SubmitRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }
    }
}
