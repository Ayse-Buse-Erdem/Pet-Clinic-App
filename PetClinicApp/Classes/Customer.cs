using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PetClinicApp.Classes
{
    public class Customer
    {
        // Connection string retrieved from App.config (PetClinicDB2)
        private string connString = ConfigurationManager.ConnectionStrings["PetClinicDB2"].ConnectionString;

        // Customer properties mapped directly to the database columns
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Adds a new customer record to the database
        public void AddCustomer()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "INSERT INTO Customers (FullName, Phone, Email) VALUES (@FullName, @Phone, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Passing parameter values from the class properties
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Email", Email);

                cmd.ExecuteNonQuery(); // Executes INSERT command
            }
        }

        // Updates an existing customer record in the database
        public void UpdateCustomer()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "UPDATE Customers SET FullName=@FullName, Phone=@Phone, Email=@Email WHERE CustomerID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Passing updated values
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@ID", CustomerID);

                cmd.ExecuteNonQuery(); // Executes UPDATE command
            }
        }

        // Deletes a customer record from the database using ID
        public void DeleteCustomer()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "DELETE FROM Customers WHERE CustomerID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", CustomerID);

                cmd.ExecuteNonQuery(); // Executes DELETE command
            }
        }

        // Retrieves all customers from the database as a DataTable
        public DataTable GetAllCustomers()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM Customers";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt); // Fills datatable with query result

                return dt;
            }
        }
    }
}
