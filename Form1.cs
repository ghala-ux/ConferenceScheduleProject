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
        public bool isDarkMode = false;

        public Form1()
        {
            InitializeComponent();
            sessionManager = new ConferenceManager<Session>();
            speakerManager = new ConferenceManager<Speaker>();
        }

        private void btnManageSessions_Click(object sender, EventArgs e)
        {

            SessionForm sessionForm = new SessionForm(sessionManager);
            if (isDarkMode)
            {
                sessionForm.ApplyDarkMode();
            }

            sessionForm.Show();
        }

        private void btnManageSpeakers_Click(object sender, EventArgs e)
        {
            SpeakerForm speakerForm = new SpeakerForm(speakerManager);
            if (isDarkMode)
            {
                speakerForm.ApplyDarkMode();
            }
            speakerForm.Show();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            ViewAllForm viewForm = new ViewAllForm(sessionManager, speakerManager);
            if (isDarkMode)
            {
                viewForm.ApplyDarkMode();
                viewForm.Show();
            }
                
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            lblTitle.ForeColor = Color.Black;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.BackColor = SystemColors.Control;
                    ctrl.ForeColor = Color.Black;
                    isDarkMode = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            lblTitle.ForeColor = Color.White;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.BackColor = Color.Gray;
                    ctrl.ForeColor = Color.White;
                }
            }
            isDarkMode = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
