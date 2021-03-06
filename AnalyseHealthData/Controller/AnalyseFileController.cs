﻿using System;
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
        const String deathFile = "death.txt";

        private List<FileInfo> opdFiles = new List<FileInfo>() ;
        private List<FileInfo> ipdFiles = new List<FileInfo>();
        private List<FileInfo> serviceFiles = new List<FileInfo>();
        private List<FileInfo> accidentFiles = new List<FileInfo>();
        private List<FileInfo> personFiles = new List<FileInfo>();
        private List<FileInfo> admidFiles = new List<FileInfo>();
        private List<FileInfo> deathFiles = new List<FileInfo>();

        private List<String> opdList = new List<String>();
        private List<String> ipdList = new List<String>();
        private List<String> serviceList = new List<String>();
        private List<String> accidentList = new List<String>();
        private List<String> personList = new List<String>();
        private List<String> admidList = new List<String>();
        private List<String> deathList = new List<String>();

        private Dictionary<string, int> opdDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> ipdDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> serviceDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> accidentDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> personDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> admidDataIndex = new Dictionary<string, int>();
        private Dictionary<string, int> deathDataIndex = new Dictionary<string, int>();

        private List<List<FileInfo>> allFiles = new List<List<FileInfo>>();

        private Dictionary<String, HealthCareData> seq_healthCareDataMap = new Dictionary<string, HealthCareData>();
        private Dictionary<String, List<HealthCareData>> an_healthCareDataMap = new Dictionary<string, List<HealthCareData>>();
        private Dictionary<String, List<HealthCareData>> pid_healthCareDataMap = new Dictionary<string, List<HealthCareData>>();
        
        private List<HealthCareData> healthCareDataList = new List<HealthCareData>();


        public List<HealthCareData> joinDeathList = new List<HealthCareData>();

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
            this.allFiles.Add(this.deathFiles);

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
            this.deathFiles.Clear();

            this.opdList.Clear();
            this.ipdList.Clear();
            this.serviceList.Clear();
            this.accidentList.Clear();
            this.personList.Clear();
            this.admidList.Clear();
            this.deathList.Clear();
            this.joinDeathList.Clear();

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
                    addtextln("Folder: "+ folderName);
                    readFiles(dir);

                    readSubFolder(dir);
                }
               
                addtextln(dirs.Count + " directories found.");
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
               
                addtextln("Sub Folder: " + folderName);
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
               
                addtextln("File: " + fileName);

                storeFile(file);
            }
        }

        public void storeFile(FileInfo file)
        {
            String fileName = file.Name.ToLower();

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
            else if (fileName.Equals(deathFile))
            {
                deathFiles.Add(file);
            }
        }

        public List<String> getLineArray(FileInfo file)
        {
            String fileName = file.Name.ToLower();

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
            else if (fileName.Equals(deathFile))
            {
                return deathList;
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

                if(files.Count() > 0)
                {
                    String filename = files[0].Name;
                    len = 0;

                    foreach (var file in files)
                    {
                        len = len + file.Length;
                    }

                    result = fileSize(len);

                    addtextln("File: " + filename + " has " + files.Length + " files, Total Size " + result);
                }
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
           
            addtextln("Combinding file");
            foreach (List<FileInfo> fileArray in allFiles)
            {
                FileInfo[] files = fileArray.ToArray();

                combineTextFile(files);
                //readTextFile(files);
            }
            addtextln("Combind file finished");

            linkData();

            exportlinkData();

        }

        public void combineTextFile(FileInfo[] files)
        {
            if (files.Count() == 0)
                return;

            String filename = files[0].Name;
            filename = filename.Replace(".txt",".csv");

            string line = null;
            int line_number = 0;

            List<String> saveLine = getLineArray(files[0]);

            String filefullName = Path.Combine(this.exportFolder, filename); 


            FileStream fileStream = new FileStream(filefullName, FileMode.Create);
            fileStream.Close();

            System.Text.Encoding encode = Utils.GetEncoding(files[0].FullName);

            using (StreamWriter writer = new StreamWriter(filefullName))
            {

                int index = 0;
                foreach (var file in files)
                {
                    line_number = 0;

                    using (StreamReader reader = new StreamReader(file.FullName, encode))
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
                                    line = line.Replace(",", "");
                                    line = line.Replace(Environment.NewLine, "");
                                    line = line.Replace("|", ",");
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
            addtextln("Linkiing data");
            seq_healthCareDataMap.Clear();
            pid_healthCareDataMap.Clear();

            joinService();
            joinAdmission();
            joinPerson();
            joinDiganosis_OPD();
            joinDiganosis_IPD();
            joinAccident();
            joinDeath();
            calcualateData();


        }

        private void joinService()
        {

            serviceDataIndex =  Utils.setupDataDic(serviceList[0]);
            addtextln("Read Service" );

            HealthCareData healthCareData = null;
            for (int index = 1; index < serviceList.Count; index++)
            {
                healthCareData = new HealthCareData();
                String line = serviceList[index];
                string[] data = line.Split(',');

                String seq = Utils.getVal("SEQ", data, serviceDataIndex);
                String pid = Utils.getVal("PID", data, serviceDataIndex);
                String date_serv = Utils.getVal("DATE_SERV", data, serviceDataIndex);

                healthCareData.seq = seq;
                healthCareData.pid = pid;
                healthCareData.hospcode = Utils.getVal("HOSPCODE", data, serviceDataIndex);
                healthCareData.hn = Utils.getVal("HN", data, serviceDataIndex);
                healthCareData.date_serv = date_serv;
                healthCareData.time_serv = Utils.getVal("TIME_SERV", data, serviceDataIndex);
                healthCareData.location = Utils.getVal("LOCATION", data, serviceDataIndex);

                healthCareData.type_in = Utils.getVal("TYPEIN", data, serviceDataIndex);
                healthCareData.refer_in_hosp = Utils.getVal("REFERINHOSP", data, serviceDataIndex);
                healthCareData.cause_in = Utils.getVal("CAUSEIN", data, serviceDataIndex);
                healthCareData.typeout = Utils.getVal("TYPEOUT", data, serviceDataIndex);

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
                healthCareDataList.Add(healthCareData);
            }
        }

        private void joinAdmission()
        {
            HealthCareData healthCareData = null;
            addtextln("Read Admit" );
            admidDataIndex = Utils.setupDataDic(admidList[0]);
            for (int index = 1; index < admidList.Count; index++)
            {
                String line = admidList[index];
                string[] data = line.Split(',');

                String seq = Utils.getVal("SEQ", data, admidDataIndex);
                String pid = Utils.getVal("PID", data, admidDataIndex);
                String date_admit = Utils.getVal("DATETIME_ADMIT", data, admidDataIndex);
                String date_serv = date_admit.Substring(0, 8);
                String time_serv = date_admit.Substring(8, 6);

                healthCareData = new HealthCareData();

                healthCareData.seq = seq;
                healthCareData.pid = pid;
                healthCareData.hospcode = Utils.getVal("HOSPCODE", data, serviceDataIndex);
                healthCareData.hn = Utils.getVal("HN", data, serviceDataIndex);
                healthCareData.date_serv = date_serv;
                healthCareData.time_serv = time_serv;


                healthCareData.type_in = Utils.getVal("TYPEIN", data, serviceDataIndex);
                healthCareData.refer_in_hosp = Utils.getVal("REFERINHOSP", data, serviceDataIndex);
                healthCareData.cause_in = Utils.getVal("CAUSEIN", data, serviceDataIndex);


                healthCareData.an = Utils.getVal("AN", data, admidDataIndex);
                healthCareData.discharge_status = Utils.getVal("DISCHSTATUS", data, admidDataIndex);
                healthCareData.date_admit = date_admit;
                String an = Utils.getVal("AN", data, admidDataIndex);


                if (seq_healthCareDataMap.ContainsKey(seq))
                {

                    healthCareData = seq_healthCareDataMap[seq];
                    healthCareData.an = Utils.getVal("AN", data, admidDataIndex);
                    healthCareData.discharge_status = Utils.getVal("DISCHSTATUS", data, admidDataIndex);
                    healthCareData.date_admit = date_admit;
                }
                else
                {
                    seq_healthCareDataMap.Add(seq, healthCareData);
                    healthCareDataList.Add(healthCareData);


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


                if (an_healthCareDataMap.ContainsKey(an))
                {
                    List<HealthCareData> careData = an_healthCareDataMap[an];
                    careData.Add(healthCareData);
                }
                else
                {
                    List<HealthCareData> careData = new List<HealthCareData>();
                    careData.Add(healthCareData);
                    an_healthCareDataMap.Add(an, careData);
                }
            }
        }

        private void joinPerson()
        {
            addtextln("Read Person" );
            personDataIndex = Utils.setupDataDic(personList[0]);
            for (int index = 1; index < personList.Count; index++)
            {

                String line = personList[index];
                string[] data = line.Split(',');

                String pid = Utils.getVal("PID", data, personDataIndex);

                if (pid_healthCareDataMap.ContainsKey(pid))
                {
                    List<HealthCareData> careDatas = pid_healthCareDataMap[pid];

                    careDatas.ForEach(delegate (HealthCareData careData)
                    {
                        careData.cid = Utils.getVal("CID", data, personDataIndex);
                        careData.prename = Utils.getVal("PRENAME", data, personDataIndex);
                        careData.name = Utils.getVal("NAME", data, personDataIndex);
                        careData.lname = Utils.getVal("LNAME", data, personDataIndex);
                        careData.sex = Utils.getVal("SEX", data, personDataIndex);
                        careData.birthdate = Utils.getVal("BIRTH", data, personDataIndex);
                        careData.m_status = Utils.getVal("MSTATUS", data, personDataIndex);
                        careData.occupation_old = Utils.getVal("OCCUPATION_OLD", data, personDataIndex);
                        careData.occupation_new = Utils.getVal("OCCUPATION_NEW", data, personDataIndex);
                        careData.religion = Utils.getVal("RELIGION", data, personDataIndex);
                    });
                }
            }

        }

        private void joinDiganosis_OPD()
        {

            HealthCareData healthCareData = null;
            addtextln("Read OPD" );
            opdDataIndex = Utils.setupDataDic(opdList[0]);
            string diagType = "";
            string icd10 = "";
            for (int index = 1; index < opdList.Count; index++)
            {
                String line = opdList[index];
                string[] data = line.Split(',');
                String seq = Utils.getVal("SEQ", data, opdDataIndex);

                if (seq_healthCareDataMap.ContainsKey(seq))
                {
                    healthCareData = seq_healthCareDataMap[seq];

                    diagType = Utils.getVal("DIAGTYPE", data, opdDataIndex);
                    icd10 = Utils.getVal("DIAGCODE", data, opdDataIndex);
                    healthCareData.setICD10(diagType, icd10);

                }
            }
        }

        private void joinDiganosis_IPD()
        {
            HealthCareData healthCareData = null;

            addtextln("Read IPD" );
            ipdDataIndex = Utils.setupDataDic(ipdList[0]);
            String diagType = "";
            String icd10 = "";
            String date;
            for (int index = 1; index < ipdList.Count; index++)
            {
                String line = ipdList[index];
                string[] data = line.Split(',');

                String pid = Utils.getVal("PID", data, ipdDataIndex);
                String an = Utils.getVal("AN", data, ipdDataIndex);


                diagType = Utils.getVal("DIAGTYPE", data, ipdDataIndex);
                icd10 = Utils.getVal("DIAGCODE", data, ipdDataIndex);
                date = Utils.getVal("DATETIME_ADMIT", data, ipdDataIndex);


                if (an_healthCareDataMap.ContainsKey(an))
                {
                    List<HealthCareData> careDatas = an_healthCareDataMap[an];

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
                else if (pid_healthCareDataMap.ContainsKey(pid))
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
        }


        private void joinAccident()
        {
            //PID	SEQ	DATETIME_SERV	DATETIME_AE	AETYPE	AEPLACE	TYPEIN_AE	TRAFFIC	VEHICLE	ALCOHOL	NACROTIC_DRUG	
            //BELT	HELMET	AIRWAY	STOPBLEED	SPLINT	FLUID	URGENCY	COMA_EYE	COMA_SPEAK	COMA_MOVEMENT

            HealthCareData healthCareData = null;
            addtextln("Read Accident" );
            accidentDataIndex = Utils.setupDataDic(accidentList[0]);
            String seq = "";
            String pid = "";
            for (int index = 1; index < accidentList.Count; index++)
            {
                String line = accidentList[index];
                string[] data = line.Split(',');
                 seq = Utils.getVal("SEQ", data, accidentDataIndex);

                if (seq_healthCareDataMap.ContainsKey(seq))
                {
                    healthCareData = seq_healthCareDataMap[seq];

                    pushAccidentData(healthCareData, data);

                }

                 pid = Utils.getVal("PID", data, accidentDataIndex);

                if (pid_healthCareDataMap.ContainsKey(pid))
                {

                    List<HealthCareData> careDatas = pid_healthCareDataMap[pid];

                    careDatas.ForEach(delegate (HealthCareData careData)
                    {
                        pushAccidentData(careData, data);

                    });
                }
            }


        }

        private void pushAccidentData(HealthCareData healthCareData, string[] data)
        {
            healthCareData.aetype = Utils.getVal("AETYPE", data, accidentDataIndex);
            healthCareData.aeplace = Utils.getVal("AEPLACE", data, accidentDataIndex);
            healthCareData.typein_ae = Utils.getVal("TYPEIN_AE", data, accidentDataIndex);
            healthCareData.traffic = Utils.getVal("TRAFFIC", data, accidentDataIndex);
            healthCareData.vehicle = Utils.getVal("VEHICLE", data, accidentDataIndex);
            healthCareData.alcohol = Utils.getVal("ALCOHOL", data, accidentDataIndex);
            healthCareData.nacrotic_drug = Utils.getVal("NACROTIC_DRUG", data, accidentDataIndex);
            healthCareData.belt = Utils.getVal("BELT", data, accidentDataIndex);
            healthCareData.helmet = Utils.getVal("HELMET", data, accidentDataIndex);
            healthCareData.airway = Utils.getVal("AIRWAY", data, accidentDataIndex);
            healthCareData.stopbleed = Utils.getVal("STOPBLEED", data, accidentDataIndex);
            healthCareData.splint = Utils.getVal("SPLINT", data, accidentDataIndex);
            healthCareData.fluid = Utils.getVal("FLUID", data, accidentDataIndex);
            healthCareData.urgency = Utils.getVal("URGENCY", data, accidentDataIndex);
            healthCareData.coma_eye = Utils.getVal("COMA_EYE", data, accidentDataIndex);
            healthCareData.coma_speak = Utils.getVal("COMA_SPEAK", data, accidentDataIndex);
            healthCareData.coma_movement = Utils.getVal("COMA_MOVEMENT", data, accidentDataIndex);
        }

        private void joinDeath()
        {
            //HOSPCODE	PID	HOSPDEATH	AN	SEQ	DDEATH	CDEATH_A	CDEATH_B	CDEATH_C	CDEATH_D	ODISEASE	CDEATH	PREGDEATH	PDEATH

            if (deathList.Count() == 0) return;

            HealthCareData healthCareData = null;
            addtextln("Read Death");
            deathDataIndex = Utils.setupDataDic(deathList[0]);
            String seq = "";
            String pid = "";
            String an = "";

            for (int index = 1; index < deathList.Count; index++)
            {
                String line = deathList[index];
                string[] data = line.Split(',');
                seq = Utils.getVal("SEQ", data, deathDataIndex);

                if (seq_healthCareDataMap.ContainsKey(seq))
                {
                    healthCareData = seq_healthCareDataMap[seq];

                    pushDeathData(healthCareData, data);

                }

                pid = Utils.getVal("PID", data, deathDataIndex);

                if (pid_healthCareDataMap.ContainsKey(pid))
                {

                    List<HealthCareData> careDatas = pid_healthCareDataMap[pid];

                    careDatas.ForEach(delegate (HealthCareData careData)
                    {
                        pushDeathData(careData, data);

                    });
                }

                an = Utils.getVal("AN", data, deathDataIndex);

                if (an_healthCareDataMap.ContainsKey(an))
                {
                    List<HealthCareData> careDatas = an_healthCareDataMap[an];

                    careDatas.ForEach(delegate (HealthCareData careData)
                    {
                        pushDeathData(careData, data);

                    });
                }
            }
        }

        private void pushDeathData(HealthCareData healthCareData, string[] data)
        {

            //HOSPCODE	PID	HOSPDEATH	AN	SEQ	DDEATH	CDEATH_A	CDEATH_B	CDEATH_C	CDEATH_D	ODISEASE	CDEATH	PREGDEATH	PDEATH
            healthCareData.hospdeath = Utils.getVal("HOSPDEATH", data, deathDataIndex);
            healthCareData.ddeath = Utils.getVal("DDEATH", data, deathDataIndex);
            healthCareData.cdeath_a = Utils.getVal("CDEATH_A", data, deathDataIndex);
            healthCareData.cdeath_b = Utils.getVal("CDEATH_B", data, deathDataIndex);
            healthCareData.cdeath_c = Utils.getVal("CDEATH_C", data, deathDataIndex);
            healthCareData.cdeath_d = Utils.getVal("CDEATH_D", data, deathDataIndex);
            healthCareData.odisease = Utils.getVal("ODISEASE", data, deathDataIndex);
            healthCareData.cdeath = Utils.getVal("CDEATH", data, deathDataIndex);
            healthCareData.pregdeath = Utils.getVal("PREGDEATH", data, deathDataIndex);
            healthCareData.pdeath = Utils.getVal("PDEATH", data, deathDataIndex);
        }

        private void calcualateData()
        {

            HealthCareData healthCareData = null;
            String typeout = "";
            String discharge_status = "";

            foreach (HealthCareData item in healthCareDataList)
            {
                healthCareData = item;

                String date_serv = healthCareData.date_serv;
                String birth_date = healthCareData.birthdate;

     

                try
                {
                    int year_serv = int.Parse(date_serv.Substring(0, 4));
                    int year_birth = int.Parse(birth_date.Substring(0, 4));

                    int age = year_serv - year_birth;

                    healthCareData.age_at_service = age;

                }
                catch (Exception e)
                {
                    // Console.WriteLine(date_serv + "Serve " + birth_date + "Birth " + e.ToString());
                }

                typeout = healthCareData.typeout;
                discharge_status = healthCareData.discharge_status;
                int typeout_int = 0;
                int discharge_int = 0;
                string CDEATH = healthCareData.cdeath;
                try
                {
                    if (typeout.Length > 0)
                    {
                        typeout_int = int.Parse(typeout);
                    }

                    if (discharge_status.Length > 0)
                    {
                        discharge_int = int.Parse(discharge_status);
                    }


                }
                catch (Exception e)
                {
                   // Console.WriteLine(e.ToString() + "typeout " + typeout + " discharge_status " + discharge_status);
                }

                if ((typeout_int >= 4 && typeout_int <= 6) || (discharge_int == 8 || discharge_int == 9) || CDEATH != null)
                {
                    healthCareData.deathstatus = "1";

                    if (healthCareData.icd10_principle_dx.Contains("V") || healthCareData.icd10_external_cause.Contains("V"))
                    {
                        joinDeathList.Add(healthCareData);
                    }
                }
                else
                {
                    healthCareData.deathstatus = "0";
                }

            }
            addtextln("Death Count from Health Data: " + joinDeathList.Count());


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

            addtextln("Export Link Data Completed, ROW :" + seq_healthCareDataMap.Count);
     
        }


        public void addtextln(String text)
        {
            statusTextBox.AppendText(Environment.NewLine);
            statusTextBox.AppendText(text);
        }
        public void addtext(String text)
        {
            statusTextBox.AppendText(text);
        }
    }
}
