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
            string chooseOptionToAddContacts = string.Empty;
            List<Contacts> book = new List<Contacts>();
            do
            {
                Contacts C1 = new Contacts();
                C1.AddContacts();
                book.Add(C1);
                Console.WriteLine("Enter the choice to add more persons Contacts in current Address Book: \n \"Yes\" or \"No\"");
                chooseOptionToAddContacts = Console.ReadLine().ToUpper();
            }while (chooseOptionToAddContacts.Contains("Y"));
        }
    }
}
