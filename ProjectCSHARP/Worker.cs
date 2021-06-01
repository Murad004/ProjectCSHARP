using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSHARP
{
    class Worker:Base
    {
        public CV[] cVs { get; set; }
        public int CVCount { get; set; }
        public Notification[] notifications { get; set; }
        public int NotCount { get; set; }

        public Worker(string name, string surname, string city, string phonenumber, int age,string username,string password)
             : base(name, surname, city, phonenumber, age,username,password)
        {

        }

        public void ShowCV()
        {
            foreach (var cv in cVs)
            {
                Console.WriteLine(cv);
            }
        }

        public void AddNot(Notification newnot)
        {
            Notification[] temp = new Notification[++NotCount];
            if (notifications != null)
            {
                notifications.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = newnot;
            notifications = temp;
        }

        public void AddCV()
        {

            Console.Write("Inlcude Speciality : ");
            string speciality = Console.ReadLine();
            Console.Write("Include your username : ");
            string fromusername = Console.ReadLine();
            Console.Write("Include School : ");
            string school = Console.ReadLine();
            Console.Write("Include University Point : ");
            int.TryParse(Console.ReadLine(), out int point);
            Console.Write("Include Skills : ");
            string skills = Console.ReadLine();
            Console.Write("Inlcude Companies : ");
            string companies = Console.ReadLine();
            Console.Write("Include Start Date : ");
            DateTime startdatetime;
            DateTime.TryParse(Console.ReadLine(), out startdatetime);
            Console.Write("Include End Time : ");
            DateTime enddatetime;
            DateTime.TryParse(Console.ReadLine(), out enddatetime);
            Console.Write("Language : ");
            string language = Console.ReadLine();
            Console.Write("Honors Diploma : ");
            string hondiplom = Console.ReadLine();
            Console.Write("Git Link : ");
            string gitlink = Console.ReadLine();
            Console.Write("Linkedin : ");
            string linkedin = Console.ReadLine();
            Console.Clear();
            CV newcv = new CV { Speciality = speciality,FromName=fromusername, School = school, Point = point, Skills = skills, Companies = companies, StartDate = startdatetime, EndDate = enddatetime, Language = language,HonorsDiploma=hondiplom, GitLink = gitlink, Linkedin = linkedin };

            CV[]temp = new CV[++CVCount];
            if (cVs != null)
            {
                cVs.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = newcv;
            cVs = temp;
        }
        public void DeleteCV( int ID)
        {
            var array = cVs.Where(c => c.ID != ID).ToArray();
            cVs = array;
        }

        public void UpdateCV(int ID)
        {
            foreach (var cv in cVs)
            {
                if (ID == cv.ID)
                {
                    Console.WriteLine("Speciality (1)");
                    Console.WriteLine("School (2)");
                    Console.WriteLine("University Point (3)");
                    Console.WriteLine("Skills (4)");
                    Console.WriteLine("Companies (5)");
                    Console.WriteLine("Start Date (6)");
                    Console.WriteLine("End Date (7)");
                    Console.WriteLine("Language (8)");
                    Console.WriteLine("Honors Diploma (9)");
                    Console.WriteLine("GitLink (10)");
                    Console.WriteLine("Linkedin (11)");
                    Console.Write("You choose : ");
                    int.TryParse(Console.ReadLine(), out int choose);
                    if (choose == 1)
                    {
                        Console.Write("New Speciality : ");
                        string spec = Console.ReadLine();
                        cv.Speciality = spec;
                    }
                    else if (choose == 2)
                    {
                        Console.Write("New School : ");
                        string school = Console.ReadLine();
                        cv.School = school;
                    }
                    else if (choose == 3)
                    {
                        Console.Write("New Point : ");
                        int.TryParse(Console.ReadLine(), out int point);
                        cv.Point = point;
                    }
                    else if (choose == 4)
                    {
                        Console.Write("New Skills : ");
                        string skills = Console.ReadLine();
                        cv.Skills = skills;
                    }
                    else if (choose == 5)
                    {
                        Console.Write("New Companies : ");
                        string companie = Console.ReadLine();
                        cv.Companies = companie;
                    }
                    else if (choose == 6)
                    {
                        Console.Write("New Start Time : ");
                        DateTime starttime;
                        DateTime.TryParse(Console.ReadLine(), out starttime);
                        cv.StartDate = starttime;
                    }
                    else if (choose == 7)
                    {
                        Console.Write("New End Time : ");
                        DateTime EndTime;
                        DateTime.TryParse(Console.ReadLine(), out EndTime);
                        cv.EndDate = EndTime;
                    }
                    else if (choose == 8)
                    {
                        Console.Write("New Language : ");
                        string language = Console.ReadLine();
                        cv.Language = language;
                    }
                    else if (choose == 9)
                    {
                        Console.Write("New Honors Diploma (yes or no) : ");
                        string chose = Console.ReadLine();
                        cv.HonorsDiploma = chose;
                    }
                    else if (choose == 10)
                    {
                        Console.Write("New GitLink : ");
                        string gitlink = Console.ReadLine();
                        cv.GitLink = gitlink;
                    }
                    else if (choose == 11)
                    {
                        Console.Write("New Linkedin : ");
                        string linkedin = Console.ReadLine();
                        cv.Linkedin = linkedin;
                    }

                }
            }
        }

        public void DeleteNot(int ID)
        {
            var array = notifications.Where(n => n.ID != ID).ToArray();
            notifications = array;
        }

        public void ShowNot()
        {
            foreach (var not in notifications)
            {
                Console.WriteLine(not);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
