using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    { 
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupPage();
            app.Group
                .SelectGroup(1)
                .RemoveGroup()
                .ReturntoGroupPage()
                .Exit();
        }
    }
}