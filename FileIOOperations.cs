using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CsvHelper;
using System.Threading.Tasks;

namespace Address_Book_2
{
    internal class FileIOOperations
    {
        #region FilePath to and from which File to be Write & Read
        public static string path = @"C:\Users\Kashish Manchanda\source\repos\Address_Book_2\Utility\AddressBook.txt";
        #endregion

        #region Writing Person Details in AddressBook.txt File
        public static void WritingAllPersonContactsinFile(IDictionary<string,Book> addressBook)
        {
            File.WriteAllText(path, string.Empty);
            foreach(KeyValuePair<string,Book> person in addressBook)
            {
                File.AppendAllText(path, $"Address Book Name : {person.Key} {Environment.NewLine}");
                foreach(Contacts contacts in person.Value.listOfContacts)
                {
                    File.AppendAllText(path, contacts.ToString() + Environment.NewLine);
                }
                File.AppendAllText(path,Environment.NewLine);
            }
            Console.WriteLine("Content has written to AdrressBook.txt file");
        }
        #endregion

        #region Reading File from AddressBook.txt file
        public static void ReadingAllPersonContactsinFile()
        {
            string lines = File.ReadAllText(path);
            Console.WriteLine("Reading files from AdrressBook.txt file");
            Console.WriteLine(lines);
        }
        #endregion
    }
}
