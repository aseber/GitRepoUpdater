using System.Collections.Generic;

namespace GitRepoUpdater.Gui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.directoriesList = new System.Windows.Forms.CheckedListBox();
            this.pullFetchDirectoriesButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.directoryButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoriesList
            // 
            this.directoriesList.CheckOnClick = true;
            this.tableLayoutPanel.SetColumnSpan(this.directoriesList, 2);
            this.directoriesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directoriesList.FormattingEnabled = true;
            this.directoriesList.Location = new System.Drawing.Point(3, 30);
            this.directoriesList.Name = "directoriesList";
            this.directoriesList.Size = new System.Drawing.Size(481, 202);
            this.directoriesList.TabIndex = 0;
            this.directoriesList.TabStop = false;
            // 
            // pullFetchDirectoriesButton
            // 
            this.pullFetchDirectoriesButton.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.pullFetchDirectoriesButton, 2);
            this.pullFetchDirectoriesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pullFetchDirectoriesButton.Location = new System.Drawing.Point(3, 238);
            this.pullFetchDirectoriesButton.Name = "pullFetchDirectoriesButton";
            this.pullFetchDirectoriesButton.Size = new System.Drawing.Size(481, 34);
            this.pullFetchDirectoriesButton.TabIndex = 2;
            this.pullFetchDirectoriesButton.Text = "Pull / Fetch Directories";
            this.pullFetchDirectoriesButton.UseVisualStyleBackColor = true;
            this.pullFetchDirectoriesButton.Click += new System.EventHandler(this.PullAndFetchDirectories);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.urlTextBox.Location = new System.Drawing.Point(3, 3);
            this.urlTextBox.MaxLength = 260;
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(441, 20);
            this.urlTextBox.TabIndex = 2;
            this.urlTextBox.TabStop = false;
            // 
            // directoryButton
            // 
            this.directoryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directoryButton.Location = new System.Drawing.Point(450, 3);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(34, 21);
            this.directoryButton.TabIndex = 1;
            this.directoryButton.Text = "...";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.ChangeRootDirectory);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.89744F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.102564F));
            this.tableLayoutPanel.Controls.Add(this.directoriesList, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.pullFetchDirectoriesButton, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.directoryButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.urlTextBox, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.48936F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.51064F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(487, 275);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(487, 275);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Git Repository Updater";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox directoriesList;
        private System.Windows.Forms.Button pullFetchDirectoriesButton;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}

