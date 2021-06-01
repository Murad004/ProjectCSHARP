using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSHARP
{
    class CV
    {
        static int Id = 0;
        public CV()
        {
            ID = Id++;
        }

        public int ID { get; set; }
        public string FromName { get; set; }
        public string Speciality { get; set; }
        public string School { get; set; }
        public int Point { get; set; }
        public string Skills { get; set; }
        public string Companies { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Language { get; set; }
        public string HonorsDiploma { get; set; }
        public string GitLink { get; set; }
        public string Linkedin { get; set; }



        public override string ToString()
        {
            return $"ID : {ID}\nSpeciality : {Speciality}\nFrom username : {FromName}\nSchool : {School}\nPoint : {Point}\nSkills : {Skills}\nCompanies : {Companies}\nStart Date : {StartDate}\nEnd Date : {EndDate}\nLanguage : {Language}\nHonors Diplom : {HonorsDiploma}\nGit Link : {GitLink}\nLinkedin Account : {Linkedin}";
        }

    }
}
