using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSHARP
{
    class Employer : Base
    {
        public Vacancy[] Vacancies { get; set; }
        public int VacancyCount { get; set; }
        public Notification[] Notifications { get; set; }
        public int NotCount { get; set; }

        public Employer(string name, string surname, string city, string phonenumber, int age, string username, string password)
            : base(name, surname, city, phonenumber, age, username, password)
        {

        }

        public void ShowVacancy()
        {
            if (Vacancies != null)
            {
                foreach (var vac in Vacancies)
                {
                    Console.WriteLine(vac);
                }
            }
        }

        public void AddNot(Notification newnot)
        {
            Notification[] temp = new Notification[++NotCount];
            if (Notifications != null)
            {
                Notifications.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = newnot;
            Notifications = temp;
        }

        public  void DeleteNot(int ID)
        {
            var array = Notifications.Where(n => n.ID != ID).ToArray();
            Notifications = array;
        }



        public void AddVacancy(Vacancy newvacancy)
        {
            Vacancy[] temp = new Vacancy[++VacancyCount];
            if (Vacancies != null)
            {
                Vacancies.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = newvacancy;
            Vacancies = temp;
        }

        public Vacancy[] DeleteVacancy(int ID)
        {
            Vacancy[] source = Vacancies;
            Vacancy[] destination = new Vacancy[source.Length - 1];
            if (ID > 0)
            {
                Array.Copy(source, 0, destination, 0, ID);
            }
            if (ID < source.Length - 1)
            {
                Array.Copy(source, ID + 1, destination, ID, source.Length - ID - 1);
            }
            return destination;
        }

        public void UpdateVacancy(int ID)
        {
            foreach (var vacancy in Vacancies)
            {
                if (ID == vacancy.ID)
                {
                    Console.WriteLine("Name (1)");
                    Console.WriteLine("Job Description (2)");
                    Console.WriteLine("Skills (3)");
                    Console.WriteLine("Salary (4)");
                    Console.Write("You choose : ");
                    int.TryParse(Console.ReadLine(), out int choose);
                    Console.Clear();
                    if (choose == 1)
                    {
                        Console.Write("New Name : ");
                        string name = Console.ReadLine();
                        vacancy.Name = name;
                        ShowVacancy();
                    }
                    else if (choose == 2)
                    {
                        Console.Write("New Job Description : ");
                        string jdescription = Console.ReadLine();
                        vacancy.JobDescription = jdescription;
                        ShowVacancy();
                    }
                    else if (choose == 3)
                    {
                        Console.Write("New Skills : ");
                        string skills = Console.ReadLine();
                        vacancy.Skills = skills;
                        ShowVacancy();
                    }
                    else if (choose == 4)
                    {
                        Console.Write("New Salary : ");
                        int.TryParse(Console.ReadLine(), out int salary);
                        vacancy.Salary = salary;
                        ShowVacancy();
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }

    }
}
