namespace VolumeChangeRunner
{
    partial class EntryEditorForm
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
            this.lblDrive = new System.Windows.Forms.Label();
            this.btnCommandBrowse = new System.Windows.Forms.Button();
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.txtArguments = new System.Windows.Forms.TextBox();
            this.lblArguments = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.lblSeparatorDummy = new System.Windows.Forms.Label();
            this.ofdSelectCommand = new System.Windows.Forms.OpenFileDialog();
            this.cmbDrive = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Location = new System.Drawing.Point(12, 15);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(35, 13);
            this.lblDrive.TabIndex = 0;
            this.lblDrive.Text = "Drive:";
            // 
            // btnCommandBrowse
            // 
            this.btnCommandBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommandBrowse.Location = new System.Drawing.Point(372, 38);
            this.btnCommandBrowse.Name = "btnCommandBrowse";
            this.btnCommandBrowse.Size = new System.Drawing.Size(50, 20);
            this.btnCommandBrowse.TabIndex = 4;
            this.btnCommandBrowse.Text = "...";
            this.btnCommandBrowse.UseVisualStyleBackColor = true;
            this.btnCommandBrowse.Click += new System.EventHandler(this.btnCommandBrowse_Click);
            // 
            // cmbEvent
            // 
            this.cmbEvent.CausesValidation = false;
            this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvent.FormattingEnabled = true;
            this.cmbEvent.IntegralHeight = false;
            this.cmbEvent.Location = new System.Drawing.Point(100, 90);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(150, 21);
            this.cmbEvent.TabIndex = 8;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(12, 93);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(38, 13);
            this.lblEvent.TabIndex = 7;
            this.lblEvent.Text = "Event:";
            // 
            // txtArguments
            // 
            this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArguments.CausesValidation = false;
            this.txtArguments.Location = new System.Drawing.Point(100, 64);
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.Size = new System.Drawing.Size(322, 20);
            this.txtArguments.TabIndex = 6;
            // 
            // lblArguments
            // 
            this.lblArguments.AutoSize = true;
            this.lblArguments.Location = new System.Drawing.Point(12, 67);
            this.lblArguments.Name = "lblArguments";
            this.lblArguments.Size = new System.Drawing.Size(60, 13);
            this.lblArguments.TabIndex = 5;
            this.lblArguments.Text = "Arguments:";
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.CausesValidation = false;
            this.txtCommand.Location = new System.Drawing.Point(100, 38);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(266, 20);
            this.txtCommand.TabIndex = 3;
            this.txtCommand.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommand_Validating);
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(12, 41);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(57, 13);
            this.lblCommand.TabIndex = 2;
            this.lblCommand.Text = "Command:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(334, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 26);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkay.Location = new System.Drawing.Point(240, 139);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(88, 26);
            this.btnOkay.TabIndex = 10;
            this.btnOkay.Text = "&OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            // 
            // lblSeparatorDummy
            // 
            this.lblSeparatorDummy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparatorDummy.Location = new System.Drawing.Point(12, 123);
            this.lblSeparatorDummy.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.lblSeparatorDummy.Name = "lblSeparatorDummy";
            this.lblSeparatorDummy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSeparatorDummy.Size = new System.Drawing.Size(410, 2);
            this.lblSeparatorDummy.TabIndex = 9;
            // 
            // ofdSelectCommand
            // 
            this.ofdSelectCommand.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            // 
            // cmbDrive
            // 
            this.cmbDrive.CausesValidation = false;
            this.cmbDrive.FormattingEnabled = true;
            this.cmbDrive.Location = new System.Drawing.Point(100, 12);
            this.cmbDrive.Name = "cmbDrive";
            this.cmbDrive.Size = new System.Drawing.Size(150, 21);
            this.cmbDrive.TabIndex = 1;
            this.cmbDrive.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDrive_Validating);
            // 
            // EntryEditorForm
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 177);
            this.Controls.Add(this.cmbDrive);
            this.Controls.Add(this.lblSeparatorDummy);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDrive);
            this.Controls.Add(this.btnCommandBrowse);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.cmbEvent);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lblArguments);
            this.Controls.Add(this.txtArguments);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EntryEditorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDrive;
        private System.Windows.Forms.Button btnCommandBrowse;
        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtArguments;
        private System.Windows.Forms.Label lblArguments;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Label lblSeparatorDummy;
        private System.Windows.Forms.OpenFileDialog ofdSelectCommand;
        private System.Windows.Forms.ComboBox cmbDrive;
    }
}