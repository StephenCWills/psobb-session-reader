using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using psobb_session_reader.Definitions;

namespace psobb_session_reader
{
    public partial class MainWindow : Form
    {
        private Configuration _configuration;
        private List<Session> _sessions;
        private List<Session> _filteredSessions;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                try { _configuration = Configuration.Load(); }
                catch { _configuration = new Configuration(); }

                InitializePSOPath();
                CheckForSessionsDirectory();
                LoadSessions();

                InitializeGridHeaderContextMenu();
            }));
        }

        private void ReloadSessionDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSessions();
        }

        private void LoadSessions()
        {
            string psoPath = _configuration.PSOPath ?? string.Empty;
            string sessionsDirectory = Path.Combine(psoPath, "sessions");

            if (!Directory.Exists(sessionsDirectory))
                return;

            _sessions = Directory.EnumerateFiles(sessionsDirectory, "*-session-counters.txt")
                .Select(filePath => new Session(filePath))
                .OrderByDescending(session => session.SessionTime)
                .ToList();

            _filteredSessions = new List<Session>(_sessions);

            _sessionBindingSource.DataSource = _filteredSessions;
            _sessionDataGridView.AutoResizeColumns();
            _sessionCountLabel.Text = $"Count: {_filteredSessions.Count}";
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _configuration.MainWindowX = Location.X;
            _configuration.MainWindowY = Location.Y;
            _configuration.MainWindowWidth = Width;
            _configuration.MainWindowHeight = Height;

            try { _configuration.Save(); }
            catch { MessageBox.Show($"Unable to create settings file \"{Configuration.DefaultPath}\"", "Unable to create settings file!", MessageBoxButtons.OK, MessageBoxIcon.Error); };
        }

        private void SessionDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex != _sectionIDDataGridViewTextBoxColumn.Index)
                return;

            bool selected = e.State.HasFlag(DataGridViewElementStates.Selected);
            e.PaintBackground(e.ClipBounds, selected);

            SectionID sectionID = (SectionID)e.Value;
            Image image = _sectionIDImageList.Images[sectionID.Name];
            Point location = e.CellBounds.Location;
            location.Offset(2, 2);
            e.Graphics.DrawImageUnscaled(image, location);

            e.PaintContent(e.ClipBounds);

            e.Handled = true;
        }

        private void TabContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            Point p = _sessionDetailTabControl.PointToClient(Cursor.Position);
            int index = GetTabIndex(p);

            if (index >= 0)
                _sessionDetailTabControl.SelectTab(index);
            else
                e.Cancel = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region [ Load PSO Path ]

        private void InitializePSOPath()
        {
            if (string.IsNullOrEmpty(_configuration.PSOPath))
                _configuration.PSOPath = FindPSOPath();

            if (string.IsNullOrEmpty(_configuration.PSOPath))
            {
                string promptText = new StringBuilder()
                    .AppendLine("Unable to locate PSO directory with Kill Counter addon installed.")
                    .AppendLine("Enter the path to the initialization script (init.lua) for the Kill Counter addon:")
                    .ToString();

                _configuration.PSOPath = PromptForPSOPath(promptText);
            }
        }

        private void CheckForSessionsDirectory()
        {
            string psoPath = _configuration.PSOPath ?? string.Empty;
            string sessionsDirectory = Path.Combine(psoPath, "sessions");

            if (!Directory.Exists(sessionsDirectory))
            {
                string messageText = new StringBuilder()
                    .AppendLine("Unable to locate the sessions directory.")
                    .AppendLine("Session data is saved only if the sessions directory exists.")
                    .AppendLine("Would you like the session reader to attempt to create it?")
                    .ToString();

                DialogResult messageBoxResult = MessageBox.Show(messageText, "Create sessions directory?", MessageBoxButtons.YesNo);

                if (messageBoxResult != DialogResult.Yes)
                    return;

                try
                {
                    Directory.CreateDirectory(sessionsDirectory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error creating sessions directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string FindPSOPath()
        {
            string[] searchDirectories =
            {
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
            };

            List<string> killCounterDirectories = new[] { Path.GetDirectoryName(Application.ExecutablePath) }
                .Concat(searchDirectories.SelectMany(EnumerateDirectories))
                .Where(directory => Directory.Exists(Path.Combine(directory, "addons", "Kill Counter")))
                .ToList();

            if (killCounterDirectories.Count != 1)
                return null;

            return killCounterDirectories[0];
        }

        private string PromptForPSOPath(string promptText = null)
        {
            using (PathPrompt prompt = new PathPrompt())
            {
                if (promptText != null)
                    prompt.PromptText = promptText;

                prompt.InitializationScriptPath = _configuration.PSOPath;
                DialogResult result = prompt.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string killCounterDirectory = Path.GetDirectoryName(prompt.InitializationScriptPath);
                    string addonsDirectory = Path.GetDirectoryName(killCounterDirectory);
                    return Path.GetDirectoryName(addonsDirectory);
                }

                return null;
            }
        }

        private static IEnumerable<string> EnumerateDirectories(string path)
        {
            try { return Directory.EnumerateDirectories(path, "*"); }
            catch { return Enumerable.Empty<string>(); }
        }

        private static IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            try { return Directory.EnumerateFiles(path, searchPattern); }
            catch { return Enumerable.Empty<string>(); }
        }

        private void ChangePSOPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptForPSOPath();
            CheckForSessionsDirectory();
            LoadSessions();
        }

        #endregion

        #region [ Show / Hide Data Columns ]

        private void InitializeGridHeaderContextMenu()
        {
            foreach (DataGridViewColumn column in _sessionDataGridView.Columns)
            {
                column.HeaderCell.ContextMenuStrip = _gridHeaderContextMenuStrip;

                string text = column.HeaderText;
                ToolStripMenuItem item = new ToolStripMenuItem(text);
                item.CheckOnClick = true;
                item.Checked = column.Visible;
                item.CheckedChanged += (sender, args) => column.Visible = item.Checked;
                _gridHeaderContextMenuStrip.Items.Add(item);
            }
        }

        #endregion

        #region [ Opening / Closing Tabs ]

        private void SessionDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = _sessionDataGridView.Rows[e.RowIndex];
            Session session = (Session)row.DataBoundItem;

            TabPage detailTab = _sessionDetailTabControl.TabPages
                .Cast<TabPage>()
                .FirstOrDefault(tab => Equals(session, tab.Tag));

            if (detailTab == null)
            {
                detailTab = new TabPage(session.SessionTime.ToString("g"));
                detailTab.Tag = session;

                RichTextBox detailTextBox = new RichTextBox();
                detailTextBox.Dock = DockStyle.Fill;
                detailTextBox.Text = session.ToDetail();
                detailTextBox.ReadOnly = true;

                detailTab.Controls.Add(detailTextBox);
                _sessionDetailTabControl.TabPages.Add(detailTab);

                UpdateTabs();
            }

            _sessionDetailTabControl.SelectTab(detailTab);
        }

        private void CloseCurrentTab_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = _sessionDetailTabControl.SelectedTab;
            _sessionDetailTabControl.TabPages.Remove(selectedTab);
            UpdateTabs();
        }

        private void CloseAllTabs_Click(object sender, EventArgs e)
        {
            _sessionDetailTabControl.TabPages.Clear();
            UpdateTabs();
        }

        private void UpdateTabs()
        {
            bool hasTab = (_sessionDetailTabControl.TabPages.Count > 0);
            _closeCurrentTabToolStripMenuItem.Enabled = hasTab;
            _closeAllTabsToolStripMenuItem.Enabled = hasTab;
            _sessionSplitContainer.Panel1Collapsed = !hasTab;
        }

        #endregion

        #region [ Tab Reordering ]

        private int _dragTabIndex = -1;

        private void SessionDetailTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _dragTabIndex = _sessionDetailTabControl.SelectedIndex;
        }

        private void SessionDetailTabControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                _dragTabIndex = -1;

            if (_dragTabIndex == -1)
                return;

            Point mouseLocation = e.Location;
            int hoverTabIndex = GetTabIndex(mouseLocation);

            if (hoverTabIndex == -1 || hoverTabIndex == _dragTabIndex)
                return;

            TabPage dragTab = _sessionDetailTabControl.TabPages[_dragTabIndex];
            TabPage hoverTab = _sessionDetailTabControl.TabPages[hoverTabIndex];
            _sessionDetailTabControl.TabPages[_dragTabIndex] = hoverTab;
            _sessionDetailTabControl.TabPages[hoverTabIndex] = dragTab;
            _sessionDetailTabControl.SelectTab(dragTab);
            _dragTabIndex = hoverTabIndex;
        }

        private int GetTabIndex(Point location)
        {
            for (int i = 0; i < _sessionDetailTabControl.TabCount; i++)
            {
                Rectangle r = _sessionDetailTabControl.GetTabRect(i);

                if (r.Contains(location))
                    return i;
            }

            return -1;
        }

        #endregion
    }
}
