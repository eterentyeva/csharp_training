﻿using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact
                .SelectContact(6)
                .RemoveContact()
                .Exit();
        }
    }
}
