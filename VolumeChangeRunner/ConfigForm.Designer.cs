namespace VolumeChangeRunner
{
    partial class ConfigForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvxEntries = new VolumeChangeRunner.Controls.ListViewEx();
            this.chdDriveLetter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdArguments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.btnEditEntry = new System.Windows.Forms.Button();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnCloneEntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvxEntries
            // 
            this.lvxEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvxEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdDriveLetter,
            this.chdCommand,
            this.chdArguments,
            this.chdEvent});
            this.lvxEntries.FullRowSelect = true;
            this.lvxEntries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvxEntries.HideSelection = false;
            this.lvxEntries.Location = new System.Drawing.Point(12, 12);
            this.lvxEntries.MultiSelect = false;
            this.lvxEntries.Name = "lvxEntries";
            this.lvxEntries.ShowGroups = false;
            this.lvxEntries.ShowItemToolTips = true;
            this.lvxEntries.Size = new System.Drawing.Size(760, 161);
            this.lvxEntries.TabIndex = 1;
            this.lvxEntries.UseCompatibleStateImageBehavior = false;
            this.lvxEntries.View = System.Windows.Forms.View.Details;
            this.lvxEntries.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvxEntries_MouseDoubleClick);
            // 
            // chdDriveLetter
            // 
            this.chdDriveLetter.Text = "Drive";
            this.chdDriveLetter.Width = 40;
            // 
            // chdCommand
            // 
            this.chdCommand.Text = "Command";
            this.chdCommand.Width = 400;
            // 
            // chdArguments
            // 
            this.chdArguments.Text = "Arguments";
            this.chdArguments.Width = 200;
            // 
            // chdEvent
            // 
            this.chdEvent.Text = "Event";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(684, 179);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddEntry.Location = new System.Drawing.Point(12, 179);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(88, 26);
            this.btnAddEntry.TabIndex = 2;
            this.btnAddEntry.Text = "&Add Entry...";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // btnEditEntry
            // 
            this.btnEditEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditEntry.Location = new System.Drawing.Point(106, 179);
            this.btnEditEntry.Name = "btnEditEntry";
            this.btnEditEntry.Size = new System.Drawing.Size(88, 26);
            this.btnEditEntry.TabIndex = 3;
            this.btnEditEntry.Text = "&Edit Entry...";
            this.btnEditEntry.UseVisualStyleBackColor = true;
            this.btnEditEntry.Click += new System.EventHandler(this.btnEditEntry_Click);
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteEntry.Location = new System.Drawing.Point(294, 179);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(88, 26);
            this.btnDeleteEntry.TabIndex = 5;
            this.btnDeleteEntry.Text = "&Delete Entry";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(590, 179);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(88, 26);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "&About...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnCloneEntry
            // 
            this.btnCloneEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCloneEntry.Location = new System.Drawing.Point(200, 179);
            this.btnCloneEntry.Name = "btnCloneEntry";
            this.btnCloneEntry.Size = new System.Drawing.Size(88, 26);
            this.btnCloneEntry.TabIndex = 4;
            this.btnCloneEntry.Text = "C&lone Entry";
            this.btnCloneEntry.UseVisualStyleBackColor = true;
            this.btnCloneEntry.Click += new System.EventHandler(this.btnCloneEntry_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 217);
            this.Controls.Add(this.btnCloneEntry);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnDeleteEntry);
            this.Controls.Add(this.btnEditEntry);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvxEntries);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ListViewEx lvxEntries;
        private System.Windows.Forms.ColumnHeader chdDriveLetter;
        private System.Windows.Forms.ColumnHeader chdCommand;
        private System.Windows.Forms.ColumnHeader chdArguments;
        private System.Windows.Forms.ColumnHeader chdEvent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.Button btnEditEntry;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnCloneEntry;
    }
}

