using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void CreateNewIssue(AccountData account, ProjectData projectData, IssueData issueData)
        {
            mantis_tests1.Mantis.MantisConnectPortTypeClient client = new mantis_tests1.Mantis.MantisConnectPortTypeClient();
            mantis_tests1.Mantis.IssueData issue = new mantis_tests1.Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Catergory;
            issue.project = new mantis_tests1.Mantis.ObjectRef();
            issue.project.id = projectData.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjects(AccountData account)
        {
            mantis_tests1.Mantis.MantisConnectPortTypeClient client = new mantis_tests1.Mantis.MantisConnectPortTypeClient();
            mantis_tests1.Mantis.ProjectData[] mantisList = client.mc_projects_get_user_accessible(account.Name, account.Password);
            int projectCount = mantisList.Length;
            List<ProjectData> projectList = new List<ProjectData>();
            for (int i = 0; i <= projectCount - 1; i++)
            {
                projectList.Add(new ProjectData() { Name = mantisList[i].name, Description = mantisList[i].description });
            }
            return projectList;
        }

        public void CreateProjectForRemove(AccountData account, ProjectData project)
        {
            mantis_tests1.Mantis.MantisConnectPortTypeClient client = new mantis_tests1.Mantis.MantisConnectPortTypeClient();
            mantis_tests1.Mantis.ProjectData addedProject = new mantis_tests1.Mantis.ProjectData();
            addedProject.name = project.Name;
            addedProject.description = project.Description;
            client.mc_project_add(account.Name, account.Password, addedProject);
        }

    }
}
