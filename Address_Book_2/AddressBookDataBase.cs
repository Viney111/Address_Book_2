using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Address_Book_2
{
    public class AddressBookDataBase
    {
        #region DB Connection String
        public static string connectionString = @"Server=LAPTOP-IUMGL5A5;Database=Address_Book_Service;User ID=LAPTOP-IUMGL5A5\Kashish Manchanda;Trusted_Connection=True";
        #endregion

        SqlConnection sqlConnection = new SqlConnection(connectionString);

        #region Get All the Contacts From Database to Console
        public List<Contacts> GetContactsListByDataAdapterFromDB(string query)
        {
            List<Contacts> retrievedContactsFromDB = new List<Contacts>();
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
                        Contacts contacts = new Contacts();
                        contacts.firstName = (string)dataRow["FirstName"];
                        contacts.lastName = (string)dataRow["LastName"];
                        contacts.address = (string)dataRow["AddressDetails"];
                        contacts.city = (string)dataRow["City"];
                        contacts.state = (string)dataRow["StateName"];
                        contacts.zipCode = (int)dataRow["Zip"];
                        contacts.phoneNo = (Int64)dataRow["PhoneNo"];
                        contacts.email = (string)dataRow["email"];
                        retrievedContactsFromDB.Add(contacts);
                    }
                }
                return retrievedContactsFromDB;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
        #endregion

        #region Update Contact Details for a person & retrieve data in Object Form from Database
        public void UpdateContactDetailsofAPerson(Contacts contacts)
        {
            try
            {
                SqlCommand command = new SqlCommand("spUpdateContacts",sqlConnection )
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FirstName", contacts.firstName);
                command.Parameters.AddWithValue("@LastName", contacts.lastName);
                command.Parameters.AddWithValue("@City", contacts.city);
                command.Parameters.AddWithValue("@State",contacts.state);
                command.Parameters.AddWithValue("@Zip", contacts.zipCode);
                sqlConnection.Open();
                var result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Records updated successfully");
                }
                else
                {
                    Console.WriteLine("Record not updated successfully");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        public Contacts RetrieveDataFromDBInObjectForm(string connectionstring,Contacts passingContact)
        {
            SqlConnection connection;
            SqlDataReader sqlDataReader = default;
            try
            {
                Contacts contacts = new Contacts();
                using (connection = new SqlConnection(connectionstring))
                {
                    string query = @"SELECT * FROM PersonContactsTable";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    connection.Open();
                    sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            if (sqlDataReader.GetString(1) == passingContact.firstName && sqlDataReader.GetString(2) == passingContact.lastName)
                            {
                                contacts.firstName = sqlDataReader.GetString(1);
                                contacts.lastName = sqlDataReader.GetString(2);
                                contacts.address = sqlDataReader.GetString(3);
                                contacts.city = sqlDataReader.GetString(4);
                                contacts.state = sqlDataReader.GetString(5);
                                contacts.zipCode = sqlDataReader.GetInt32(6);
                                contacts.phoneNo = sqlDataReader.GetInt64(7);
                                contacts.email = sqlDataReader.GetString(8);
                                break;
                            }
                        }
                    }
                    sqlDataReader.Close();
                    return contacts;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
