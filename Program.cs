using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_Book_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook addressBook = new AddressBook();
            addressBook.AddContactsDetailinAddressBook();
            FileIOOperations.ReadingAllPersonContactsinFile();
            //addressBook.DisplayContactsInAddressBookDictionary();
            //addressBook.SeachingPersonByCityNameAndCountingAlso();
            //addressBook.SeachingPersonByStateNameAndCountingAlso();
        }
    }
}
