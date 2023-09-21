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
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.GoToGroupPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            groupHelper.ReturntoGroupPage();
            groupHelper.Exit();
        }
    }
}