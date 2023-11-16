using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroupTest()
        {
            app.Group.GroupExistenceCheck();
            app.Contact.ContactExistanceCheck();
            GroupData group = GroupData.GetAll()[0]; 
            app.Contact.ContactInGroupCheck(group);

            List<ContactData> oldContacts = group.GetContacts();
            ContactData contact = oldContacts[0];
            app.Contact.RemoveContactFromGroup(contact, group);
            List<ContactData> newContacts = group.GetContacts();
            oldContacts.Remove(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
