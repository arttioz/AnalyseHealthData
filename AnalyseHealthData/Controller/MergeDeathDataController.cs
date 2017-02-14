using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnalyseHealthData.Model;

namespace AnalyseHealthData.Controller
{
    class MergeDeathDataController
    {
        System.Windows.Forms.RichTextBox statusTextBox;
        private Dictionary<String, DeathCertData> cid_deathCertData = new Dictionary<string, DeathCertData>();
        private Dictionary<String, DeathCertData> name_deathCertData = new Dictionary<string, DeathCertData>();
        private List<DeathCertData> deathFromDeathCertData;



        String exportFolder;

        public void mergeDeathData(List<HealthCareData> deathFromHealthData, List<DeathCertData> deathFromDeathCertData, String exportFolder, System.Windows.Forms.RichTextBox statusTextBox)
        {
            this.statusTextBox = statusTextBox;
            this.deathFromDeathCertData = deathFromDeathCertData;
            this.exportFolder = exportFolder;
            cid_deathCertData.Clear();
            foreach(DeathCertData data in deathFromDeathCertData)
            {
                String cid = data.cid.Replace("-", "");

                if (!cid_deathCertData.ContainsKey(cid)){
                    cid_deathCertData.Add(cid, data);
                }

                if (!name_deathCertData.ContainsKey(data.name + data.surname))
                {
                    name_deathCertData.Add(data.name + data.surname, data);
                }  
            }

            foreach (HealthCareData data in deathFromHealthData)
            {
                if (!cid_deathCertData.ContainsKey(data.cid) && !name_deathCertData.ContainsKey(data.name + data.lname))
                {
                    DeathCertData deathFromHealth = new DeathCertData();
                    deathFromHealth.seq = data.seq;
                    deathFromHealth.area = "-";
                    deathFromHealth.province = "-";
                    deathFromHealth.hospcode = data.hospcode;
                    deathFromHealth.hospname = "-";
                    deathFromHealth.systemcode = "-";
                    deathFromHealth.hn = data.pid;
                    deathFromHealth.prename = data.prename;
                    deathFromHealth.name =  data.name;
                    deathFromHealth.surname = data.lname;
                    deathFromHealth.cid = data.cid;
                    deathFromHealth.gender = data.sex;
                    deathFromHealth.birthdate = data.birthdate;
                    deathFromHealth.age = data.age_at_service + "";
                    deathFromHealth.nonthai = "-";
                    deathFromHealth.nation = "-";
                    deathFromHealth.race = "-";
                    deathFromHealth.deathdate = convertDateToDeathCert( data.date_serv );
                    deathFromHealth.deathtime = convertTimeToDeathCert( data.time_serv );
                    deathFromHealth.checkdate = "-";
                    deathFromHealth.checktime = "-";
                    deathFromHealth.deathcause = data.icd10_external_cause;
                    deathFromHealth.deathcheck = data.icd10_external_cause;

                    deathFromDeathCertData.Add(deathFromHealth);
                    addtextLn(data.name+ " " + data.lname);
                }
            }

            exportlinkData();
        }

       

        public void exportlinkData()
        {
            String filename = "deathMerge.csv";
            String filefullName = Path.Combine(this.exportFolder, filename);


            FileStream fileStream = new FileStream(filefullName, FileMode.Create);
            fileStream.Close();

            using (StreamWriter writer = new StreamWriter(filefullName))
            {
                writer.WriteLine(DeathCertData.deathCertHeader);


                foreach (DeathCertData item in deathFromDeathCertData)
                {
                    writer.WriteLine(item.toCSV());

                }

            }

            addtextLn("Export deathMerge.csv Completed, ROW :" + deathFromDeathCertData.Count);

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

        public static string convertDateToDeathCert(string datetext)
        {
            String date = datetext;
            if (datetext.Length == 8)
            {
                String year = datetext.Substring(0, 4);
                String month = datetext.Substring(4, 2);
                String day = datetext.Substring(6, 2);

                int yeari = int.Parse(year) + 543;

                datetext = day + "/" + month + "/" + yeari ;
            }
            return datetext;
        }

        public static string convertTimeToDeathCert(string time)
        {
            if (time.Length == 6)
            {
                String hr = time.Substring(0, 2);
                String mn = time.Substring(2, 2);

                time = hr + ":" + mn;
            }
            return time;
        }
    }
}
