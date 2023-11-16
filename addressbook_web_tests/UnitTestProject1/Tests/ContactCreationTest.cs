using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("FirstName", "LastName");
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.Logout();
        }
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contact);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.Logout();
        }
    }
}
