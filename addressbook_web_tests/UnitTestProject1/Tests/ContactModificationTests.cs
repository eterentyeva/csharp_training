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
            if (!app.Contact.IsContactExist())
                app.Contact.Create(new ContactData("new", "new"));
            newData = new ContactData("an", "ch");
            app.Navigator.OpenHomePage();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldCData = oldContacts[0];
            app.Contact.Modify(oldCData, newData);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldCData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }
            app.Auth.Logout();
        }
    }
}
