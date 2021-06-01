using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSHARP
{
    class Vacancy
    {
        static int id = 0;
        public Vacancy()
        {
            ID = id++;
        }

        public int ID { get; set; }
        public string FromName { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string Skills { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }


        public override string ToString()
        {
            return $"ID : {ID}\nName : {Name}\nJob Description : {JobDescription}\nSkills : {Skills}\nLocation : {Location}\nSalary : {Salary}";
        }
    }
}
