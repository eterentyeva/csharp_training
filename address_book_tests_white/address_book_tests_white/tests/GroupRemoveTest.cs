using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_tests_white
{
    [TestFixture]
    public class GroupRemoveTest : TestBase
    {
        [Test]
        public void TestRemoveGroup()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove();
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count-1, newGroups.Count);
        }
    }
}
