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

            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Group.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();

            oldGroups[0].Name = newData.Name;

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);

                }
            }


            app.Auth.Logout();
        }
    }
}
