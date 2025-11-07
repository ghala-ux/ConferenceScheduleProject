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
    public partial class SessionForm : Form
    {
        private ConferenceManager<Session> manager;

        public SessionForm(ConferenceManager<Session> sessionManager)
        {
            InitializeComponent();
            this.manager = sessionManager;
            RefreshList();
        }
        // Refresh the ListBox with current sessions
        private void RefreshList()
        {
            lstSessions.Items.Clear();

            foreach (var session in manager.dataList)
            {
                lstSessions.Items.Add($"ID: {session.ID} | {session.Name} | {session.Type}");
            }
        }
        public SessionForm()
        {
            InitializeComponent();
        }

        private void lstSessions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSessionForm addForm = new AddSessionForm(manager);
            addForm.ShowDialog(); // Use ShowDialog for modal window
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
                               $"Time: {result.StartTime.ToShortTimeString()}\nType: {result.Type}";
                MessageBox.Show(details, "Search Result");
            }
            else
            {
                MessageBox.Show($"Session with key '{searchKey}' not found.");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstSessions.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a session to delete.");
                return;
            }

            string selectedText = lstSessions.SelectedItem.ToString();
            string id = selectedText.Split('|')[0].Replace("ID:", "").Trim();

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete session {id}?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                manager.DeleteItem(id);
                MessageBox.Show("Session deleted successfully.");
                RefreshList();
            }
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            if (manager.dataList.Count == 0)
            {
                MessageBox.Show("No sessions to display.");
                return;
            }

            string allSessions = $"Total Sessions: {manager.dataList.Count}\n\n";

            foreach (var session in manager.dataList)
            {
                allSessions += $"ID: {session.ID}\n";
                allSessions += $"Name: {session.Name}\n";
                allSessions += $"Time: {session.StartTime.ToShortTimeString()}\n";
                allSessions += $"Type: {session.Type}\n";
                allSessions += "------------------------\n";
            }

            MessageBox.Show(allSessions, "All Sessions");
        }
    }
}