namespace ConferenceScheduleM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnManageSessions = new System.Windows.Forms.Button();
            this.btnManageSpeakers = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(245, 90);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(154, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Conference Schedule Manager";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnManageSessions
            // 
            this.btnManageSessions.Location = new System.Drawing.Point(283, 130);
            this.btnManageSessions.Name = "btnManageSessions";
            this.btnManageSessions.Size = new System.Drawing.Size(75, 58);
            this.btnManageSessions.TabIndex = 2;
            this.btnManageSessions.Text = "Manage Sessions";
            this.btnManageSessions.UseVisualStyleBackColor = true;
            this.btnManageSessions.Click += new System.EventHandler(this.btnManageSessions_Click);
            // 
            // btnManageSpeakers
            // 
            this.btnManageSpeakers.Location = new System.Drawing.Point(283, 224);
            this.btnManageSpeakers.Name = "btnManageSpeakers";
            this.btnManageSpeakers.Size = new System.Drawing.Size(75, 48);
            this.btnManageSpeakers.TabIndex = 3;
            this.btnManageSpeakers.Text = "Manage Speakers";
            this.btnManageSpeakers.UseVisualStyleBackColor = true;
            this.btnManageSpeakers.Click += new System.EventHandler(this.btnManageSpeakers_Click);
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(283, 307);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(75, 23);
            this.btnViewAll.TabIndex = 4;
            this.btnViewAll.Text = "View All Conference Items";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(283, 364);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 589);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.btnManageSpeakers);
            this.Controls.Add(this.btnManageSessions);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conference Schedule Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnManageSessions;
        private System.Windows.Forms.Button btnManageSpeakers;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnExit;
    }
}

