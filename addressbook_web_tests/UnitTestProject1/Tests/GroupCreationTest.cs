using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("g");
            group.Header = "g";
            group.Footer = "g";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.Logout();

        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            app.Auth.Logout();
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            app.Auth.Logout();
        }
    }
}
