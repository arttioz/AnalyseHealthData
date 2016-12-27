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
using AnalyseHealthData.Controller;


namespace AnalyseHealthData
{
    public partial class MainForm : Form
    {
        private AnalyseFileController afc ;


        public MainForm()
        {
            InitializeComponent();
            filePathTextBox.Text = "C: \\Users\\Arttioz\\Google ไดรฟ์\\โครงการ Injury Data Center_ สสส\\ลงพื้นที่ สงขลา RTI\\59";
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                filePathTextBox.Text = fbd.SelectedPath;

                string[] files = Directory.GetFiles(fbd.SelectedPath);

                System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

            }
        }

        private void readFilebutton_Click(object sender, EventArgs e)
        {
            if(afc == null)
            {
                afc = new AnalyseFileController(filePathTextBox.Text, statusTextBox);
            }
            else
            {
                afc.setFolder(filePathTextBox.Text);
            }
            
        }

        private void analyseButton_Click(object sender, EventArgs e)
        {
            if (afc != null)
            {
                afc.analyseFile(exportFolderTextBox.Text);
            }
        }

        private void exportFolderbutton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                exportFolderTextBox.Text = fbd.SelectedPath;

                string[] files = Directory.GetFiles(fbd.SelectedPath);
            }
        }
    }
}
