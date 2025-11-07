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
    public partial class ViewAllForm : Form
    {
        private ConferenceManager<Session> sessionManager;
        private ConferenceManager<Speaker> speakerManager;

        public ViewAllForm(ConferenceManager<Session> sessions, ConferenceManager<Speaker> speakers)
        {
            InitializeComponent();
            this.sessionManager = sessions;
            this.speakerManager = speakers;
            DisplayAllData();
        }

        private void DisplayAllData()
        {
            txtDisplay.Clear();

            // Display Sessions
            txtDisplay.AppendText("========== ALL SESSIONS ==========\n\n");

            if (sessionManager.dataList.Count == 0)
            {
                txtDisplay.AppendText("No sessions available.\n\n");
            }
            else
            {
                foreach (var session in sessionManager.dataList)
                {
                    txtDisplay.AppendText($"ID: {session.ID}\n");
                    txtDisplay.AppendText($"Name: {session.Name}\n");
                    txtDisplay.AppendText($"Time: {session.StartTime.ToShortTimeString()}\n");
                    txtDisplay.AppendText($"Type: {session.Type}\n");
                    txtDisplay.AppendText("---------------------------\n");
                }
            }

            // Display Speakers
            txtDisplay.AppendText("\n========== ALL SPEAKERS ==========\n\n");

            if (speakerManager.dataList.Count == 0)
            {
                txtDisplay.AppendText("No speakers available.\n");
            }
            else
            {
                foreach (var speaker in speakerManager.dataList)
                {
                    txtDisplay.AppendText($"ID: {speaker.ID}\n");
                    txtDisplay.AppendText($"Name: {speaker.Name}\n");
                    txtDisplay.AppendText($"Affiliation: {speaker.Affiliation}\n");
                    txtDisplay.AppendText("---------------------------\n");
                }
            }
        }
        public ViewAllForm()
        {
            InitializeComponent();
        }

        private void ViewAllForm_Load(object sender, EventArgs e)
        {

        }
    }
}
