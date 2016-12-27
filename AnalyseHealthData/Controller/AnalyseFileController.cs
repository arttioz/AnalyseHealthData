using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace AnalyseHealthData.Controller
{

    class AnalyseFileController
    {

        const String opdFile = "diagnosis_opd.txt";
        const String ipdFile = "diagnosis_ipd.txt";
        const String serviceFile = "service.txt";
        const String accidentFile = "accident.txt";
        const String personFile = "person.txt";
        const String admidFile = "admission.txt";

        private List<FileInfo> opdFiles = new List<FileInfo>() ;
        private List<FileInfo> ipdFiles = new List<FileInfo>();
        private List<FileInfo> serviceFiles = new List<FileInfo>();
        private List<FileInfo> accidentFiles = new List<FileInfo>();
        private List<FileInfo> personFiles = new List<FileInfo>();
        private List<FileInfo> admidFiles = new List<FileInfo>();

        private List<String> opdList = new List<String>();
        private List<String> ipdList = new List<String>();
        private List<String> serviceList = new List<String>();
        private List<String> accidentList = new List<String>();
        private List<String> personList = new List<String>();
        private List<String> admidList = new List<String>();

        private List<List<FileInfo>> allFiles = new List<List<FileInfo>>();

        System.Windows.Forms.RichTextBox statusTextBox;
        private String folderPath;

        private String exportFolder;

        public AnalyseFileController(String folderPath, System.Windows.Forms.RichTextBox statusTextBox)
        {
            this.allFiles.Add(this.opdFiles);
            this.allFiles.Add(this.ipdFiles);
            this.allFiles.Add(this.serviceFiles);
            this.allFiles.Add(this.accidentFiles);
            this.allFiles.Add(this.personFiles);
            this.allFiles.Add(this.admidFiles);

            this.statusTextBox = statusTextBox;
            setFolder(folderPath);
        }


        public void setFolder(String folderPath)
        {
            this.opdFiles.Clear();
            this.ipdFiles.Clear();
            this.serviceFiles.Clear();
            this.accidentFiles.Clear();
            this.personFiles.Clear();
            this.admidFiles.Clear();


            this.folderPath = folderPath;
            statusTextBox.AppendText("Folder Path: " + folderPath);

            if (folderPath.Length > 0)
            {
                readFolder();
            }

          
        }


        public void readFolder()
        {
            try
            {
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(folderPath));
                String folderName = "";

                foreach (var dir in dirs)
                {
                    folderName = dir.Substring(dir.LastIndexOf("\\") + 1);
                    addtext(Environment.NewLine);
                    addtext("Folder: "+ folderName);
                    readFiles(dir);

                    readSubFolder(dir);
                }
                addtext(Environment.NewLine);
                addtext(dirs.Count + " directories found.");
            }
            catch (UnauthorizedAccessException UAEx)
            {
                statusTextBox.AppendText(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                statusTextBox.AppendText(PathEx.Message);
            }


            viewFile();
        }

        public void readSubFolder(String dirPath)
        {
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(dirPath));
            String folderName = "";
            foreach (var dir in dirs)
            {
                folderName = dir.Substring(dir.LastIndexOf("\\") + 1);
                addtext(Environment.NewLine);
                addtext("Sub Folder: " + folderName);
                readFiles(dir);

                readSubFolder(dir);
            }
        }

        public void readFiles(String dirPath)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            FileInfo[] files = dir.GetFiles("*.txt");

            String fileName = "";
            foreach (FileInfo file in files)
            {
                fileName = file.Name;
                addtext(Environment.NewLine);
                addtext("File: " + fileName);

                storeFile(file);
            }
        }

        public void storeFile(FileInfo file)
        {
            String fileName = file.Name;

            if (fileName.Equals(opdFile))
            {
                opdFiles.Add(file);
            }
            else if (fileName.Equals(ipdFile))
            {
                ipdFiles.Add(file);
            }
            else if (fileName.Equals(accidentFile))
            {
                accidentFiles.Add(file);
            }
            else if (fileName.Equals(personFile))
            {
                personFiles.Add(file);
            }
            else if (fileName.Equals(serviceFile))
            {
                serviceFiles.Add(file);
            }
            else if (fileName.Equals(admidFile))
            {
                admidFiles.Add(file);
            }
        }

        public void viewFile()
        {
            double len = 0;
            string result = "0";

            foreach (List<FileInfo> fileArray in allFiles)
            {
                FileInfo[] files = fileArray.ToArray();
                String filename = files[0].Name;
                len = 0;

                foreach (var file in files)
                {
                    len = len + file.Length;
                }

                result = fileSize(len);

                addtext(Environment.NewLine);
                addtext("File: " + filename + " has " + files.Length + " files, Total Size " + result);
            }
        }

        public String fileSize(double length)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = length;
            int order = 0;
            string result = "0";
            order = 0;

            while (len >= 1024 && ++order < sizes.Length)
            {
                len = len / 1024;
            }

            result = String.Format("{0:0.##} {1}", len, sizes[order]);

            return result;
        }



        public void analyseFile(String exportFolder)
        {
           
            this.exportFolder = exportFolder;
            addtext(Environment.NewLine);
            addtext("Combinding file");
            foreach (List<FileInfo> fileArray in allFiles)
            {
                FileInfo[] files = fileArray.ToArray();

                combineTextFile(files);
            }
            addtext(Environment.NewLine);
            addtext("Combind file finished");
        }

        public void combineTextFile(FileInfo[] files)
        {
            String filename = files[0].Name;
            string line = null;
            int line_number = 0;

            String filefullName = Path.Combine(this.exportFolder, filename); 


            FileStream fileStream = new FileStream(filefullName, FileMode.Create);
            fileStream.Close();

            using (StreamWriter writer = new StreamWriter(filefullName))
            {

                int index = 0;
                foreach (var file in files)
                {
                    line_number = 0;

                    using (StreamReader reader = new StreamReader(file.FullName))
                    {


                        while ((line = reader.ReadLine()) != null)
                        {
                            if (index > 0 && line_number == 0)
                            {

                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(line))
                                {
                                    line.Replace(Environment.NewLine, "");
                                    writer.WriteLine(line);
                                }
                            }

                            line_number++;
                        }
                    }

                    index++;
                }
            }
        }


        public void addtext(String text)
        {
            statusTextBox.AppendText(text);

        }
    }
}
