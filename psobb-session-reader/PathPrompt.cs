using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace psobb_session_reader
{
    public partial class PathPrompt : Form
    {
        public PathPrompt()
        {
            InitializeComponent();
        }

        public string PromptText
        {
            get => _pathLabel.Text;
            set => _pathLabel.Text = value;
        }

        public string InitializationScriptPath
        {
            get => _pathTextBox.Text;
            set => _pathTextBox.Text = value;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            _initializationScriptPathDialog.FileName = InitializationScriptPath;
            DialogResult result = _initializationScriptPathDialog.ShowDialog();

            if (result == DialogResult.OK)
                InitializationScriptPath = _initializationScriptPathDialog.FileName;
        }

        private void PathPrompt_Load(object sender, EventArgs e)
        {
            int height = _mainPanel.Controls
                .Cast<Control>()
                .Sum(control => control.Height);

            Size clientSize = ClientSize;
            clientSize.Height = height + _mainPanel.Padding.Vertical;
            ClientSize = clientSize;

            MaximumSize = new Size(int.MaxValue, Height);
            MinimumSize = new Size(0, Height);
        }
    }
}
