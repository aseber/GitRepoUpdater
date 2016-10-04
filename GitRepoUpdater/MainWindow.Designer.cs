using System.Collections.Generic;

namespace GitMultiUpdate
{
    partial class MainWindow
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
            this.DirectoriesList = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DirectoriesList
            // 
            this.DirectoriesList.CheckOnClick = true;
            this.DirectoriesList.FormattingEnabled = true;
            this.DirectoriesList.Location = new System.Drawing.Point(2, 1);
            this.DirectoriesList.Name = "DirectoriesList";
            this.DirectoriesList.Size = new System.Drawing.Size(969, 472);
            this.DirectoriesList.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(969, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Pull / Fetch Directories";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PullAndFetchDirectories);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 529);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DirectoriesList);
            this.Name = "MainWindow";
            this.Text = "GitRepoUpdater";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox DirectoriesList;
        private System.Windows.Forms.Button button1;
    }
}

