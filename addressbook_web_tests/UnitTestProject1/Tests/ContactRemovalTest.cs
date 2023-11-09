using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.OpenHomePage();
            if (!app.Contact.IsContactExist())
                app.Contact.Create(new ContactData("new", "new"));
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contact
                .SelectContact(0)
                .RemoveContact();
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
            app.Auth.Logout();
        }
    }
}
