using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VolumeChangeRunner
{
    public enum EntryEditorMode { Add, Edit }

    public partial class EntryEditorForm : Controls.ModernForm
    {
        RunnerEntry currentRunnerEntry;
        StringBuilder validationStringBuilder;

        public EntryEditorForm(EntryEditorMode editorMode, RunnerEntry runnerEntry)
        {
            InitializeComponent();

            switch (editorMode)
            {
                case EntryEditorMode.Add:
                    Text = "Add Entry";
                    currentRunnerEntry = new RunnerEntry();
                    break;

                case EntryEditorMode.Edit:
                    Text = "Edit Entry";
                    currentRunnerEntry = (RunnerEntry)runnerEntry.Clone();
                    break;

                    throw new Exception();
            }

            cmbDrive.DataSource = new BindingList<string>(DriveInfo.GetDrives()
                .Select(x => x.Name)
                .ToList());
            cmbDrive.Format += (s, e) =>
            {
                var driveInfo = new DriveInfo((string)e.ListItem);
                if (driveInfo.IsReady)
                    e.Value = $"{driveInfo.Name} ({driveInfo.VolumeLabel})";
                else
                    e.Value = driveInfo.Name;
            };

            cmbEvent.DataSource = Enum.GetValues(typeof(RunnerEventType))
                .Cast<RunnerEventType>()
                .ToDictionary(x => x.GetAttribute<DescriptionAttribute>().Description, y => y)
                .ToList();
            cmbEvent.DisplayMember = "Key";
            cmbEvent.ValueMember = "Value";

            SuspendLayout();

            /* NOTE: editable DropDown + databinding = screwy and prone to not working
             *  this doesn't work w/ nonexistent drives -> "cmbDrive.DataBindings.Add(nameof(cmbDrive.SelectedItem), currentRunnerEntry, nameof(currentRunnerEntry.DriveLetter), false, DataSourceUpdateMode.OnPropertyChanged);" */
            cmbDrive.SelectedIndex = cmbDrive.FindString(currentRunnerEntry.DriveLetter);
            if (cmbDrive.SelectedIndex == -1) cmbDrive.Text = currentRunnerEntry.DriveLetter;

            txtCommand.DataBindings.Add(nameof(txtCommand.Text), currentRunnerEntry, nameof(currentRunnerEntry.CommandToRun), false, DataSourceUpdateMode.OnPropertyChanged);
            txtArguments.DataBindings.Add(nameof(txtArguments.Text), currentRunnerEntry, nameof(currentRunnerEntry.CommandArguments), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbEvent.DataBindings.Add(nameof(cmbEvent.SelectedValue), currentRunnerEntry, nameof(currentRunnerEntry.EventType), false, DataSourceUpdateMode.OnPropertyChanged);

            ResumeLayout();
        }

        public RunnerEntry GetRunnerEntry()
        {
            return (RunnerEntry)currentRunnerEntry.Clone();
        }

        private void cmbDrive_Validating(object sender, CancelEventArgs e)
        {
            var comboBox = (sender as ComboBox);
            try
            {
                /* If something was entered manually, check if we can't find that in our DataSource */
                if (comboBox.SelectedIndex == -1 && !string.IsNullOrEmpty(comboBox.Text))
                    comboBox.SelectedIndex = comboBox.FindString(comboBox.Text);

                /* Let's get DriveInfo for the selected item OR the manually entered text, if not found in the DataSource */
                var driveInfo = new DriveInfo(comboBox.SelectedItem == null ? comboBox.Text : (string)comboBox.SelectedItem);

                /* Store drive letter in RunnerEntry */
                currentRunnerEntry.DriveLetter = driveInfo.Name.ToUpper();
                e.Cancel = false;
            }

            /* DriveInfo is good at exception handling */
            catch (ArgumentException)
            {
                validationStringBuilder.AppendLine("No or Invalid drive letter specified.");
                e.Cancel = true;
            }
        }

        private void txtCommand_Validating(object sender, CancelEventArgs e)
        {
            var textBox = (sender as TextBox);

            if (string.IsNullOrEmpty(textBox.Text))
            {
                validationStringBuilder.AppendLine("No command specified.");
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void EntryEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.Cancel)
            {
                validationStringBuilder = new StringBuilder();

                cmbDrive.CausesValidation = txtCommand.CausesValidation = txtArguments.CausesValidation = true;
                e.Cancel = !ValidateChildren();

                if (e.Cancel)
                    MessageBox.Show(validationStringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cmbDrive.CausesValidation = txtCommand.CausesValidation = txtArguments.CausesValidation = false;
            }
        }

        private void btnCommandBrowse_Click(object sender, EventArgs e)
        {
            var directory = (!string.IsNullOrEmpty(txtCommand.Text) ? Path.GetDirectoryName(txtCommand.Text) : string.Empty);
            if (Directory.Exists(directory)) ofdSelectCommand.InitialDirectory = directory;

            if (ofdSelectCommand.ShowDialog() == DialogResult.OK)
                txtCommand.Text = ofdSelectCommand.FileName;
        }
    }
}
