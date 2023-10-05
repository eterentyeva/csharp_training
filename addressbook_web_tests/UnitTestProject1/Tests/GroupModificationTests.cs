using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        private GroupData newData;

        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupPage();
            if (!app.Group.IsGroupExist())
                app.Group.Create(new GroupData("new"));
            GroupData newData = new GroupData("l");
            newData.Header = null;
            newData.Footer = null;

            app.Group.Modify(1, newData);
            app.Auth.Logout();
        }
    }
}
