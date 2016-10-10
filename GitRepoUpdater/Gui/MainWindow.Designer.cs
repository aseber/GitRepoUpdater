using System.Collections.Generic;

namespace GitRepoUpdater.Gui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.directoriesList = new System.Windows.Forms.CheckedListBox();
            this.pullFetchDirectoriesButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.directoryButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoriesList
            // 
            this.directoriesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoriesList.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.directoriesList, 2);
            this.directoriesList.FormattingEnabled = true;
            this.directoriesList.Location = new System.Drawing.Point(6, 57);
            this.directoriesList.Margin = new System.Windows.Forms.Padding(6);
            this.directoriesList.Name = "directoriesList";
            this.directoriesList.Size = new System.Drawing.Size(963, 394);
            this.directoriesList.TabIndex = 0;
            // 
            // pullFetchDirectoriesButton
            // 
            this.pullFetchDirectoriesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pullFetchDirectoriesButton.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.pullFetchDirectoriesButton, 2);
            this.pullFetchDirectoriesButton.Location = new System.Drawing.Point(6, 468);
            this.pullFetchDirectoriesButton.Margin = new System.Windows.Forms.Padding(6);
            this.pullFetchDirectoriesButton.Name = "pullFetchDirectoriesButton";
            this.pullFetchDirectoriesButton.Size = new System.Drawing.Size(963, 55);
            this.pullFetchDirectoriesButton.TabIndex = 1;
            this.pullFetchDirectoriesButton.Text = "Pull / Fetch Directories";
            this.pullFetchDirectoriesButton.UseVisualStyleBackColor = true;
            this.pullFetchDirectoriesButton.Click += new System.EventHandler(this.PullAndFetchDirectories);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.urlTextBox.Location = new System.Drawing.Point(6, 10);
            this.urlTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.urlTextBox.MaxLength = 260;
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(884, 31);
            this.urlTextBox.TabIndex = 2;
            // 
            // directoryButton
            // 
            this.directoryButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.directoryButton.Location = new System.Drawing.Point(904, 6);
            this.directoryButton.Margin = new System.Windows.Forms.Padding(6);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(62, 39);
            this.directoryButton.TabIndex = 3;
            this.directoryButton.Text = "...";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.ChangeRootDirectory);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.89744F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.102564F));
            this.tableLayoutPanel1.Controls.Add(this.directoriesList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pullFetchDirectoriesButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.directoryButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.urlTextBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.1579F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.8421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(975, 529);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 529);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "mainWindow";
            this.Text = "GitRepoUpdater";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox directoriesList;
        private System.Windows.Forms.Button pullFetchDirectoriesButton;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

