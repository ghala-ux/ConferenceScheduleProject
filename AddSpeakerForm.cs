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
    public partial class AddSpeakerForm : Form
    {
        private ConferenceManager<Speaker> manager;

        public AddSpeakerForm(ConferenceManager<Speaker> speakerManager)
        {
            InitializeComponent();
            this.manager = speakerManager;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please fill all required fields (ID and Name).");
                return;
            }

            // Create new speaker
            Speaker newSpeaker = new Speaker
            {
                ID = txtID.Text,
                Name = txtName.Text,
                Affiliation = txtAffiliation.Text,
                Biography = txtBiography.Text
            };

            // Add to manager
            manager.AddInitialData(newSpeaker);

            MessageBox.Show($"SUCCESS: Speaker '{newSpeaker.Name}' added with ID: {newSpeaker.ID}");

            this.Close();
        }
        public AddSpeakerForm()
        {
            InitializeComponent();
        }

        private void AddSpeakerForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
