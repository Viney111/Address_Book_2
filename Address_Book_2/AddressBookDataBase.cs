using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Address_Book_2
{
    public class AddressBookDataBase
    {
        public static string connectionString = @"Server=LAPTOP-IUMGL5A5;Database=Address_Book_Service;User ID=LAPTOP-IUMGL5A5\Kashish Manchanda;Trusted_Connection=True";
        public void GetContactDetailsByDataAdapter(string query)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection connection;
                using(connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
                    adapter.Fill(ds);
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(dataRow["FirstName"] + "," + dataRow["LastName"] + "," + dataRow["AddressDetails"] + "," + dataRow["City"] + "," + dataRow["StateName"] + "," + dataRow["Zip"] + "," + dataRow["PhoneNo"] + "," + dataRow["Email"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
