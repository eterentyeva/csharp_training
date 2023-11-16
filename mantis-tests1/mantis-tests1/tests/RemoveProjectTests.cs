using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class RemoveProjectTests: TestBase
    {
        [Test]
        public void RemoveProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            app.Login.Login(account);
            app.ManagementMenu.MenuProjects();
            app.Project.ProjectExistanceCheck(account);
            List<ProjectData> oldProjects = app.API.GetProjects(account);
            app.Project.DeleteProject(account, 0);
            List<ProjectData> newProjects = app.API.GetProjects(account);
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
