using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTest: AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Group.GroupExistenceCheck();
            app.Contact.ContactExistanceCheck();
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            if (contact == null)
            {
                contact = new ContactData("new", "new");
                app.Contact.Create(contact);
            }
            app.Contact.AddContactToGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
