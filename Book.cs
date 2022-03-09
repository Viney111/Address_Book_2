using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_2
{
    internal class Book
    {
        public static List<Contacts> book = new List<Contacts>();
        public static void ContactsDetail()
        {
            string chooseOptionToAddContacts = string.Empty;
            string chooseOptionToEditExistingContacts = string.Empty;
            do
            {
                Contacts C1 = new Contacts();
                book.Add(C1.AddContacts());
                Console.WriteLine("Enter the choice to add more persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                chooseOptionToAddContacts = Console.ReadLine().ToUpper();
            } while (chooseOptionToAddContacts.Contains("Y"));
            Console.WriteLine("Enter the choice to edit persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
            chooseOptionToEditExistingContacts = Console.ReadLine().ToUpper();
            if (chooseOptionToEditExistingContacts.Contains("Y"))
            {
                EditContacts();
            }
        }
        public static void EditContacts()
        {
            Console.WriteLine("Enter the name of the person whose contact details you want to edit: ");
            string nameOfEditingContactPerson = Console.ReadLine().ToUpper();
            Contacts editedContact = null;
            foreach(Contacts contact in book)
            {
                if (contact.firstName.ToUpper() == nameOfEditingContactPerson)
                {
                    editedContact = contact;
                    Console.WriteLine("Enter the option to modify the property: ");
                    Console.WriteLine("Enter 1 to Change First name ");
                    Console.WriteLine("Enter 2 to Change Last name ");
                    Console.WriteLine("Enter 3 to Change Phone Number ");
                    Console.WriteLine("Enter 4 to Change Address ");
                    Console.WriteLine("Enter 5 to Change City ");
                    Console.WriteLine("Enter 6 to Change State ");
                    Console.WriteLine("Enter 7 to Change Pincode ");
                    Console.WriteLine("Enter 8 to Chnage Email ");
                    Console.WriteLine("Enter 9 to Exit ");
                    int Check = Convert.ToInt32(Console.ReadLine());
                    switch (Check)
                    {
                        case 1:
                            Console.WriteLine("Enter the New First Name: ");
                            editedContact.firstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter the New Last Name: ");
                            editedContact.lastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter the New Phone Number: ");
                            editedContact.phoneNo = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter the New Address: ");
                            editedContact.address = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter the New City: ");
                            editedContact.city = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter the New State: ");
                            editedContact.state = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter the New Zip Code: ");
                            editedContact.zipCode = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter the New email: ");
                            editedContact.email = (Console.ReadLine());
                            break;
                        case 9:
                            return;
                    }
                }
            }
        }
        public static void DisplayContactsDetails()
        {
            foreach(Contacts contact in book)
            {
                Console.WriteLine($"First Name: {contact.firstName} LastName: {contact.lastName}\nAddress is: {contact.address}\nCity Name is: {contact.city}\nState Name is: {contact.state}\nZipCode is: {contact.zipCode}\nPhone Number is: {contact.phoneNo}\nEmail is: {contact.email} ");
                Console.WriteLine("--------------------------------------------------");
            }
        }

    }
}
