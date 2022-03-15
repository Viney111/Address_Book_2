using System;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using System.Threading.Tasks;

namespace Address_Book_2
{
    internal class FileIOOperations
    {
        #region FilePath to and from which File to be Write & Read
        public static string path = @"C:\Users\Kashish Manchanda\source\repos\Address_Book_2\Utility\AddressBook.txt";
        public static string csvPath = @"C:\Users\Kashish Manchanda\source\repos\Address_Book_2\Utility\AddressBook1.csv";
        #endregion

        #region Writing Person Details in AddressBook.txt File
        public static void WritingAllPersonContactsinFile(IDictionary<string,Book> addressBook)
        {
            File.WriteAllText(path, string.Empty);
            foreach(KeyValuePair<string,Book> book in addressBook)
            {
                File.AppendAllText(path, $"Address Book Name : {book.Key}\n");
                foreach(Contacts contacts in book.Value.listOfContacts)
                {
                    File.AppendAllText(path, contacts.ToString());
                }
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

        #region Writing to AddressBook1.csv File
        public static void WritigAllPersonContactsinCSVFile(IDictionary<string, Book> addressBook)
        {
            File.WriteAllText(csvPath, string.Empty);
            var stream = File.Open(csvPath, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);
            CsvWriter csvWriter = new CsvWriter(sw, CultureInfo.InvariantCulture);
            foreach (var kvp in addressBook)
            {
                foreach(var contact in kvp.Value.listOfContacts)
                {
                    List<Contacts> listToCSV = new List<Contacts>();
                    listToCSV.Add(contact);
                    csvWriter.WriteRecords(listToCSV);
                }
            }
            csvWriter.Flush();
            sw.Close();
        }
        #endregion

        #region Reading from CSV File
        public static void ReadingAllPersonContactsfromCSVFile()
        {
            using (StreamReader streamreader = new StreamReader(csvPath))
            using (CsvReader csvReader = new CsvReader(streamreader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<Contacts>().ToList();
                foreach(Contacts contact in records)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        #endregion
    }
}
