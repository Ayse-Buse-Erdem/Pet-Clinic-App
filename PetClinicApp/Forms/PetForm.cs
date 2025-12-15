using System;
using System.Windows.Forms;
using PetClinicApp.Classes;

namespace PetClinicApp.Forms
{
    public partial class PetForm : Form
    {
        Pet pet = new Pet();

        public PetForm()
        {
            InitializeComponent();
            LoadCustomers();   // Loads customer list into ComboBox
            LoadPets(); // Loads pets into DataGridView
        }

        private void LoadCustomers()
        {
            cmbCustomer.DataSource = pet.GetAllCustomers();
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "CustomerID";
        }

        private void LoadPets()
        {
            dgvPets.DataSource = pet.GetAllPets();
        }

        // Method to clear input fields after Add or Update
        private void ClearFields()
        {
            txtPetName.Clear();
            txtSpecies.Clear();
            txtBreed.Clear();
            cmbCustomer.SelectedIndex = -1; // Reset ComboBox selection
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pet.CustomerID = (int)cmbCustomer.SelectedValue;
            pet.PetName = txtPetName.Text.Trim();
            pet.Species = txtSpecies.Text.Trim();
            pet.Breed = txtBreed.Text.Trim();
            pet.AddPet();
            LoadPets();
            MessageBox.Show("Pet added successfully.");

            ClearFields(); // Clear fields after adding
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPets.CurrentRow != null)
            {
                pet.PetID = Convert.ToInt32(dgvPets.CurrentRow.Cells["PetID"].Value);
                pet.CustomerID = (int)cmbCustomer.SelectedValue;
                pet.PetName = txtPetName.Text.Trim();
                pet.Species = txtSpecies.Text.Trim();
                pet.Breed = txtBreed.Text.Trim();
                pet.UpdatePet();
                LoadPets();
                MessageBox.Show("Pet updated successfully.");

                ClearFields(); // Clear fields after updating
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPets.CurrentRow != null)
            {
                pet.PetID = Convert.ToInt32(dgvPets.CurrentRow.Cells["PetID"].Value);
                pet.DeletePet();
                LoadPets();
                MessageBox.Show("Pet deleted successfully.");

                ClearFields(); // Clear fields after deleting 
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPets();
        }

        private void dgvPets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPets.CurrentRow != null)
            {
                cmbCustomer.SelectedValue = Convert.ToInt32(dgvPets.CurrentRow.Cells["CustomerID"].Value);
                txtPetName.Text = dgvPets.CurrentRow.Cells["PetName"].Value.ToString();
                txtSpecies.Text = dgvPets.CurrentRow.Cells["Species"].Value.ToString();
                txtBreed.Text = dgvPets.CurrentRow.Cells["Breed"].Value.ToString();
            }
        }

        private void PetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
