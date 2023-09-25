using NUnit.Framework;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contact
                .SelectContact(2)
                .RemoveContact()
                .Exit(); 
        }
    }
}
