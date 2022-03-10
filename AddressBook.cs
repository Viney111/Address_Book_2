using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_2
{
    internal class AddressBook
    {
        #region Dictionary for Multiple Address Book
        IDictionary<string, Book> multipleAddressBook = new Dictionary<string, Book>();
        #endregion

        #region Add Multiple AddressBook in Dictionary
        public void AddAddressBook(Book book, string addressBookName)
        {
            multipleAddressBook.Add(addressBookName, book);
        }
        #endregion

        #region Main Function for Editing,Deleting,Adding Contacts in AddressBook
        public void AddContactsDetailinAddressBook()
        {
            //VARIABLES for Adding,Editing,Deleting Contacts & Address Book
            string chooseOptionToAddContacts = string.Empty;
            string chooseOptionToEditExistingContacts = string.Empty;
            string chooseOptionToDeleteExistingContacts = string.Empty;
            string chooseOptionToAddAddressBook = string.Empty;
            do
            {
                Console.WriteLine("Enter the name of AddressBook: ");
                string nameOfAddressBook = Console.ReadLine();
                Book bookContacts = new Book();
                do
                {
                    Contacts contacts = Contacts.AddContacts();
                    bookContacts.AddContactDetailsInList(contacts);                  
                    Console.WriteLine("Enter the choice to add more persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                    chooseOptionToAddContacts = Console.ReadLine().ToUpper();
                } while (chooseOptionToAddContacts.Contains("Y"));
                //Option for Editing Contacts
                Console.WriteLine("Enter the choice to edit persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                chooseOptionToEditExistingContacts = Console.ReadLine().ToUpper();
                if (chooseOptionToEditExistingContacts.Contains("Y"))
                {
                    bookContacts.EditContacts();
                }
                //Option for Deletig Contacts
                Console.WriteLine("Enter the choice to delete persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                chooseOptionToDeleteExistingContacts = Console.ReadLine().ToUpper();
                if (chooseOptionToDeleteExistingContacts.Contains("Y"))
                {
                    bookContacts.DeleteContacts();
                }
                AddAddressBook(bookContacts,nameOfAddressBook);
                Console.WriteLine("Enter the choice to add more Address Books: \n \"Yes\" or \"No\"");
                chooseOptionToAddAddressBook = Console.ReadLine().ToUpper();
            } while (chooseOptionToAddAddressBook.Contains("Y"));
        }
        #endregion

        #region Displaying all Contacts present in Multiple AddressBook
        public void DisplayContactsInAddressBookDictionary()
        {
            foreach(var kvp in multipleAddressBook)
            {
                Console.WriteLine($"The name of AddressBook is {kvp.Key} \nDetails in Address Book are:");
                kvp.Value.DisplayContactsDetails();
            }
        }
        #endregion

        #region For Viewing Person in a city or State across Multiple AddressBook
        public void SeachingPersonByCityName()
        {
            Console.WriteLine("Enter the City name: ");
            string cityName = Console.ReadLine();
            foreach (var kvp in multipleAddressBook)
            {
                foreach (var v in kvp.Value.listOfContacts)
                {
                    if (v.city == cityName)
                    {
                        Console.WriteLine($"{v.firstName} {v.lastName} lives in this {cityName}.");
                    }
                }
            }
        }
        #endregion

        #region For Searching Person in a particular State across Multiple AddressBook
        public void SeachingPersonByStateName()
        {
            Console.WriteLine("Enter the State name: ");
            string stateName = Console.ReadLine();
            foreach (var kvp in multipleAddressBook)
            {
                foreach (var v in kvp.Value.listOfContacts)
                {
                    if (v.city == stateName)
                    {
                        Console.WriteLine($"{v.firstName} {v.lastName} lives in this {stateName}.");
                    }
                }
            }
        }
        #endregion
    }
}
