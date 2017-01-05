using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using AnalyseHealthData.Model;
using System.Threading;

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

        private Dictionary<string, int> opdDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> ipdDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> serviceDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> accidentDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> personDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> admidDataIndex = new Dictionary<string, int>();

        private List<List<FileInfo>> allFiles = new List<List<FileInfo>>();

        private Dictionary<String, HealthCareData> seq_healthCareDataMap = new Dictionary<string, HealthCareData>();
        private Dictionary<String, List<HealthCareData>> pid_healthCareDataMap = new Dictionary<string, List<HealthCareData>>();
        private List<HealthCareData> healthCareDataList = new List<HealthCareData>();

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

            this.opdList.Clear();
            this.ipdList.Clear();
            this.serviceList.Clear();
            this.accidentList.Clear();
            this.personList.Clear();
            this.admidList.Clear();


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

        public List<String> getLineArray(FileInfo file)
        {
            String fileName = file.Name;

            if (fileName.Equals(opdFile))
            {
                return opdList;
            }
            else if (fileName.Equals(ipdFile))
            {
                return ipdList;
            }
            else if (fileName.Equals(accidentFile))
            {
                return accidentList;
            }
            else if (fileName.Equals(personFile))
            {
                return personList;
            }
            else if (fileName.Equals(serviceFile))
            {
                return serviceList;
            }
            else if (fileName.Equals(admidFile))
            {
                return admidList;
            }

            return null;
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

                //combineTextFile(files);
                readTextFile(files);
            }
            addtext(Environment.NewLine);
            addtext("Combind file finished");

            linkData();

            exportlinkData();

        }

        public void combineTextFile(FileInfo[] files)
        {
            String filename = files[0].Name;
            string line = null;
            int line_number = 0;

            List<String> saveLine = getLineArray(files[0]);

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
                                    line = line.Replace(Environment.NewLine, "");
                                    saveLine.Add(line);
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
        public void readTextFile(FileInfo[] files)
        {
            String filename = files[0].Name;
            string line = null;
            int line_number = 0;
            List<String> saveLine = getLineArray(files[0]);

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
                                line = line.Replace(Environment.NewLine, "");
                                saveLine.Add(line);
                            }
                        }
                        line_number++;
                    }
                }

                index++;
            }
       
        }



        public void linkData()
        {
            addtext("Linkiing data");
            seq_healthCareDataMap.Clear();
            pid_healthCareDataMap.Clear();
            HealthCareData healthCareData = null;

            serviceDataIndex = setupDataDic(serviceList[0]);


            addtext("Read Service" +  Environment.NewLine);
            for (int index = 1; index < serviceList.Count; index++)
            {
                 healthCareData = new HealthCareData();
                String line = serviceList[index];
                string[] data = line.Split('|');

                String seq = getVal("SEQ", data, serviceDataIndex);
                String pid = getVal("PID", data, serviceDataIndex);
                String date_serv = getVal("DATE_SERV", data, serviceDataIndex);

                healthCareData.seq = seq;
                healthCareData.pid = pid;
                healthCareData.hospcode = getVal("HOSPCODE", data, serviceDataIndex);
                healthCareData.hn = getVal("HN", data, serviceDataIndex);
                healthCareData.date_serv = date_serv;
                healthCareData.time_serv = getVal("TIME_SERV", data, serviceDataIndex);
                healthCareData.location = getVal("LOCATION", data, serviceDataIndex);

                healthCareData.type_in = getVal("TYPEIN", data, serviceDataIndex);
                healthCareData.refer_in_hosp = getVal("REFERINHOSP", data, serviceDataIndex);
                healthCareData.cause_in = getVal("CAUSEIN", data, serviceDataIndex);
                healthCareData.typeout = getVal("TYPEOUT", data, serviceDataIndex);

                seq_healthCareDataMap.Add(seq, healthCareData);

                if (!pid_healthCareDataMap.ContainsKey(pid))
                {
                    List<HealthCareData> careData = new List<HealthCareData>();
                    careData.Add(healthCareData);

                    pid_healthCareDataMap.Add(pid, careData);
                }
                else
                {
                    List<HealthCareData> careData = pid_healthCareDataMap[pid];
                    careData.Add(healthCareData);
                }
                
            }

            addtext("Read Admit" + Environment.NewLine);
            admidDataIndex = setupDataDic(admidList[0]);
            for (int index = 1; index < admidList.Count; index++)
            {
                String line = admidList[index];
                string[] data = line.Split('|');

                String seq = getVal("SEQ", data, admidDataIndex);
                String pid = getVal("PID", data, admidDataIndex);
                String date_admit = getVal("DATETIME_ADMIT", data, admidDataIndex);
                String date_serv = date_admit.Substring(0, 8);

                healthCareData = new HealthCareData();

                healthCareData.seq = seq;
                healthCareData.pid = pid;
                healthCareData.hospcode = getVal("HOSPCODE", data, serviceDataIndex);
                healthCareData.hn = getVal("HN", data, serviceDataIndex);
                healthCareData.date_serv = date_serv;
                healthCareData.time_serv = date_serv;
                

                healthCareData.type_in = getVal("TYPEIN", data, serviceDataIndex);
                healthCareData.refer_in_hosp = getVal("REFERINHOSP", data, serviceDataIndex);
                healthCareData.cause_in = getVal("CAUSEIN", data, serviceDataIndex);


                healthCareData.an = getVal("AN", data, admidDataIndex);
                healthCareData.discharge_status = getVal("DISCHSTATUS", data, admidDataIndex);
                healthCareData.date_admit = date_admit;

                if (seq_healthCareDataMap.ContainsKey(seq))
                {
                    healthCareData = seq_healthCareDataMap[seq];
                    healthCareData.an = getVal("AN", data, admidDataIndex);
                    healthCareData.discharge_status = getVal("DISCHSTATUS", data, admidDataIndex);
                    healthCareData.date_admit = date_admit;

                }
                else
                {
                    seq_healthCareDataMap.Add(seq, healthCareData);
                   
                    if (pid_healthCareDataMap.ContainsKey(pid))
                    {
                        List<HealthCareData> careData = pid_healthCareDataMap[pid];
                        careData.Add(healthCareData);
                    }
                    else
                    {
                        List<HealthCareData> careData = new List<HealthCareData>();
                        careData.Add(healthCareData);
                        pid_healthCareDataMap.Add(pid, careData);
                    }
                }
             }


            addtext("Read Person" + Environment.NewLine);
            personDataIndex = setupDataDic(personList[0]);
            for (int index = 1; index < personList.Count; index++)
            {
               
                String line = personList[index];
                string[] data = line.Split('|');

                String  pid = getVal("PID", data, personDataIndex);

                if (pid_healthCareDataMap.ContainsKey(pid))
                {
                    List<HealthCareData> careDatas = pid_healthCareDataMap[pid];

                    careDatas.ForEach(delegate (HealthCareData careData)
                    {
                        healthCareData.cid = getVal("CID", data, personDataIndex);

                        careData.prename = getVal("PRENAME", data, personDataIndex);
                        careData.name = getVal("NAME", data, personDataIndex);
                        careData.lname = getVal("LNAME", data, personDataIndex);
                        careData.sex = getVal("SEX", data, personDataIndex);
                        careData.birthdate = getVal("BIRTH", data, personDataIndex);
                        careData.m_status = getVal("MSTATUS", data, personDataIndex);
                        careData.occupation_old = getVal("OCCUPATION_OLD", data, personDataIndex);
                        careData.occupation_new = getVal("OCCUPATION_NEW", data, personDataIndex);
                        careData.religion = getVal("RELIGION", data, personDataIndex);
                    });
                }


            }


         

            addtext("Read OPD" + Environment.NewLine);
            opdDataIndex = setupDataDic(opdList[0]);
            string diagType = "";
            string icd10 = "";
            for (int index = 1; index < opdList.Count; index++)
            {
                String line = opdList[index];
                string[] data = line.Split('|');
                String seq = getVal("SEQ", data, opdDataIndex);

                if (seq_healthCareDataMap.ContainsKey(seq))
                {
                    healthCareData = seq_healthCareDataMap[seq];

                    diagType = getVal("DIAGTYPE", data, opdDataIndex);
                    icd10 = getVal("DIAGCODE", data, opdDataIndex);
                    healthCareData.setICD10(diagType, icd10);

                }
            }


            addtext("Read IPD" + Environment.NewLine);
            ipdDataIndex = setupDataDic(ipdList[0]);
             diagType = "";
             icd10 = "";
            String date; 
            for (int index = 1; index < ipdList.Count; index++)
            {
                String line = ipdList[index];
                string[] data = line.Split('|');

                String pid = getVal("PID", data, ipdDataIndex);
                diagType = getVal("DIAGTYPE", data, ipdDataIndex);
                icd10 = getVal("DIAGCODE", data, ipdDataIndex);
                date = getVal("DATETIME_ADMIT", data, ipdDataIndex);

                if (pid_healthCareDataMap.ContainsKey(pid))
                {
                    List<HealthCareData> careDatas = pid_healthCareDataMap[pid];

                    if (careDatas.Count == 1)
                    {
                        healthCareData = careDatas[0];
                        healthCareData.setICD10(diagType, icd10);
                    }
                    else if (careDatas.Count > 1)
                    {
                        careDatas.ForEach(delegate (HealthCareData careData)
                        {
                            healthCareData = careData;
                            if (healthCareData.checkSameDataByDate(date))
                            {
                                healthCareData.setICD10(diagType, icd10);
                            }

                        });
                    }
                }
            }

            String typeout = "";
            String discharge_status = "";

            foreach (var item in seq_healthCareDataMap)
            {
                healthCareData = item.Value;

                String date_serv = healthCareData.date_serv;
                String birth_date = healthCareData.birthdate;

                try
                {
                    int year_serv = int.Parse( date_serv.Substring(0, 4) );
                    int year_birth = int.Parse(birth_date.Substring(0, 4));

                    int age = year_serv - year_birth;

                    healthCareData.age_at_service = age;

                }
                catch(Exception e)
                {
                    Console.WriteLine(date_serv + "Serve " + birth_date + "Birth " +  e.ToString());
                }

                typeout = healthCareData.typeout;
                discharge_status = healthCareData.discharge_status;
                int typeout_int = 0;
                int discharge_int = 0;
                try
                {
                    if(typeout.Length > 0)
                    {
                        typeout_int = int.Parse(typeout);
                    }

                    if(discharge_status.Length > 0)
                    {
                        discharge_int = int.Parse(discharge_status);
                    }
                    
                 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString() + "typeout " + typeout + " discharge_status " + discharge_status);
                }

                if( (typeout_int >= 4 && typeout_int <= 6 ) || (discharge_int == 8 || discharge_int == 9))
                {
                    healthCareData.deathstatus = "1";
                }
                else
                {
                    healthCareData.deathstatus = "0";
                }

            }

        }

        public void exportlinkData()
        {
            String filename = "health_data.csv";
            String filefullName = Path.Combine(this.exportFolder, filename);


            FileStream fileStream = new FileStream(filefullName, FileMode.Create);
            fileStream.Close();

            using (StreamWriter writer = new StreamWriter(filefullName))
            {
                writer.WriteLine(HealthCareData.toCVSHeader());
                HealthCareData healthCareData = null;

               

                foreach (var item in seq_healthCareDataMap)
                {
                    healthCareData = item.Value;

                    if(healthCareData.icd10_principle_dx.Contains("V") || healthCareData.icd10_external_cause.Contains("V"))
                    {
                        writer.WriteLine(healthCareData.toCVS());
                    }
                }

            }

            addtext("Export Link Data Completed, ROW :" + seq_healthCareDataMap.Count + Environment.NewLine);
     
        }

        public String getVal(String key,string[] data,Dictionary<string, int> dataDic)
        {

            return data[dataDic[key]].Trim();
        }

        public Dictionary<string, int> setupDataDic(String headerLine)
        {
      
            Dictionary<string, int> dataDicIndex = new Dictionary<string, int>();
            string[] dataDic = headerLine.Split('|');

            for(int i = 0; i < dataDic.Length; i++)
            {
                string key = dataDic[i];

                dataDicIndex.Add(key, i);

            }

            return dataDicIndex;
        }

        public void addtext(String text)
        {
            statusTextBox.AppendText(text);
        }
    }
}
