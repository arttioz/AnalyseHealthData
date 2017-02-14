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
using AnalyseHealthData.Model;
using AnalyseHealthData.Controller;


namespace AnalyseHealthData
{
    public partial class MainForm : Form
    {
        private AnalyseFileController afc ;
        private AnalyseDeathCertController adc;
        private MergeDeathDataController mdc;

        private String defaultPath = "C:\\dev\\data\\Saraburi\\HDC Saraburi";
        private String defaultExportPath = " C:\\dev\\data\\link";
       


        public MainForm()
        {
            InitializeComponent();
            filePathTextBox.Text = defaultPath;
            exportFolderTextBox.Text = defaultExportPath;
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

            if(adc == null)
            {
                adc = new AnalyseDeathCertController(deathCertFileTextBox.Text, statusTextBox);
            }
            else
            {
                adc.setFile(deathCertFileTextBox.Text);
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

        private void deathCertBrowseButton_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog fildDialog = new OpenFileDialog();
            DialogResult result = fildDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = fildDialog.FileName;
                if (!string.IsNullOrWhiteSpace(file))
                {
                    deathCertFileTextBox.Text = file;

                }
            }
        }

        private void mergeDeathButton_Click(object sender, EventArgs e)
        {
            if (adc != null)
            {
                adc.analyseFile(exportFolderTextBox.Text, deathCertFileTextBox.Text);
            }
        }

        private void meargeDeathDataButton_Click(object sender, EventArgs e)
        {
            List<HealthCareData> deathFromHealthData = afc.joinDeathList;
            List<DeathCertData> deathFromDeathCertData = adc.deathTrafficlist;

            if (mdc == null)
            {
                mdc = new MergeDeathDataController();
            }
            mdc.mergeDeathData(deathFromHealthData, deathFromDeathCertData, exportFolderTextBox.Text, statusTextBox);

        }
    }
}
