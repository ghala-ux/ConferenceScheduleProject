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
    public partial class Form1 : Form
    {
        private ConferenceManager<Session> sessionManager;
        private ConferenceManager<Speaker> speakerManager;
        public Form1()
        {
            InitializeComponent();
            sessionManager = new ConferenceManager<Session>();
            speakerManager = new ConferenceManager<Speaker>();
        }

        private void btnManageSessions_Click(object sender, EventArgs e)
        {

            SessionForm sessionForm = new SessionForm(sessionManager);
            sessionForm.Show();
        }

        private void btnManageSpeakers_Click(object sender, EventArgs e)
        {
            SpeakerForm speakerForm = new SpeakerForm(speakerManager);
            speakerForm.Show();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            ViewAllForm viewForm = new ViewAllForm(sessionManager, speakerManager);
            viewForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
             "Are you sure you want to exit?",
             "Exit Confirmation",
             MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
