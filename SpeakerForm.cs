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
    public partial class SpeakerForm : Form
    {
        private ConferenceManager<Speaker> manager;

        public SpeakerForm(ConferenceManager<Speaker> speakerManager)
        {
            InitializeComponent();
            this.manager = speakerManager;
            RefreshList();
        }

        private void RefreshList()
        {
            lstSpeakers.Items.Clear();

            foreach (var speaker in manager.dataList)
            {
                lstSpeakers.Items.Add($"ID: {speaker.ID} | {speaker.Name} | {speaker.Affiliation}");
            }
        }

        public SpeakerForm()
        {
            InitializeComponent();
        }

        private void SpeakerForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSpeakerForm addForm = new AddSpeakerForm(manager);
            addForm.ShowDialog();
            RefreshList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKey = txtSearch.Text;

            if (string.IsNullOrEmpty(searchKey))
            {
                MessageBox.Show("Please enter ID or Name to search.");
                return;
            }

            var result = manager.dataList.Find(s =>
                s.ID.Equals(searchKey, StringComparison.OrdinalIgnoreCase) ||
                s.Name.IndexOf(searchKey, StringComparison.OrdinalIgnoreCase) >= 0
            );

            if (result != null)
            {
                string details = $"ID: {result.ID}\nName: {result.Name}\n" +
                               $"Affiliation: {result.Affiliation}\nBiography: {result.Biography}";
                MessageBox.Show(details, "Search Result");
            }
            else
            {
                MessageBox.Show($"Speaker with key '{searchKey}' not found.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstSpeakers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a speaker to delete.");
                return;
            }

            string selectedText = lstSpeakers.SelectedItem.ToString();
            string id = selectedText.Split('|')[0].Replace("ID:", "").Trim();

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete speaker {id}?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                manager.DeleteItem(id);
                MessageBox.Show("Speaker deleted successfully.");
                RefreshList();
            }
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            if (manager.dataList.Count == 0)
            {
                MessageBox.Show("No speakers to display.");
                return;
            }

            string allSpeakers = $"Total Speakers: {manager.dataList.Count}\n\n";

            foreach (var speaker in manager.dataList)
            {
                allSpeakers += $"ID: {speaker.ID}\n";
                allSpeakers += $"Name: {speaker.Name}\n";
                allSpeakers += $"Affiliation: {speaker.Affiliation}\n";
                allSpeakers += "------------------------\n";
            }

            MessageBox.Show(allSpeakers, "All Speakers");
        }

        private void lstSpeakers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //دالة اللون 
        public void ApplyDarkMode()
        {
            this.BackColor = Color.Black;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ForeColor = Color.White;
                }
                else if (ctrl is TextBox)
                {
                    ctrl.BackColor = Color.FromArgb(30, 30, 30);
                    ctrl.ForeColor = Color.White;
                }
                else if (ctrl is Button)
                {
                    ctrl.BackColor = Color.Gray;
                    ctrl.ForeColor = Color.White;
                }
            }
        }
    }
}
    