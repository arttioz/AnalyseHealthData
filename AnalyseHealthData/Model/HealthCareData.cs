using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyseHealthData.Model
{
    class HealthCareData
    {

        // Hospcode
        public String hospcode = "";

        //Service
        public String seq= "";
        public String hn= ""; // เลขทะเบียนการมารับบริการ
       
        public String date_serv= "";
        public String time_serv= "";
        public String location= ""; //ที่ตั้งของที่อยู่ผู้รับบริการ	1 = ในเขตรับผิดชอบ, 2 = นอกเขตรับผิดชอบ

        public String type_in= ""; // ประเภทการมารับบริการ	1 = มารับบริการเอง, 2 = มารับบริการตามนัดหมาย, 3 = ได้รับการส่งต่อจากสถานพยาบาลอื่น, 4 = ได้รับการส่งตัวจากบริการ EMS

        public String refer_in_hosp= ""; //สถานบริการที่ส่งผู้ป่วยมา	 รหัสสถานพยาบาลที่ส่งผู้ป่วยมารักษาต่อ
        public String cause_in= ""; //สาเหตุการส่งผู้ป่วยมารับบริการ	1 = เพื่อการวินิจฉัยและรักษา, 2 = เพื่อการวินิจฉัย, 3 = เพื่อการรักษาและพื้นฟูต่อเนื่อง, 4 = เพื่อการดูแลต่อใกล้บ้าน, 5 = ตามความต้องการผู้ป่วย

        public String serve_place= ""; // สถานที่รับบริการ	1 = ในสถานบริการ , 2 = นอกสถานบริการ

        public String typeout= ""; // สถานะผู้มารับบริการเมื่อเสร็จสิ้นบริการ 
                               // 1 = จําหน่ายกลับบ้าน, 2 = รับไว้รักษาต่อในแผนกผู้ป่วยใน, 3 = ส่งต่อไปยังสถานพยาบาลอื่น, 
                               // 4 = เสียชีวิต, 5 = เสียชีวิตก่อนมาถึง สถานพยาบาล, 6 = เสียชีวิตระหว่างส่งต่อไปยังสถานพยาบาลอื่น, 
                               // 7= ปฏิเสธการรักษา, 8 = หนีกลับ


        public double cost; // ราคาทุนของบริการ
        public double price; // ค่าบริการทั้งหมด (ราคาขาย)

        //Person
        public String cid= ""; // รหัสประชาชน
        public String pid= ""; // รหัสทะเบียนของบุคคลที่มาขึ้นทะเบียนในสถานบริการ

        public String prename= "";
        public String name= "";
        public String lname= "";
        public String sex= ""; // 1 = Male, 2 = Female
        public String birthdate= ""; // DD/MM/YYYY
        public String m_status= ""; // 1 = โสด, 2 = คู่, 3 = ม่าย, 4 = หย่า, 5 = แยก, 6 = สมณะ,  9=ไม่ทราบ
        public String occupation_old= ""; // อาชีพ(รหัสเก่า) รหัสมาตรฐานสำนักนโยบายและยุทธศาสตร์
        public String occupation_new= ""; // อาชีพ(รหัสใหม่) รหัสมาตรฐานสำนักนโยบายและยุทธศาสตร์
        public String religion= "";
        public int age_at_service;


        //Admit
        public String date_admit = "";
        public String date_disch = "";
        public String an;


        public String discharge_status= ""; // (DISCHSTATUS)
                                        // 1 =	complete recovery
                                        // 2 =	improved
                                        // 3 =	not improved
                                        // 4 =	normal delivery
                                        // 5 =	un-delivery
                                        // 6 =	normal child discharged with mother
                                        // 7 =  normal child discharged separately
                                        // 8 =	dead stillbirth
                                        // 9 =	dead


        //OPD-IPD
        //DIAGTYPE

        //  1 = PRINCIPLE DX (การวินิจฉัยโรคหลัก) 
        //  2 = CO-MORBIDITY(การวินิจฉัยโรคร่วม)
        //  3 = COMPLICATION(การวินิจฉัยโรคแทรก)
        //  4 = OTHER(อื่น ๆ)
        //  5 = EXTERNAL CAUSE(สาเหตุภายนอก)
        //  6 = Additional Code(รหัสเสริม)
        //  7 = Morphology Code(รหัสเกี่ยวกับเนื้องอก)


        public String icd10_principle_dx= ""; // การวินิจฉัยโรคหลัก
        public String icd10_external_cause= ""; // สาเหตุผายนอก

        public String icd10_co_morbidity_1= ""; // การวินิจฉัยโรคร่วม 1
        public String icd10_co_morbidity_2= ""; // การวินิจฉัยโรคร่วม 2
        public String icd10_co_morbidity_3= ""; // การวินิจฉัยโรคร่วม 3
        public String icd10_co_morbidity_4= ""; // การวินิจฉัยโรคร่วม 4
        public String icd10_co_morbidity_5= ""; // การวินิจฉัยโรคร่วม 5

        public String icd10_complication_1= ""; // การวินิจฉัยโรคแทรก 1
        public String icd10_complication_2= ""; // การวินิจฉัยโรคแทรก 2
        public String icd10_complication_3= ""; // การวินิจฉัยโรคแทรก 3
        public String icd10_complication_4= ""; // การวินิจฉัยโรคแทรก 4
        public String icd10_complication_5= ""; // การวินิจฉัยโรคแทรก 5

        public String icd10_other_1= ""; // อื่นๆ 1
        public String icd10_other_2= ""; // อื่นๆ 1
        public String icd10_other_3= ""; // อื่นๆ 1
        public String icd10_other_4= ""; // อื่นๆ 1
        public String icd10_other_5= ""; // อื่นๆ 1

        public String deathstatus; // 0 = เป็น 1 = เสียชีวิต

        public Boolean checkSameDataByDate(String dateCheck)
        {
            // date = 20160901084300;
            // year = 2016
            // month = 09
            // date = 01;

            int year_check = int.Parse(dateCheck.Substring(0, 4) );
            int month_check = int.Parse(dateCheck.Substring(4, 2));
            int date_check = int.Parse( dateCheck.Substring(6, 2));

            // date_serv = 20160905;
            // year = 2016
            // month = 09;
            // date = 05

            int year = int.Parse(date_serv.Substring(0, 4));
            int month = int.Parse(date_serv.Substring(4, 2));
            int date = int.Parse(date_serv.Substring(6, 2));

            DateTime date_c = new DateTime(year_check, month_check, date_check, 00, 00, 00);
            DateTime date_s = new DateTime(year, month, date, 00, 00, 00);

            var diff = date_c.Subtract(date_s);

            // 10 days
            if(diff.Hours < 240)
            {
                return true;
            }


            return false;
        }

        public static String toCVSHeader()
        {
            String cvs = "HOSPCODE,PID,SEQ,HN,DATE_SERV,TIME_SERV,LOCATION,TYPEIN,REFERINHOSP,CAUSEIN,TYPEOUT";
            cvs += ",CID,PRENAME,NAME,LNAME,SEX,BIRTH,MSTATUS,OCCUPATION_OLD,OCCUPATION_NEW,RELIGION";
            cvs += ",DISCHSTATUS,DEATH,ICD10_PRINCIPLE_DX,ICD10_EXTERNAL_CAUSE";
            cvs += ",ICD10_CO_MORBIDITY_1,ICD10_CO_MORBIDITY_2,ICD10_CO_MORBIDITY_3,ICD10_CO_MORBIDITY_4,ICD10_CO_MORBIDITY_5";
            cvs += ",ICD10_COMPLICATION_1,ICD10_COMPLICATION_2,ICD10_COMPLICATION_3,ICD10_COMPLICATION_4,ICD10_COMPLICATION_5";
            cvs += ",ICD10_OTHER_1,ICD10_OTHER_2,ICD10_OTHER_3,ICD10_OTHER_4,ICD10_OTHER_5";

            return cvs;
        }

        public String toCVS()
        {
            String cvs  = "";
            cvs += hospcode + "," + pid + "," + seq + "," + hn + "," + date_serv + "," + time_serv + "," + location + "," + type_in + "," + refer_in_hosp + "," + cause_in + "," + typeout;
            cvs += "," + cid + "," + prename + "," + name + "," + lname + "," + sex + "," + birthdate + "," + m_status + "," + occupation_old + "," + occupation_new + "," + religion;
            cvs += "," + discharge_status + "," + deathstatus + "," + icd10_principle_dx + "," + icd10_external_cause;
            cvs += "," + icd10_co_morbidity_1 + "," + icd10_co_morbidity_2 + "," + icd10_co_morbidity_3 + "," + icd10_co_morbidity_4 + "," + icd10_co_morbidity_5;
            cvs += "," + icd10_complication_1 + "," + icd10_complication_2 + "," + icd10_complication_3 + "," + icd10_complication_4 + "," + icd10_complication_5;
            cvs += "," + icd10_other_1 + "," + icd10_other_2 + "," + icd10_other_3 + "," + icd10_other_4 + "," + icd10_other_5;

            return cvs;
        }

        public void setICD10(String diagTypeTxt,String icd10)
        {
            try
            {
                int diagType = int.Parse(diagTypeTxt);
                if (diagType == 1)
                {
                    icd10_principle_dx = icd10;
                }
                else if (diagType == 2)
                {
                    setICD10_CO_morbidity(icd10);
                }
                else if (diagType == 3)
                {
                    setICD10_Complication(icd10);
                }
                else if (diagType == 4)
                {
                    setICD10_Other(icd10);
                }
                else if (diagType == 5)
                {
                    icd10_external_cause = icd10;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void setICD10_CO_morbidity(String icd10)
        {
            icd10 = icd10.Trim();

            if (icd10_co_morbidity_1.Length == 0)
            {
                icd10_co_morbidity_1 = icd10;
            }
            else if (icd10_co_morbidity_2.Length == 0)
            {
                icd10_co_morbidity_2 = icd10;
            }
            else if (icd10_co_morbidity_3.Length == 0)
            {
                icd10_co_morbidity_3 = icd10;
            }
            else if (icd10_co_morbidity_4.Length == 0)
            {
                icd10_co_morbidity_4 = icd10;
            }
            else if (icd10_co_morbidity_5.Length == 0)
            {
                icd10_co_morbidity_5 = icd10;
            }

        }

        public void setICD10_Complication(String icd10)
        {
            icd10 = icd10.Trim();

            if (icd10_complication_1.Length == 0)
            {
                icd10_complication_1 = icd10;
            }
            else if (icd10_complication_2.Length == 0)
            {
                icd10_complication_2 = icd10;
            }
            else if (icd10_complication_3.Length == 0)
            {
                icd10_complication_3 = icd10;
            }
            else if (icd10_complication_4.Length == 0)
            {
                icd10_complication_4 = icd10;
            }
            else if (icd10_complication_5.Length == 0)
            {
                icd10_complication_5 = icd10;
            }

        }


        public void setICD10_Other(String icd10)
        {
            icd10 = icd10.Trim();

            if (icd10_other_1.Length == 0)
            {
                icd10_other_1 = icd10;
            }else if ( icd10_other_2.Length == 0)
            {
                icd10_other_2 = icd10;
            }
            else if (icd10_other_3.Length == 0)
            {
                icd10_other_3 = icd10;
            }
            else if (icd10_other_4.Length == 0)
            {
                icd10_other_4 = icd10;
            }
            else if (icd10_other_5.Length == 0)
            {
                icd10_other_5 = icd10;
            }
        }

    }
}
