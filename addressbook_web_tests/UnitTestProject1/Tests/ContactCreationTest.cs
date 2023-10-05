using NUnit.Framework;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("liza", "ter");
            app.Contact.Create(contact);
            app.Auth.Logout();
        }
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            app.Contact.Create(contact);
            app.Auth.Logout();
        }
    }
}
