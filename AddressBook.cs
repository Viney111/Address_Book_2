using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_2
{
    internal class AddressBook
    {
        IDictionary<string, Book> multipleAddressBook = new Dictionary<string, Book>();
        public void AddAddressBook(Book book, string addressBookName)
        {
            multipleAddressBook.Add(addressBookName, book);
        }
        public void AddContactsDetailinAddressBook()
        {
            string chooseOptionToAddContacts = string.Empty;
            string chooseOptionToEditExistingContacts = string.Empty;
            string chooseOptionToDeleteExistingContacts = string.Empty;
            string chooseOptionToAddAddressBook = string.Empty;
            do
            {
                Console.WriteLine("Enter the name of AddressBook: ");
                string nameOfAddressBook = Console.ReadLine();
                Book book = new Book();
                do
                {
                    Contacts contacts = Contacts.AddContacts();
                    book.AddContactDetailsInList(contacts);                  
                    Console.WriteLine("Enter the choice to add more persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                    chooseOptionToAddContacts = Console.ReadLine().ToUpper();
                } while (chooseOptionToAddContacts.Contains("Y"));
                Console.WriteLine("Enter the choice to edit persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                chooseOptionToEditExistingContacts = Console.ReadLine().ToUpper();
                if (chooseOptionToEditExistingContacts.Contains("Y"))
                {
                    book.EditContacts();
                }
                Console.WriteLine("Enter the choice to delete persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                chooseOptionToDeleteExistingContacts = Console.ReadLine().ToUpper();
                if (chooseOptionToDeleteExistingContacts.Contains("Y"))
                {
                    book.DeleteContacts();
                }
                AddAddressBook(book,nameOfAddressBook);
                Console.WriteLine("Enter the choice to add more Address Books: \n \"Yes\" or \"No\"");
                chooseOptionToAddAddressBook = Console.ReadLine().ToUpper();
            } while (chooseOptionToAddAddressBook.Contains("Y"));
        }
        public void DisplayContactsInAddressBookDictionary()
        {
            foreach(var kvp in multipleAddressBook)
            {
                Console.WriteLine($"The name of AddressBook is {kvp.Key} \nDetails in Address Book are:");
                kvp.Value.DisplayContactsDetails();
            }
        }
    }
}
