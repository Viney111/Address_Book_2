using Microsoft.VisualStudio.TestTools.UnitTesting;
using Address_Book_2;
using System.Collections.Generic;

namespace AddressBookTest
{
    [TestClass]
    public class AddressBookUnitTets
    {
        public static string masterQuery = @"SELECT * FROM PersonContactsTable";
        AddressBookDataBase addressBookDataBase = new AddressBookDataBase();
        [TestMethod]
        public void GivenDBConnectionString_InAddressBookDataBase_ReturnListOfContactsinDB()
        {
            string[] expectedNamesinDB = { "VINEY","VISHAL","YASH","RAHUL","BUNNY" };
            string[] namesRetrived = { "", "", "", "", "" };
            List<Contacts> checkingContacts = addressBookDataBase.GetContactsListByDataAdapterFromDB(masterQuery);
            int i = 0;
            foreach(Contacts contact in checkingContacts)
            {
                namesRetrived[i] = contact.firstName;
                Assert.AreEqual(namesRetrived[i],expectedNamesinDB[i]);
                i++;
            }
        }

        [TestMethod]
        public void GivenContactsUpdatedObject_InUpdateContactsMethod_ReturnObjectOfUpdatedContact()
        {
            Contacts contacts = new Contacts { firstName = "VINEY", lastName = "KHANEJA", city = "Ludhiana", state = "Punjab", zipCode = 110008 };
            addressBookDataBase.UpdateContactDetailsofAPerson(contacts);
            List<Contacts> updatedListOfContacts = addressBookDataBase.GetContactsListByDataAdapterFromDB(masterQuery);
            foreach(Contacts contact in updatedListOfContacts)
            {
                if (contact.firstName == contacts.firstName && contact.lastName == contacts.lastName)
                {
                    Assert.AreEqual(contacts.city, contact.city);
                }
            }
        }
    }
}