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
            var accountData = new AccountData { Name = "administrator", Password = "root2" };
            app.Login.Login(accountData);
            app.ManagementMenu.GoToManagePage();
            app.Project.GoToProjectPage();

            app.Project.Remove();

            app.Login.LogOut();
        }

    }
}
