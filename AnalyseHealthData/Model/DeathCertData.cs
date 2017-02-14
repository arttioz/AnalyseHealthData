using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyseHealthData.Model
{
    class DeathCertData
    {

        public static String deathCertHeader = "seq,area,province,hospcode,hospname,systemcode,hn,prename,name,surname,cid,gender,birthdate,age,nonthai,nation,race,deathdate,deathtime,checkdate,checktime,deathcause,deathcheck";


        public String seq, area, province, hospcode, hospname, systemcode, hn, prename, name, surname, cid, gender, birthdate, age, nonthai, nation, race, deathdate, deathtime, checkdate, checktime, deathcause, deathcheck;


        public String toCSV()
        {

            return seq+ "," +area+ "," + province+ "," + hospcode+ "," + hospname+ "," + systemcode+ "," + hn+ "," + prename+ "," + name+ "," + surname+ "," + cid+ "," + gender+ "," + birthdate+ "," + age+ "," + nonthai+ "," + nation+ "," + race+ "," + deathdate+ "," + deathtime+ "," + checkdate+ "," + checktime+ "," + deathcause+ "," + deathcheck;
        }

    }
}
