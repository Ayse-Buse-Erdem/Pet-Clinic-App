using PetClinicApp.Classes;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;


namespace PetClinicApp.Forms
{
    public partial class LoginForm : Form
    {
        // User class instance to handle login verification
         User user = new User();

        // Constructor: Initializes the login form
        public LoginForm()
        {
            InitializeComponent();
        }

        // Login button click event
        // Validates input fields and attempts to log in
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();


            // Check if username or password fields are empty
            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Attempt login using User class
            if (user.Login(username, password))
            {
                MessageBox.Show("Login Successful!");

                // Hide login form and open main application form
                this.Hide();
                MainForm main = new MainForm();
                main.Show();
            }
            else
            {
                // Display error if login fails
                MessageBox.Show("Invalid Username or Password.");
            }
        }
        // Cancel button click event
        // Exits the application
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            string scriptPath = Path.Combine(Application.StartupPath, "DatabaseScripts", "script.sql");

            if (!File.Exists(scriptPath))
            {
                MessageBox.Show("Tablo script dosyası bulunamadı: " + scriptPath);
                return;
            }

            try
            {
                string script = File.ReadAllText(scriptPath);

                using (SqlConnection conn = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PetClinicDB2;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(script, conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Tablolar başarıyla oluşturuldu veya zaten var.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Genel Hata: " + ex.Message);
            }
        }



    }
}
