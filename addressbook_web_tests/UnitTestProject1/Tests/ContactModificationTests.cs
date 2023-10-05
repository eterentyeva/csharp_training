using NUnit.Framework;

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
            app.Contact.Modify(newData);
            app.Auth.Logout();
        }
    }
}
