using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolumeChangeRunner
{
    public partial class ConfigForm : Controls.ModernForm
    {
        public ConfigForm()
        {
            InitializeComponent();

            Text = $"{Application.ProductName} - Configuration";

            btnEditEntry.DataBindings.Add(nameof(btnEditEntry.Enabled), lvxEntries, nameof(lvxEntries.IsAnyEntrySelected), false, DataSourceUpdateMode.OnPropertyChanged);
            btnCloneEntry.DataBindings.Add(nameof(btnCloneEntry.Enabled), lvxEntries, nameof(lvxEntries.IsAnyEntrySelected), false, DataSourceUpdateMode.OnPropertyChanged);
            btnDeleteEntry.DataBindings.Add(nameof(btnDeleteEntry.Enabled), lvxEntries, nameof(lvxEntries.IsAnyEntrySelected), false, DataSourceUpdateMode.OnPropertyChanged);

            lvxEntries.Columns[lvxEntries.Columns.Count - 1].Width = -2;

            UpdateListEntries();
        }

        private void UpdateListEntries()
        {
            lvxEntries.BeginUpdate();

            var lastSelected = (lvxEntries.IsAnyEntrySelected ? lvxEntries.SelectedIndices[0] : -1);

            lvxEntries.SelectedIndices.Clear();
            lvxEntries.Items.Clear();

            foreach (var entry in Program.ApplicationConfig.RunnerEntries)
            {
                var listViewItem = new ListViewItem { Text = entry.DriveLetter, Tag = entry };
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, entry.CommandToRun));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, entry.CommandArguments));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, entry.EventType.GetAttribute<DescriptionAttribute>().Description));
                lvxEntries.Items.Add(listViewItem);
            }

            lvxEntries.SelectedIndices.Clear();
            if (lastSelected >= 0 && lastSelected < lvxEntries.Items.Count)
                lvxEntries.SelectedIndices.Add(lastSelected);
            else if ((lastSelected - 1) >= 0 && (lastSelected - 1) < lvxEntries.Items.Count)
                lvxEntries.SelectedIndices.Add(lastSelected - 1);

            lvxEntries.EndUpdate();

            RunnerApplicationContext.CurrentContext.UpdateNotifyIcon();
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            using (var entryEditorForm = new EntryEditorForm(EntryEditorMode.Add, null))
            {
                if (entryEditorForm.ShowDialog() == DialogResult.OK)
                {
                    Program.ApplicationConfig.RunnerEntries.Add(entryEditorForm.GetRunnerEntry());
                    UpdateListEntries();
                }
            }
        }

        private void btnEditEntry_Click(object sender, EventArgs e)
        {
            EditEntry(lvxEntries.SelectedItems[0]);
        }

        private void btnCloneEntry_Click(object sender, EventArgs e)
        {
            var entryToClone = (RunnerEntry)lvxEntries.SelectedItems[0].Tag;
            var entryIndex = Program.ApplicationConfig.RunnerEntries.IndexOf(entryToClone);
            Program.ApplicationConfig.RunnerEntries.Insert(entryIndex + 1, entryToClone);

            UpdateListEntries();
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really delete the selected entry?", "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Program.ApplicationConfig.RunnerEntries.Remove((RunnerEntry)lvxEntries.SelectedItems[0].Tag);
                UpdateListEntries();
            }
        }

        private void EditEntry(ListViewItem listViewItem)
        {
            var runnerEntry = (RunnerEntry)listViewItem.Tag;
            using (var entryEditorForm = new EntryEditorForm(EntryEditorMode.Edit, runnerEntry))
            {
                if (entryEditorForm.ShowDialog() == DialogResult.OK)
                {
                    var index = Program.ApplicationConfig.RunnerEntries.IndexOf(runnerEntry);
                    Program.ApplicationConfig.RunnerEntries[index] = entryEditorForm.GetRunnerEntry();
                    UpdateListEntries();
                }
            }
        }

        private void lvxEntries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listView = (sender as Controls.ListViewEx);

            var clickedItem = listView.HitTest(e.Location).Item;
            if (clickedItem != null) EditEntry(clickedItem);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            RunnerApplicationContext.CurrentContext?.ShowAboutBox();
        }
    }
}
