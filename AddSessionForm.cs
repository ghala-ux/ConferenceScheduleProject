using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferenceScheduleM
{
    public partial class AddSessionForm : Form
    {
        private ConferenceManager<Session> manager;

        public AddSessionForm(ConferenceManager<Session> sessionManager)
        {
            InitializeComponent();
            this.manager = sessionManager;

            // Fill ComboBox with Session Types
            cmbType.Items.Add("Keynote");
            cmbType.Items.Add("Workshop");
            cmbType.Items.Add("Presentation");
            cmbType.Items.Add("PanelDiscussion");
            cmbType.SelectedIndex = 0;
        }
        public AddSessionForm()
        {
            InitializeComponent();
        }

        private void AddSessionForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please fill all required fields (ID and Name).");
                return;
            }

            // Create new session
            Session newSession = new Session
            {
                ID = txtID.Text,
                Name = txtName.Text,
                StartTime = dtpStartTime.Value,
                Type = (SessionType)cmbType.SelectedIndex
            };

            // Add to manager
            manager.AddInitialData(newSession);

            MessageBox.Show($"SUCCESS: Session '{newSession.Name}' added with ID: {newSession.ID}");

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
