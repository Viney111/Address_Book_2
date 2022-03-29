using Microsoft.VisualStudio.TestTools.UnitTesting;
using Address_Book_2;

namespace AddressBookTest
{
    [TestClass]
    public class AddressBookUnitTets
    {
        Program program = new Program();
        [TestMethod]
        public void TestMethod1()
        {
            int expected = 9;
            program.Addition(5, 4);
            Assert.AreEqual(expected, 9);
        }
    }
}