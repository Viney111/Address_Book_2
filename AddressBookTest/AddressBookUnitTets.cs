using Microsoft.VisualStudio.TestTools.UnitTesting;
using Address_Book_2;

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
            addressBookDataBase.GetContactDetailsByDataAdapter(masterQuery);
            Assert.IsTrue(true);
        }
    }
}