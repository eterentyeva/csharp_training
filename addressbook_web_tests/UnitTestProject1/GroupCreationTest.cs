﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.GoToGroupPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("g");
            group.Header = "g";
            group.Footer = "g";
            groupHelper.FillingGroupPage(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturntoGroupPage();
            groupHelper.Exit();
        } 
    }
}
