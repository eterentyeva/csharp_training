using mantis_tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class CreateProjectTests: TestBase
    {
        [Test]
        public void CreateProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Name = app.Project.GenerateRandomString(),
                Description = app.Project.GenerateRandomString()
            };
            app.Login.Login(account);
            app.ManagementMenu.MenuProjects();
            List<ProjectData> oldProjects = app.API.GetProjects(account);

            app.Project.CreateProject(project);
            List<ProjectData> newProjects = app.API.GetProjects(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
