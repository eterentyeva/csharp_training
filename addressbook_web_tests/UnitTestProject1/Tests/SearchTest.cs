using NUnit.Framework;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTest: AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            Console.WriteLine(app.Contact.GetNumberOfSearchResults());
        }
        
    }
}
