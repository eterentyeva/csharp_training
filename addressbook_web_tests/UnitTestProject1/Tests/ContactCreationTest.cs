using NUnit.Framework;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            Console.WriteLine(app.Contact);
            ContactData contact = new ContactData("liza", "ter");
            app.Contact.Create(contact);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            ContactData contact = new ContactData("", "");
            app.Contact.Create(contact);
        }
    }
}
