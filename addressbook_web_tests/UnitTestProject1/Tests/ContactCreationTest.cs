using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData> ();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(
                    new ContactData(GenerateRandomString(30), GenerateRandomString(30)
                    ));
            }
            return contacts;
        }


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            app.Contact.Create(contact);
            app.Auth.Logout();
        }
    }
}
