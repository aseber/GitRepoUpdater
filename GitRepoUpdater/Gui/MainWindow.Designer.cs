using System.Collections.Generic;

namespace GitMultiUpdate.Gui
{
    partial class mainWindow
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
            this.directoriesList = new System.Windows.Forms.CheckedListBox();
            this.pullFetchDirectoriesButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.directoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // directoriesList
            // 
            this.directoriesList.CheckOnClick = true;
            this.directoriesList.FormattingEnabled = true;
            this.directoriesList.Location = new System.Drawing.Point(0, 27);
            this.directoriesList.Margin = new System.Windows.Forms.Padding(2);
            this.directoriesList.Name = "directoriesList";
            this.directoriesList.Size = new System.Drawing.Size(484, 214);
            this.directoriesList.TabIndex = 0;
            // 
            // pullFetchDirectoriesButton
            // 
            this.pullFetchDirectoriesButton.Location = new System.Drawing.Point(0, 245);
            this.pullFetchDirectoriesButton.Margin = new System.Windows.Forms.Padding(2);
            this.pullFetchDirectoriesButton.Name = "pullFetchDirectoriesButton";
            this.pullFetchDirectoriesButton.Size = new System.Drawing.Size(484, 27);
            this.pullFetchDirectoriesButton.TabIndex = 1;
            this.pullFetchDirectoriesButton.Text = "Pull / Fetch Directories";
            this.pullFetchDirectoriesButton.UseVisualStyleBackColor = true;
            this.pullFetchDirectoriesButton.Click += new System.EventHandler(this.PullAndFetchDirectories);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(0, 2);
            this.urlTextBox.MaxLength = 260;
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(447, 20);
            this.urlTextBox.TabIndex = 2;
            // 
            // directoryButton
            // 
            this.directoryButton.Location = new System.Drawing.Point(453, 2);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(31, 23);
            this.directoryButton.TabIndex = 3;
            this.directoryButton.Text = "...";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.ChangeRootDirectory);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 272);
            this.Controls.Add(this.directoryButton);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.pullFetchDirectoriesButton);
            this.Controls.Add(this.directoriesList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainWindow";
            this.Text = "GitRepoUpdater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox directoriesList;
        private System.Windows.Forms.Button pullFetchDirectoriesButton;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button directoryButton;
    }
}

