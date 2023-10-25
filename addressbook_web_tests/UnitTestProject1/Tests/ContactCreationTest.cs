using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

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

        public static IEnumerable<ContactData> ContactDataFromXml()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contact.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJson()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contact.json"));
        }

        [Test, TestCaseSource("ContactDataFromJson")]
        public void ContactCreationTest(ContactData contact)
        {
            app.Contact.Create(contact);
            app.Auth.Logout();
        }
    }
}
