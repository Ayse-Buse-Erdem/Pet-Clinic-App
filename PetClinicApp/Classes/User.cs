using System;
using System.Data.SqlClient;
using System.Configuration;

namespace PetClinicApp.Classes
{
    public class User
    {
        // Properties represent the columns in the Users table in the database
        public int UserID { get; set; }      // Primary key in Users table
        public string Username { get; set; } // User's login name
        public string Password { get; set; } // User's password 
        public string Role { get; set; }     // User role (Admin)

        // Retrieves connection string from App.config (PetClinicDB2)
        private string connString = ConfigurationManager.ConnectionStrings["PetClinicDB2"].ConnectionString;

        // Login method checks if a username + password combination exists
        // Used by LoginForm when the user clicks the "Login" button
        public bool Login(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // SQL query verifies if a matching user exists
                    string query = "SELECT COUNT(*) FROM Users WHERE Username=@u AND Password=@p";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Assign values to SQL query parameters for login
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    // ExecuteScalar returns a single value (number of matching users)
                    int count = (int)cmd.ExecuteScalar();

                    // Returns true only if a matching user exists
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Wraps and rethrows the exception for debugging or logging
                throw new Exception("Login error: " + ex.Message);
            }
        }
    }
}
