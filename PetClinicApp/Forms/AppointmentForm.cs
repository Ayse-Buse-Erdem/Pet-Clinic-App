using System;
using System.Windows.Forms;
using PetClinicApp.Classes;

namespace PetClinicApp.Forms
{
    public partial class AppointmentForm : Form
    {
        Appointment appointment = new Appointment();

        public AppointmentForm()
        {
            InitializeComponent();
            LoadPets();
            LoadServices();
            LoadAppointments();
        }

        private void LoadPets()
        {
            cmbPet.DataSource = appointment.GetAllPets();
            cmbPet.DisplayMember = "PetName";
            cmbPet.ValueMember = "PetID";
        }

        private void LoadServices()
        {
            cmbService.DataSource = appointment.GetAllServices();
            cmbService.DisplayMember = "ServiceName";
            cmbService.ValueMember = "ServiceID";
        }

        private void LoadAppointments()
        {
            dgvAppointments.DataSource = appointment.GetAllAppointments();
        }

        // ClearFields method: Clears form inputs
        private void ClearFields()
        {
            cmbPet.SelectedIndex = -1;
            cmbService.SelectedIndex = -1;
            dtpAppointmentDate.Value = DateTime.Now;
            txtNotes.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            appointment.PetID = (int)cmbPet.SelectedValue;
            appointment.ServiceID = (int)cmbService.SelectedValue;
            appointment.AppointmentDate = dtpAppointmentDate.Value;
            appointment.Notes = txtNotes.Text.Trim();

            appointment.AddAppointment();
            LoadAppointments();
            MessageBox.Show("Appointment added successfully.");

            ClearFields(); // Clear form after adding
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                appointment.AppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);
                appointment.PetID = (int)cmbPet.SelectedValue;
                appointment.ServiceID = (int)cmbService.SelectedValue;
                appointment.AppointmentDate = dtpAppointmentDate.Value;
                appointment.Notes = txtNotes.Text.Trim();

                appointment.UpdateAppointment();
                LoadAppointments();
                MessageBox.Show("Appointment updated successfully.");

                ClearFields(); // Clear form after updating
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                appointment.AppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["AppointmentID"].Value);
                appointment.DeleteAppointment();
                LoadAppointments();
                MessageBox.Show("Appointment deleted successfully.");

                ClearFields(); // Clear form after deleting 
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppointments.CurrentRow != null)
            {
                cmbPet.SelectedValue = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["PetID"].Value);
                cmbService.SelectedValue = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["ServiceID"].Value);
                dtpAppointmentDate.Value = Convert.ToDateTime(dgvAppointments.CurrentRow.Cells["AppointmentDate"].Value);
                txtNotes.Text = dgvAppointments.CurrentRow.Cells["Notes"].Value.ToString();
            }
        }

        private void lblPet_Click(object sender, EventArgs e)
        {

        }

        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
