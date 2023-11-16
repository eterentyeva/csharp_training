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
            var projectData = new ProjectData { Name = "Test Project", Description = "fdsgfhg" };
            var accountData = new AccountData { Name = "administrator", Password = "root2" };
            app.Login.Login(accountData);
            app.ManagementMenu.GoToManagePage();
            app.Project.GoToProjectPage();

            app.Project.Create(projectData);

            app.Login.LogOut();
        }
    }
}
