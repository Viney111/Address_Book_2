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
            string masterQuery = @"SELECT * FROM PersonContactsTable";
            Console.WriteLine("Welcome to Address Book Program");
            AddressBook addressBook = new AddressBook();
            AddressBookDataBase dataBase = new AddressBookDataBase();
            Console.WriteLine("Enter options for executing below options \n Enter 1 for Adding Contacts in AddressBook \n Enter 2 for Sorting Person Contacts in List \n Enter 3 for Displaying Contacts in AddressBook Dictionary \n Enter 4 for Searching Person by City Name \n Enter 5 for Searching person by State Name \n Enter 6 For Reading person Contacts from file \n Enter 7 for reading person Contacts from CSV File \n Enter 8 for reading Person Contacts from Json File \n Enter 9 for retrieving Contacts from Database");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    addressBook.AddContactsDetailinAddressBook();
                    break;
                case 2:
                    addressBook.SortContactPerson();
                    break;
                case 3:
                    addressBook.DisplayContactsInAddressBookDictionary();
                    break;
                case 4:
                    addressBook.SeachingPersonByCityNameAndCountingAlso();
                    break;
                case 5:
                    addressBook.SeachingPersonByStateNameAndCountingAlso();
                    break;
                case 6:
                    FileIOOperations.ReadingAllPersonContactsinFile();
                    break;
                case 7:
                    FileIOOperations.ReadingAllPersonContactsfromCSVFile();
                    break;
                case 8:
                    FileIOOperations.ReadingAllPersonContactsFromJsonFile();
                    break;
                case 9:
                    List<Contacts> retrivedList = dataBase.GetContactsListByDataAdapterFromDB(masterQuery);
                    foreach(Contacts contact in retrivedList)
                    {
                        Console.WriteLine(contact.ToString());
                    }
                    break;
            }
        }
    }
}
