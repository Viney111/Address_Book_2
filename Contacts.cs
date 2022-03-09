using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_2
{
    internal class Contacts
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public int phoneNo { get; set; }
        public string email { get; set; }

        public Contacts AddContacts()
        {
            Contacts contacts = new Contacts();
            Console.WriteLine("Enter First Name: ");
            contacts.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            contacts.lastName = Console.ReadLine();
            Console.WriteLine("Enter the address: ");
            contacts.address = Console.ReadLine();
            Console.WriteLine("Enter city Name: ");
            contacts.city = Console.ReadLine();
            Console.WriteLine("Enter state Name: ");
            contacts.state = Console.ReadLine();
            Console.WriteLine("Enter the zip Code: ");
            contacts.zipCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the phone Number: ");
            contacts.phoneNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the email Id: ");
            contacts.email = Console.ReadLine();
            return contacts;
        }

    }
}
