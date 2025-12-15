using System;
using System.Data;
using System.Windows.Forms;
using PetClinicApp.Classes;

namespace PetClinicApp.Forms
{
    public partial class CustomerForm : Form
    {
        // Customer class instance to interact with the database
        Customer customer = new Customer();

        // Constructor: Initializes the form
        public CustomerForm()
        {
            InitializeComponent();
        }

        // Form Load event: Populate DataGridView with existing customers
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        // Load all customers from the database into the DataGridView
        private void LoadCustomers()
        {
            dgvCustomers.DataSource = customer.GetAllCustomers();
        }

        // Add a new customer to the database
        // Triggered when "Add" button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            customer.FullName = txtFullName.Text;
            customer.Phone = txtPhone.Text;
            customer.Email = txtEmail.Text;

            customer.AddCustomer(); // Save new customer
            LoadCustomers();        // Refresh DataGridView
            ClearFields();          // Clear input fields
        }

        // Update selected customer
        // Triggered when "Update" button is clicked
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                customer.CustomerID = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CustomerID"].Value);
                customer.FullName = txtFullName.Text;
                customer.Phone = txtPhone.Text;
                customer.Email = txtEmail.Text;

                customer.UpdateCustomer(); // Update in database
                LoadCustomers();           // Refresh DataGridView
                ClearFields();             // Clear input fields
            }
        }

        // Delete selected customer
        // Triggered when "Delete" button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                customer.CustomerID = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CustomerID"].Value);

                customer.DeleteCustomer(); // Remove from database
                LoadCustomers();           // Refresh DataGridView
                ClearFields();             // Clear input fields
            }
        }

        // Refresh the DataGridView with latest customer data
        // Triggered when "Refresh" button is clicked
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        // Populate input fields with data from selected DataGridView row
        // Triggered when a DataGridView cell is clicked
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                txtFullName.Text = dgvCustomers.CurrentRow.Cells["FullName"].Value.ToString();
                txtPhone.Text = dgvCustomers.CurrentRow.Cells["Phone"].Value.ToString();
                txtEmail.Text = dgvCustomers.CurrentRow.Cells["Email"].Value.ToString();
            }
        }

        // Clear all input TextBoxes
        private void ClearFields()
        {
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }
    }
}
