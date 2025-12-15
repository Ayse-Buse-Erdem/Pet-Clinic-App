using System;
using System.Windows.Forms;
using PetClinicApp.Classes;

namespace PetClinicApp.Forms
{
    public partial class ServiceForm : Form
    {
        // Instance of Service class to interact with database
        Service service = new Service();

        // Constructor: Initializes the form
        // Loads all services into the DataGridView
        public ServiceForm()
        {
            InitializeComponent();
            LoadData(); // Load services from DB
        }

        
        // Retrieves all services and binds them to the DataGridView
        private void LoadData()
        {
            dgvServices.DataSource = service.GetAllServices();
        }

     
        // Adds a new service to the database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            service.ServiceName = txtServiceName.Text.Trim();
            service.Price = Convert.ToDecimal(txtPrice.Text.Trim());
            service.AddService();  // Insert new service into DB
            LoadData();            // Refresh DataGridView
            ClearFields();         // Clear input fields
            MessageBox.Show("Service added successfully.");
        }

     
        // Updates the selected service in the database
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow != null)
            {
                service.ServiceID = Convert.ToInt32(dgvServices.CurrentRow.Cells["ServiceID"].Value);
                service.ServiceName = txtServiceName.Text.Trim();
                service.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                service.UpdateService(); // Update service in DB
                LoadData();              // Refresh DataGridView
                ClearFields();           // Clear input fields
                MessageBox.Show("Service updated successfully.");
            }
        }

       
        // Deletes the selected service from the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow != null)
            {
                service.ServiceID = Convert.ToInt32(dgvServices.CurrentRow.Cells["ServiceID"].Value);
                service.DeleteService(); // Remove service from DB
                LoadData();              // Refresh DataGridView
                ClearFields();           // Clear input fields
                MessageBox.Show("Service deleted successfully.");
            }
        }
      
        // Reloads all services into the DataGridView
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

       
        // Populates the form fields with selected service data
        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.CurrentRow != null)
            {
                txtServiceName.Text = dgvServices.CurrentRow.Cells["ServiceName"].Value.ToString();
                txtPrice.Text = dgvServices.CurrentRow.Cells["Price"].Value.ToString();
            }
        }

        
        // Clears the input TextBoxes after add/update/delete
        private void ClearFields()
        {
            txtServiceName.Clear();
            txtPrice.Clear();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
