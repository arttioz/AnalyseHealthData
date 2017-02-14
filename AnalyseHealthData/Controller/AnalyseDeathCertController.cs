using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnalyseHealthData.Model;

namespace AnalyseHealthData.Controller
{
    class AnalyseDeathCertController
    {

        System.Windows.Forms.RichTextBox statusTextBox;
        private String filePath;

        String deathCertHeader = "seq,area,province,hospcode,hospname,systemcode,hn,prename,name,surname,cid,gender,birthdate,age,nonthai,nation,race,deathdate,deathtime,checkdate,checktime,deathcause,deathcheck";
        private Dictionary<string, int> deeathCertDataIndex = new Dictionary<string, int>();
        private String exportFolder;

        private List<String> deathList = new List<String>();
        private List<DeathCertData> deathcertlist = new List<DeathCertData>();
        
        private Dictionary<string, int> deathcertIndex = new Dictionary<string, int>();

        public List<DeathCertData> deathTrafficlist = new List<DeathCertData>();

        public AnalyseDeathCertController(String filePath, System.Windows.Forms.RichTextBox statusTextBox)
        {

            this.statusTextBox = statusTextBox;
            setFile(filePath);
        }

        public void setFile(String filePath)
        {
            this.filePath = filePath;
            addtextLn("Death Cert filePath: " + filePath);    
        }

        public void analyseFile(String exportFolder, string filePath)
        {
            deathList.Clear();
            deathcertlist.Clear();
            deathTrafficlist.Clear();

            this.exportFolder = exportFolder;
            FileInfo file = new FileInfo(filePath);

            readFile(file);
            addtextLn("Total Death from Death Cert: " + deathList.Count());
            mappingData();
            filterDeathByTraffic();
            exportlinkData();



        }


        public void exportlinkData()
        {
            String filename = "deathcert_traffic.csv";
            String filefullName = Path.Combine(this.exportFolder, filename);


            FileStream fileStream = new FileStream(filefullName, FileMode.Create);
            fileStream.Close();

            using (StreamWriter writer = new StreamWriter(filefullName))
            {
                writer.WriteLine(deathCertHeader);
 

                foreach (DeathCertData item in deathTrafficlist)
                {
                   writer.WriteLine(item.toCSV());
                }

            }

            addtextLn("Export deathcert_traffic.csvCompleted, ROW :" + deathTrafficlist.Count);

        }


        private void readFile(FileInfo file)
        {
            string line = null;
            int line_number = 0;

            System.Text.Encoding encode = Utils.GetEncoding(file.FullName);

            using (StreamReader reader = new StreamReader(file.FullName, encode))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line_number >= 5 && !string.IsNullOrWhiteSpace(line))
                    {
                       deathList.Add(line);
                    }
                    line_number++;
                }
            }
        }

        private void mappingData()
        {
            deathcertIndex = Utils.setupDataDic(deathCertHeader);

            for (int index = 0; index < deathList.Count; index++)
            {
                DeathCertData deathCertData = new DeathCertData();
                String line = deathList[index];
                string[] data = line.Split(',');
                deathCertData = putDeathCertData(deathCertData, data);
                deathcertlist.Add(deathCertData);
            }

        }

        private void filterDeathByTraffic()
        {
            DeathCertData deathCertData = null;
            for (int index = 0; index < deathcertlist.Count; index++)
            {
                 deathCertData = deathcertlist[index];
                if (deathCertData.deathcheck.Equals("ตายโดยอุบัติเหตุจราจร"))
                {
                    deathTrafficlist.Add(deathCertData);
                }
            }
            addtextLn("Total DeathCert from Traffic Injury: " + deathTrafficlist.Count());
        }

        private DeathCertData putDeathCertData(DeathCertData deathCertData, string[] data)
        {
            deathCertData.seq = Utils.getVal("seq", data, deathcertIndex);
            deathCertData.area = Utils.getVal("area", data, deathcertIndex);
            deathCertData.province = Utils.getVal("province", data, deathcertIndex);
            deathCertData.hospcode = Utils.getVal("hospcode", data, deathcertIndex);
            deathCertData.hospname = Utils.getVal("hospname", data, deathcertIndex);
            deathCertData.systemcode = Utils.getVal("systemcode", data, deathcertIndex);
            deathCertData.hn = Utils.getVal("hn", data, deathcertIndex);
            deathCertData.prename = Utils.getVal("prename", data, deathcertIndex);
            deathCertData.name = Utils.getVal("name", data, deathcertIndex);
            deathCertData.surname = Utils.getVal("surname", data, deathcertIndex);
            deathCertData.cid = Utils.getVal("cid", data, deathcertIndex);
            deathCertData.gender = Utils.getVal("gender", data, deathcertIndex);
            deathCertData.birthdate = Utils.getVal("birthdate", data, deathcertIndex);
            deathCertData.age = Utils.getVal("age", data, deathcertIndex).Replace("ปี","").Trim();
            deathCertData.nonthai = Utils.getVal("nonthai", data, deathcertIndex);
            deathCertData.nation = Utils.getVal("nation", data, deathcertIndex);
            deathCertData.race = Utils.getVal("race", data, deathcertIndex);
            deathCertData.deathdate = Utils.getVal("deathdate", data, deathcertIndex);
            deathCertData.deathtime = Utils.getVal("deathtime", data, deathcertIndex);
            deathCertData.checkdate = Utils.getVal("checkdate", data, deathcertIndex);
            deathCertData.checktime = Utils.getVal("checktime", data, deathcertIndex);
            deathCertData.deathcause = Utils.getVal("deathcause", data, deathcertIndex);
            deathCertData.deathcheck = Utils.getVal("deathcheck", data, deathcertIndex);
            return deathCertData;
        }

        private void addtextLn(String text)
        {
            statusTextBox.AppendText(Environment.NewLine);
            statusTextBox.AppendText(text);
        }

        private void addtext(String text)
        {
            statusTextBox.AppendText(text);
        }

       

    }
}
