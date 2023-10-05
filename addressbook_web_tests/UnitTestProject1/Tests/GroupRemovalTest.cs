using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupPage();
            if (!app.Group.IsGroupExist())
                app.Group.Create(new GroupData("new"));
            app.Group
                .SelectGroup(1)
                .RemoveGroup()
                .ReturntoGroupPage();
            app.Auth.Logout();
        }
    }
}