using System;
using System.Collections.Generic;
using System.Web;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestReverseContactInformation()
        {
            string reverseDataFromTable = app.Contact.ReverseContactInformationGromTable(0);
            string reverseDataFromForm = app.Contact.ReverseGetContactInformationFromEditForm(0);
            Assert.AreEqual(reverseDataFromTable, reverseDataFromForm);
        }

        [Test]
        public void TestReverseContactInformationFromDetailsForm() 
        {
            string reverseDataFromDetails = app.Contact.ReverseGetContactInformationFromDetailsForm(0);
            string reverseDataFromForm = app.Contact.ReverseGetContactInformationFromEditFormForDetails(0);
            Console.WriteLine(reverseDataFromDetails);
            Console.WriteLine(reverseDataFromForm);
            Assert.AreEqual(reverseDataFromDetails, reverseDataFromForm);
        }
    }
}
