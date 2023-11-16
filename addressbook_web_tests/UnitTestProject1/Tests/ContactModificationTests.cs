using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        private ContactData newData;

        [Test]
        public void ContactModificationTest()
        {
            ContactData newCData = new ContactData("NewFirstName", "NewLastName");
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Modify(newCData);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newCData.FirstName;
            oldContacts[0].LastName = newCData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.Logout();
        }
    }
}
