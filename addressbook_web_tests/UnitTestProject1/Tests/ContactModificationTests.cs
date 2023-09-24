using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: TestBase
    {
        private ContactData newData;

        [Test]
        public void ContactModificationTest()
        {
            newData = new ContactData("an", "ch");
            app.Contact.Modify(newData);
        }
    }
}
