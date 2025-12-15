using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PetClinicApp.Classes
{
    public class Appointment
    {
        // Connection string taken from App.config for secure and flexible access
        private string connString = ConfigurationManager.ConnectionStrings["PetClinicDB2"].ConnectionString;

        // Properties that represent Appointment table fields
        public int AppointmentID { get; set; }
        public int PetID { get; set; }
        public int ServiceID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }

        public void AddAppointment()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "INSERT INTO Appointments (PetID, ServiceID, AppointmentDate, Notes) " +
                               "VALUES (@PetID, @ServiceID, @AppointmentDate, @Notes)";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters for inserting an appointment record into the database
                cmd.Parameters.AddWithValue("@PetID", PetID);
                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);
                cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                cmd.Parameters.AddWithValue("@Notes", Notes);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAppointment()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "UPDATE Appointments " +
                               "SET PetID=@PetID, ServiceID=@ServiceID, AppointmentDate=@AppointmentDate, Notes=@Notes " +
                               "WHERE AppointmentID=@AppointmentID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PetID", PetID);
                cmd.Parameters.AddWithValue("@ServiceID", ServiceID);
                cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAppointment()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "DELETE FROM Appointments WHERE AppointmentID=@AppointmentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllPets()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT PetID, PetName FROM Pets";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetAllServices()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT ServiceID, ServiceName FROM Services";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        /// <summary>
        /// Returns a detailed list of all appointments, including
        /// Pet name, Service name and notes.
        /// This is used to fill the DataGridView in the UI.
        /// </summary>
        public DataTable GetAllAppointments()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"SELECT a.AppointmentID,
                                        p.PetName,
                                        s.ServiceName,
                                        a.AppointmentDate,
                                        a.Notes
                                 FROM Appointments a
                                 INNER JOIN Pets p ON a.PetID = p.PetID
                                 INNER JOIN Services s ON a.ServiceID = s.ServiceID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}
