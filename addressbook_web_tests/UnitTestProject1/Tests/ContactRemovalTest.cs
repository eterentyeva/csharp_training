using NUnit.Framework;
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
            app.Contact
                .SelectContact(2)
                .RemoveContact();
            app.Auth.Logout();
        }
    }
}
