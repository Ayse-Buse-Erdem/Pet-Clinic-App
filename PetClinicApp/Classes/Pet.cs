using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace PetClinicApp.Classes
{
    public class Pet
    {
        // Connection string retrieved from App.config (database: PetClinicDB2)
        private string connString = ConfigurationManager.ConnectionStrings["PetClinicDB2"].ConnectionString;

        // Properties representing database columns in the Pets table
        public int PetID { get; set; }
        public int CustomerID { get; set; }
        public string PetName { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }

        // Adds a new pet record to the database
        // Returns true if successful, false if an error occurs
        public bool AddPet()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "INSERT INTO Pets (CustomerID, PetName, Species, Breed) VALUES (@CustomerID,@PetName,@Species,@Breed)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Assigning parameter values from properties
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@PetName", PetName);
                    cmd.Parameters.AddWithValue("@Species", Species);
                    cmd.Parameters.AddWithValue("@Breed", Breed);

                    cmd.ExecuteNonQuery(); // Executes INSERT command
                }
                return true;
            }
            catch (Exception ex)
            {
                // Shows error message
                MessageBox.Show("Error adding pet: " + ex.Message);
                return false;
            }
        }

        // Updates an existing pet record in the database
        // Returns true if successful, false if an error occurs
        public bool UpdatePet()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "UPDATE Pets SET CustomerID=@CustomerID, PetName=@PetName, Species=@Species, Breed=@Breed WHERE PetID=@PetID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Assigning parameter values
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@PetName", PetName);
                    cmd.Parameters.AddWithValue("@Species", Species);
                    cmd.Parameters.AddWithValue("@Breed", Breed);
                    cmd.Parameters.AddWithValue("@PetID", PetID);

                    cmd.ExecuteNonQuery(); // Executes UPDATE command
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating pet: " + ex.Message);
                return false;
            }
        }

        // Deletes a pet record from the database based on PetID
        // Returns true if successful, false if an error occurs
        public bool DeletePet()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "DELETE FROM Pets WHERE PetID=@PetID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@PetID", PetID);

                    cmd.ExecuteNonQuery(); // Executes DELETE command
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting pet: " + ex.Message);
                return false;
            }
        }

        // Retrieves all pet records from the Pets table
        // Returns a DataTable used by DataGridView
        public DataTable GetAllPets()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT PetID, CustomerID, PetName, Species, Breed FROM Pets";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    da.Fill(dt); // Loads data into DataTable
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving pets: " + ex.Message);
            }

            return dt;
        }

        // Retrieves all customers (used for ComboBox in PetForm)
        // Returns CustomerID + FullName
        public DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT CustomerID, FullName FROM Customers";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    da.Fill(dt); // Loads customer data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving customers: " + ex.Message);
            }

            return dt;
        }
    }
}
