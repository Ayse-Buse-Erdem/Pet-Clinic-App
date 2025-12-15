using PetClinicApp.Classes;
using PetClinicApp.Forms; // Namespace for the child forms
using System;
using System.Windows.Forms;
using System.Drawing;


namespace PetClinicApp
{
    public partial class MainForm : Form
    {
        // Constructor: Initializes the MainForm
        // Sets up MDI container and menu item event handlers
        public MainForm()
        {
            InitializeComponent();

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient client)
                {
                    client.BackgroundImage = Properties.Resources.Pet21;
                    client.BackgroundImageLayout = ImageLayout.Stretch; 
                }
            }


            // Set the form as an MDI container for child forms
            this.IsMdiContainer = true;

            // Attach menu item click events to respective handlers
            this.customersToolStripMenuItem.Click += customersToolStripMenuItem_Click;
            this.petsToolStripMenuItem.Click += petsToolStripMenuItem_Click;
            this.servicesToolStripMenuItem.Click += servicesToolStripMenuItem_Click;
            this.appointmentsToolStripMenuItem.Click += appointmentsToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        // Exit menu item click event
        // Closes the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Customers menu item click event
        // Opens CustomerForm as an MDI child
        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.MdiParent = this; // Set MDI parent
            customerForm.Show();
        }

        // Pets menu item click event
        // Opens PetForm as an MDI child
        private void petsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PetForm petForm = new PetForm();
            petForm.MdiParent = this;
            petForm.Show();
        }

        // Services menu item click event
        // Opens ServiceForm as an MDI child
        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceForm serviceForm = new ServiceForm();
            serviceForm.MdiParent = this;
            serviceForm.Show();
        }

        // Appointments menu item click event
        // Opens AppointmentForm as an MDI child
        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentForm appointmentForm = new AppointmentForm();
            appointmentForm.MdiParent = this;
            appointmentForm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
