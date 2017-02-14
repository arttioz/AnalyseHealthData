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

        // Accident
        public String aetype; // รหัสสาเหตุ 19 สาเหตุ ตามมาตรฐานอ้างอิงตามสำนักระบาดวิทยา

        // aeplace
        //01 = ที่บ้าน หรืออาคารที่พัก, 
        //02 = ในสถานที่ทำงาน ยกเว้นโรงงานหรือก่อสร้าง, 
        //03= ในโรงงานอุตสาหกรรม หรือบริเวณก่อสร้าง,0
        //04 = ภายในอาคารอื่นๆ, 
        //05= ในสถานที่สาธารณะ, 
        //06 = ในชุมชน และไร่นา, 0
        //7 = บนถนนสายหลัก, 
        //08 = บนถนนสายรอง, 
        //09 = ในแม่น้ำ ลำคลอง หนองน้ำ, 
        //10= ในทะเล, 
        //11 = ในป่า/ภูเขา, 
        //98 = อื่นๆ, 99= ไม่ทราบ

        public String aeplace;

        //typein_ae
        //1 = มารับบริการเอง, 
        //2 = ได้รับการส่งตัวโดย First responder , 
        //3 = ได้รับการส่งตัวโดย BLS, 
        //4 = ได้รับการส่งตัวโดย ILS ,
        //5 = ได้รับการส่งตัวโดย ALS, 
        //6 = ได้รับการส่งต่อจากสถานพยาบาลอื่น, 
        //7 = อื่น ๆ ,9=ไม่ทราบ

        public String typein_ae;

        //traffic
        //1= ผู้ขับขี่, 2= ผู้โดยสาร, 3= คนเดินเท้า, 8= อื่นๆ, 9= ไม่ทราบ
        public String traffic;


        //vehicle
        //01= จักรยานและสามล้อถึบ,
        //02= จักรยานยนต์, 
        //03= สามล้อเครื่อง, 
        //04= รถยนต์นั่ง/แท็กซี่, 
        //05= รถปิกอัพ,  06= รถตู้, 
        //07= รถโดยสารสองแถว, 
        //08= รถโดยสารใหญ่ (รถบัส รถเมล์), 
        //09= รถบรรทุก/รถพ่วง, 10= เรือโดยสาร 
        //11= เรืออื่นๆ, 12= อากาศยาน, 
        //98= อื่นๆ 99= ไม่ทราบ 

        public String vehicle;
        public String alcohol; // 1= ดื่ม, 2= ไม่ดื่ม, 9= ไม่ทราบ
        public String nacrotic_drug; // 1= ใช้, 2= ไม่ใช้, 9= ไม่ทราบ

        public String belt; // 1= คาด, 2= ไม่คาด, 9= ไม่ทราบ

        public String helmet; // 1= สวม, 2= ไม่สวม, 9= ไม่ทราบ

        public String airway; // 1= มีการดูแลการหายใจก่อนมาถึงเหมาะสม, 2= ไม่มีการดูแลการหายใจก่อนมาถึง ,3= ไม่จำเป็น, 4 = มีการดูแลการหายใจก่อนมาถึงไม่เหมาะสม

        public String stopbleed; // "1= มีการห้ามเลือดก่อนมาถึงเหมาะสม, 2= ไม่มีการห้ามเลือดก่อนมาถึง , 3= ไม่จำเป็น, 4 = มีการห้ามเลือดก่อนมาถึงไม่เหมาะสม"

        public String splint; // 1= มีการใส่ splint/slab ก่อนมาถึงเหมาะสม, 2= ไม่มีการใส่ splint/slabก่อนมาถึง , 3= ไม่จำเป็น, 4= มีการใส่ splint/slab ก่อนมาถึงไม่เหมาะสม

        public String fluid; // 1= มีการให้ IV fluid ก่อนมาถึงเหมาะสม, 2= ไม่มีการให้ IV fluid ก่อนมาถึง , 3= ไม่จำเป็น, 4= มีการให้ IV fluid ก่อนมาถึงเหมาะสม

        public String urgency; // ระดับความเร่งด่วน 5 ระดับ (1= life threatening, 2= emergency, 3= urgent, 4= acute, 5= non acute, 6 = ไม่แน่ใจ) 

        public String coma_eye; // ระดับความรู้สึกตัววัดจากการตอบสนองของตา

        public String coma_speak; // ระดับความรู้สึกตัววัดจากการตอบสนองของการพูด

        public String coma_movement; // ระดับความรู้สึกตัววัดจากการตอบสนองของการเคลื่อนไหว


        // Death 
        //HOSPCODE	PID	HOSPDEATH	AN	SEQ	DDEATH	CDEATH_A	CDEATH_B	CDEATH_C	CDEATH_D	ODISEASE	CDEATH	PREGDEATH	PDEATH
        //hospdeath	an	seq	ddeath	cdeath_a	cdeath_b	cdeath_c	cdeath_d	odisease	cdeath	pregdeath	pdeath

        public String hospdeath;
        public String ddeath;
        public String cdeath_a; // รหัสโรคที่เป็นสาเหตุการตาย_a ตามหนังสือรับรองการตาย รหัส ICD - 10 - TM 6 หลัก(ไม่รวมจุด)
        public String cdeath_b;
        public String cdeath_c;
        public String cdeath_d;
        public String odisease; // รหัสโรคหรือภาวะอื่นที่เป็นเหตุหนุน

        //cdeath สาเหตุการตาย	"ตามหนังสือรับรองการตาย รหัส ICD - 10 - TM 6 หลัก(ไม่รวมจุด)
        //หมายเหตุ : ไม่เป็นค่าว่างและอ้างอิงตามรหัส ICD10TM ยกเว้นรหัส S, T, Z เนื่องจากรหัส S, T เป็นการให้รหัสการบาดเจ็บและการเป็นพิษ ส่วนรหัส Z เป็นรหัสการให้บริการด้านสุขภาพ"
        public String cdeath;

        //pregdeath การตั้งครรภ์และการคลอด	"1 = เสียชีวิตระหว่างตั้งครรภ์, 2= เสียชีวิตระหว่างคลอดหรือหลังคลอดภายใน 42 วัน, 3 = ไม่ตั้งครรภ์ , 4 = ผู้ชาย ,9 = ไม่ทราบ (ตัด 3 4 9 ออก)
        //หมายเหตุ : เฉพาะหญิงตั้งครรภ์"
        public String pregdeath;

        //pdeath สถานที่ตาย	1=ในสถานพยาบาล, 2=นอกสถานพยาบาล

        public String pdeath;

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

            // 30 days
            if(diff.Hours < 720)
            {
                return true;
            }


            return false;
        }

        public static String toCVSHeader()
        {
            String cvs = "HOSPCODE,PID,SEQ,HN,DATE_SERV,TIME_SERV,LOCATION,TYPEIN,REFERINHOSP,CAUSEIN,TYPEOUT";
            cvs += ",CID,PRENAME,NAME,LNAME,SEX,BIRTH,AGE,MSTATUS,OCCUPATION_OLD,OCCUPATION_NEW,RELIGION";
            cvs += ",AETYPE,AEPLACE,TYPEIN_AE,TRAFFIC,VEHICLE,ALCOHOL,NACROTIC_DRUG,BELT,HELMET,AIRWAY,STOPBLEED,SPLINT,FLUID,URGENCY,COMA_EYE,COMA_SPEAK,COMA_MOVEMENT";
            cvs += ",DISCHSTATUS,DEATH,ICD10_PRINCIPLE_DX,ICD10_EXTERNAL_CAUSE";
            cvs += ",ICD10_CO_MORBIDITY_1,ICD10_CO_MORBIDITY_2,ICD10_CO_MORBIDITY_3,ICD10_CO_MORBIDITY_4,ICD10_CO_MORBIDITY_5";
            cvs += ",ICD10_COMPLICATION_1,ICD10_COMPLICATION_2,ICD10_COMPLICATION_3,ICD10_COMPLICATION_4,ICD10_COMPLICATION_5";
            cvs += ",ICD10_OTHER_1,ICD10_OTHER_2,ICD10_OTHER_3,ICD10_OTHER_4,ICD10_OTHER_5";
            cvs += ",HOSPDEATH,DDEATH,CDEATH_A,CDEATH_B,CDEATH_C,CDEATH_D,ODISEASE,CDEATH,PREGDEATH,PDEATH";
            return cvs;
        }

        public String toCVS()
        {
            String cvs  = "";
            cvs += hospcode + "," + pid + "," + seq + "," + hn + "," + dateServe() + "," + time_serv + "," + location + "," + type_in + "," + refer_in_hosp + "," + cause_in + "," + typeout;
            cvs += "," + cid + "," + prename + "," + name + "," + lname + "," + sex + "," + birthdate + ","  + age_at_service+ "," + m_status + "," + occupation_old + "," + occupation_new + "," + religion;
            cvs += "," + aetype + "," + aeplace + "," + typein_ae + "," + traffic + "," + vehicle + "," + alcohol + "," + nacrotic_drug + "," + belt + "," + helmet + "," + airway + "," + stopbleed + "," + splint + "," + fluid + "," + urgency + "," + coma_eye + "," + coma_speak + "," + coma_movement;

            cvs += "," + discharge_status + "," + deathstatus + "," + icd10_principle_dx + "," + icd10_external_cause;
            cvs += "," + icd10_co_morbidity_1 + "," + icd10_co_morbidity_2 + "," + icd10_co_morbidity_3 + "," + icd10_co_morbidity_4 + "," + icd10_co_morbidity_5;
            cvs += "," + icd10_complication_1 + "," + icd10_complication_2 + "," + icd10_complication_3 + "," + icd10_complication_4 + "," + icd10_complication_5;
            cvs += "," + icd10_other_1 + "," + icd10_other_2 + "," + icd10_other_3 + "," + icd10_other_4 + "," + icd10_other_5;
            cvs += "," + hospdeath + "," + ddeath + "," + cdeath_a + "," + cdeath_b + "," + cdeath_c + "," + cdeath_d + "," + odisease + "," + cdeath + "," + pregdeath + "," + pdeath;


            return cvs;
        }

        public String dateServe()
        {
            String date = date_serv;
            if (date_serv.Length >= 8)
            {
                String year = date_serv.Substring(0, 4);
                String month = date_serv.Substring(4, 2);
                String day = date_serv.Substring(6, 2);


                date = day + "/" + month + "/" + year;
            }

            return date;

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
