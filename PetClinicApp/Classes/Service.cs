using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PetClinicApp.Classes
{
    public class Service
    {
        // Connection string retrieved from App.config (database: PetClinicDB2)
        private string connString = ConfigurationManager.ConnectionStrings["PetClinicDB2"].ConnectionString;

        // Properties representing columns in the Services database table
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }

        // Adds a new service record to the database
        // Called from ServiceForm when user clicks "Add"
        public void AddService()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "INSERT INTO Services (ServiceName, Price) VALUES (@ServiceName, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Passing values to SQL command parameters
                cmd.Parameters.AddWithValue("@ServiceName", ServiceName);
                cmd.Parameters.AddWithValue("@Price", Price);

                cmd.ExecuteNonQuery();  // Executes INSERT command
            }
        }

        // Updates an existing service record based on ServiceID
        // Executed when user edits a service in the DataGridView
        public void UpdateService()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "UPDATE Services SET ServiceName=@ServiceName, Price=@Price WHERE ServiceID=@ServiceID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ServiceName", ServiceName);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);

                cmd.ExecuteNonQuery();  // Executes UPDATE command
            }
        }

        // Deletes a service record from the database
        // Called when user selects a service and presses "Delete"
        public void DeleteService()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "DELETE FROM Services WHERE ServiceID=@ServiceID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);

                cmd.ExecuteNonQuery();  // Executes DELETE command
            }
        }

        // Retrieves all service records from the Services table
        // Returned DataTable is used to populate DataGridView
        public DataTable GetAllServices()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM Services";

                // SqlDataAdapter allows reading database data into DataTable
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);  // Loads all records into DataTable

                return dt;
            }
        }
    }
}
