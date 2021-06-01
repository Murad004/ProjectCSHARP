using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCSHARP
{
    class WorkMenu
    {

        public static bool CheckedEmployer(Employer[] employers, string username, string password)
        {
            foreach (var employer in employers)
            {
                if (username == employer.Username && password == employer.Password)
                {
                    return true;
                }
            }
            throw new Exception("Username or Password Incorrect!Please try again.");
        }
        public static bool CheckedWorker(Worker[] workers, string username, string password)
        {
            foreach (var worker in workers)
            {
                if (username == worker.Username && password == worker.Password)
                {
                    return true;
                }
            }
            throw new Exception("Username or Password Incorrect!Please try again.");
        }
        public static void WorkerOrEmployer()
        {
            Console.WriteLine("Employer (1)");
            Console.WriteLine("Worker (2)");
            Console.Write("You : ");
        }
        public static void LoginOrRegister()
        {
            Console.WriteLine("Login (1)");
            Console.WriteLine("Register (2)");
            Console.Write("Choose : ");
        }
        public static bool FilterSystemEmployer(Worker[] workers)
        {
            Console.Write("Enter CV name : ");
            string name = Console.ReadLine();
            Console.Clear();
            foreach (var worker in workers)
            {
                var list = worker.cVs.Where(c => c.Speciality == name).ToList();
                foreach (var l in list)
                {
                    Console.WriteLine(l);
                }
                return true;
            }
            throw new Exception("...");
        }

        public static bool FilterSystemWorker(Employer[] employers)
        {
            Console.Write("Enter Vacancy Name : ");
            string name = Console.ReadLine();
            Console.Clear();
            foreach (var employer in employers)
            {
                var list = employer.Vacancies.Where(v => v.Name == name).ToList();
                foreach (var l in list)
                {
                    Console.WriteLine(l);
                }
                return true;
            }
            throw new Exception("...");
        }
        public static bool ShowCV(Worker[] workers)
        {
            foreach (var worker in workers)
            {
                foreach (var cv in worker.cVs)
                {
                    Console.WriteLine(cv);
                    return true;
                }
            }
            throw new Exception("...");
        }


        public static void WorkerMenu(Worker[] workers, Employer[] employers)
        {
            bool workerwhile = true;
            bool workerfunctionwhile = true;
            while (workerwhile)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("Include Username : ");
                string username = Console.ReadLine();
                Console.Clear();
                Console.Write("Include Password : ");
                string password = Console.ReadLine();
                try
                {
                    if (CheckedWorker(workers, username, password))
                    {
                        foreach (var worker in workers)
                        {
                            if (username == worker.Username && password == worker.Password)
                            {
                                workerwhile = false;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Succesfully!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Clear();
                                while (workerfunctionwhile)
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Show vacancies (1)");
                                    Console.WriteLine("Add CV (2)");
                                    Console.WriteLine("Delete CV (3)");
                                    Console.WriteLine("Update CV (4)");
                                    Console.WriteLine("Show Notification (5)");
                                    Console.WriteLine("Show CV (6)");
                                    Console.WriteLine("Exit (7)");
                                    int.TryParse(Console.ReadLine(), out int choose);
                                    if (choose == 1)
                                    {
                                        Console.Clear();
                                        try
                                        {
                                            FilterSystemWorker(employers);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("Bid (1)");
                                            Console.WriteLine("Bid Remove (2)");
                                            int.TryParse(Console.ReadLine(), out int chb);
                                            if (chb == 1)
                                            {
                                                using (FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                {

                                                    string text = "Elana Muraciet edildi!";
                                                    byte[] bytes = Encoding.Default.GetBytes(text);
                                                    fs.Write(bytes, 0, bytes.Length);
                                                    
                                                }
                                                Console.Write("\nWhich publisher (Include username) : ");
                                                string fromusername = Console.ReadLine();
                                                foreach (var employer in employers)
                                                {
                                                    if (fromusername == employer.Username)
                                                    {
                                                        Console.Write("Content : ");
                                                        string content = Console.ReadLine();
                                                        Console.Write("You username : ");
                                                        string youusername = Console.ReadLine();
                                                        employer.AddNot(new Notification(content, DateTime.Now.ToLongTimeString(), youusername));
                                                    }
                                                }


                                            }
                                            else if (chb == 2)
                                            {
                                                using (FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                {

                                                    string text = "Elana olunmus muraciet silindi!";
                                                    byte[] bytes = Encoding.Default.GetBytes(text);
                                                    fs.Write(bytes, 0, bytes.Length);

                                                }
                                                Console.Write("Which ID : ");
                                                int.TryParse(Console.ReadLine(), out int id);
                                                Console.Clear();
                                                foreach (var employer in employers)
                                                {
                                                    foreach (var not in employer.Notifications)
                                                    {
                                                        if (not.ID == id)
                                                        {
                                                            employer.DeleteNot(id);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }


                                    }
                                    else if (choose == 2)
                                    {
                                        
                                        Console.Clear();
                                        worker.AddCV();
                                        using (FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                        {

                                            string text = "CV elave olundu!";
                                            byte[] bytes = Encoding.Default.GetBytes(text);
                                            fs.Write(bytes, 0, bytes.Length);

                                        }
                                    }
                                    else if (choose == 3)
                                    {
                                        Console.Clear();
                                        Console.Write("Include ID : ");
                                        int.TryParse(Console.ReadLine(), out int id);
                                        worker.DeleteCV(id);

                                    }
                                    else if (choose == 4)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Include ID : ");
                                        int.TryParse(Console.ReadLine(), out int id);
                                        worker.UpdateCV(id);
                                        using (FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                        {

                                            string text = "CV yenilendi!";
                                            byte[] bytes = Encoding.Default.GetBytes(text);
                                            fs.Write(bytes, 0, bytes.Length);

                                        }
                                    }
                                    else if (choose == 5)
                                    {
                                        Console.Clear();
                                        foreach (var not in worker.notifications)
                                        {
                                            Console.WriteLine(not);
                                            Console.WriteLine("Accept (1)");
                                            Console.WriteLine("Reject (2)");
                                            int.TryParse(Console.ReadLine(), out int ch);
                                            if (ch == 1)
                                            {
                                                Console.Write("Which employer (include username) : ");
                                                string empuser = Console.ReadLine();
                                                foreach (var employer in employers)
                                                {
                                                    if (empuser == employer.Username)
                                                    {
                                                        employer.AddNot(new Notification("Bid Accept!", DateTime.Now.ToLongTimeString(), worker.Username));
                                                    }
                                                }
                                                using (FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                {

                                                    string text = "Not accept olundu!";
                                                    byte[] bytes = Encoding.Default.GetBytes(text);
                                                    fs.Write(bytes, 0, bytes.Length);

                                                }
                                            }
                                            else if (ch == 2)
                                            {
                                                Console.Write("Which employer (include username) : ");
                                                string empuser = Console.ReadLine();
                                                if (empuser == not.Username)
                                                {
                                                    Console.WriteLine(not);
                                                    Console.Write("Which ID : ");
                                                    int.TryParse(Console.ReadLine(), out int id);
                                                    worker.DeleteNot(id);
                                                    foreach (var employer in employers)
                                                    {
                                                        if (empuser == employer.Username)
                                                        {
                                                            employer.AddNot(new Notification("Bid reject!", DateTime.Now.ToLongTimeString(), worker.Username));
                                                        }
                                                    }
                                                    using (FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                    {

                                                        string text = "Not reject olundu!";
                                                        byte[] bytes = Encoding.Default.GetBytes(text);
                                                        fs.Write(bytes, 0, bytes.Length);

                                                    }
                                                }
                                            }
                                        }

                                    }
                                    else if (choose == 6)
                                    {
                                        Console.Clear();
                                        worker.ShowCV();
                                        using (FileStream fs = new FileStream("hakuna.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                        {

                                            string text = "CV baxildi!";
                                            byte[] bytes = Encoding.Default.GetBytes(text);
                                            fs.Write(bytes, 0, bytes.Length);

                                        }
                                    }
                                    else if (choose == 7)
                                    {
                                        Console.Clear();
                                        workerfunctionwhile = false;
                                        WorkerOrEmployer();
                                        int.TryParse(Console.ReadLine(), out int chose);
                                        if (chose == 1)
                                        {
                                            Console.Clear();
                                            EmployerMenu(employers, workers);
                                        }
                                        else if (chose == 2)
                                        {
                                            Console.Clear();
                                            WorkerMenu(workers, employers);
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public static void EmployerMenu(Employer[] employers, Worker[] workers)
        {
            bool employerwhile = true;
            bool employerfunctionwhile = true;
            while (employerwhile)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Include Username : ");
                string username = Console.ReadLine();
                Console.Clear();
                Console.Write("Include Password : ");
                string password = Console.ReadLine();
                try
                {
                    if (CheckedEmployer(employers, username, password))
                    {
                        foreach (var employer in employers)
                        {
                            if (username == employer.Username && password == employer.Password)
                            {
                                employerwhile = false;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Succesfully!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Clear();
                                while (employerfunctionwhile)
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Search CV (1)");
                                    Console.WriteLine("Add Vacancy (2)");
                                    Console.WriteLine("Delete Vacancy (3)");
                                    Console.WriteLine("Update Vacancy (4)");
                                    Console.WriteLine("Show Notification (5)");
                                    Console.WriteLine("Exit (6)");
                                    int.TryParse(Console.ReadLine(), out int choose);
                                    if (choose == 1)
                                    {
                                        Console.Clear();

                                        try
                                        {
                                            FilterSystemEmployer(workers);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("Bid (1)");
                                            Console.WriteLine("Bid remove (2)");
                                            int.TryParse(Console.ReadLine(), out int chose);
                                            if (chose == 1)
                                            {
                                                Console.Write("Which publisher (Include Username) : ");
                                                string publisherusername = Console.ReadLine();
                                                foreach (var worker in workers)
                                                {
                                                    if (publisherusername == worker.Username)
                                                    {
                                                        Console.Write("Content : ");
                                                        string content = Console.ReadLine();
                                                        Console.Write("Your username : ");
                                                        string youusername = Console.ReadLine();
                                                        worker.AddNot(new Notification(content, DateTime.Now.ToLongTimeString(), youusername));

                                                    }
                                                }
                                                using (FileStream fs = new FileStream("employer.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                {

                                                    string text = "CV ye muraciet olundu!";
                                                    byte[] bytes = Encoding.Default.GetBytes(text);
                                                    fs.Write(bytes, 0, bytes.Length);

                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                    }
                                    else if (choose == 2)
                                    {
                                        Console.Clear();
                                        Console.Write("Enter Publisher name : ");
                                        string fromname = Console.ReadLine();
                                        Console.Write("Enter Name : ");
                                        string name = Console.ReadLine();
                                        Console.Write("Enter Job Description : ");
                                        string jd = Console.ReadLine();
                                        Console.Write("Enter Skills : ");
                                        string skills = Console.ReadLine();
                                        Console.Write("Enter Location : ");
                                        string location = Console.ReadLine();
                                        Console.Write("Enter Salary : ");
                                        int.TryParse(Console.ReadLine(), out int salary);
                                        Console.Clear();
                                        employer.AddVacancy(new Vacancy { FromName = fromname, Name = name, JobDescription = jd, Skills = skills, Location = location, Salary = salary });
                                        using (FileStream fs = new FileStream("employer.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                        {

                                            string text = "Vacancy add olundu!";
                                            byte[] bytes = Encoding.Default.GetBytes(text);
                                            fs.Write(bytes, 0, bytes.Length);

                                        }
                                    }
                                    else if (choose == 3)
                                    {
                                        Console.Clear();
                                        Console.Write("Include ID : ");
                                        int.TryParse(Console.ReadLine(), out int id);
                                        employer.DeleteVacancy(id);
                                        using (FileStream fs = new FileStream("employer.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                        {

                                            string text = "Vacancy silindi!";
                                            byte[] bytes = Encoding.Default.GetBytes(text);
                                            fs.Write(bytes, 0, bytes.Length);

                                        }
                                    }
                                    else if (choose == 4)
                                    {
                                        Console.Clear();
                                        Console.Write("Include ID : ");
                                        int.TryParse(Console.ReadLine(), out int id);
                                        employer.UpdateVacancy(id);
                                        using (FileStream fs = new FileStream("employer.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                        {

                                            string text = "Vacancy muraciet olundu!";
                                            byte[] bytes = Encoding.Default.GetBytes(text);
                                            fs.Write(bytes, 0, bytes.Length);

                                        }
                                    }
                                    else if (choose == 5)
                                    {
                                        Console.Clear();
                                        foreach (var not in employer.Notifications)
                                        {
                                            Console.WriteLine(not);
                                            Console.WriteLine("Accept (1)");
                                            Console.WriteLine("Reject (2)");
                                            int.TryParse(Console.ReadLine(), out int ch);
                                            if (ch == 1)
                                            {
                                                Console.Write("Which employer (include username) : ");
                                                string empuser = Console.ReadLine();
                                                foreach (var worker in workers)
                                                {
                                                    if (empuser == worker.Username)
                                                    {
                                                        worker.AddNot(new Notification("Bid Accept!", DateTime.Now.ToLongTimeString(), worker.Username));
                                                    }
                                                }
                                                using (FileStream fs = new FileStream("employer.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                {

                                                    string text = "Not accept olundu!";
                                                    byte[] bytes = Encoding.Default.GetBytes(text);
                                                    fs.Write(bytes, 0, bytes.Length);

                                                }
                                            }
                                            else if (ch == 2)
                                            {
                                                Console.Write("Which employer (include username) : ");
                                                string empuser = Console.ReadLine();
                                                if (empuser == not.Username)
                                                {
                                                    Console.WriteLine(not);
                                                    Console.Write("Which ID : ");
                                                    int.TryParse(Console.ReadLine(), out int id);
                                                    employer.DeleteNot(id);
                                                    foreach (var worker in workers)
                                                    {
                                                        if (empuser == worker.Username)
                                                        {
                                                            worker.AddNot(new Notification("Bid reject!", DateTime.Now.ToLongTimeString(), worker.Username));
                                                        }
                                                    }
                                                }
                                                using (FileStream fs = new FileStream("employer.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                {

                                                    string text = "Not reject olundu!";
                                                    byte[] bytes = Encoding.Default.GetBytes(text);
                                                    fs.Write(bytes, 0, bytes.Length);

                                                }
                                            }
                                        }
                                    }
                                    else if (choose == 6)
                                    {
                                        Console.Clear();
                                        employerfunctionwhile = false;
                                        WorkerOrEmployer();
                                        int.TryParse(Console.ReadLine(), out int chose);
                                        if (chose == 1)
                                        {
                                            EmployerMenu(employers, workers);
                                        }
                                        else if (chose == 2)
                                        {
                                            WorkerMenu(workers, employers);
                                        }

                                    }


                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void Run()
        {
            #region ObyektYaratmag
            //Vacancy vacancy1 = new Vacancy { Name = "Dizayner", JobDescription = "Yeni tikilen binalari dizayn etmek", Skills = "Ingilis dili Ve Rus dili bacarigi olmalidir", Location = "28 May Metrosu", Salary = 2500 };
            //Vacancy vacancy2 = new Vacancy { Name = "Proqramlasdirma", JobDescription = "Proqram yazacag", Skills = "Ingilis dili Ve Rus dili bacarigi olmalidir", Location = "Nizami metrosu", Salary = 2500 };
            //Vacancy vacancy3 = new Vacancy { Name = "IT", JobDescription = "Sebeke adminstratoru", Skills = "Ingilis dili Ve Rus dili bacarigi olmalidir", Location = "Icerisheher", Salary = 2500 };
            //Vacancy[] vacancies = new Vacancy[3] { vacancy1, vacancy2, vacancy3 };
            //Vacancy vacancy4 = new Vacancy { Name = "Kassir", JobDescription = "Kassada pul hesablanmasi", Skills = "Gozel danisig terzi", Location = "Xetai", Salary = 450 };
            //Vacancy vacancy5 = new Vacancy { Name = "Ofisiant", JobDescription = "Musterilere qaygi gostermek", Skills = "Gozel danisig terzi", Location = "NZS", Salary = 650 };
            //Vacancy[] vacansies1 = new Vacancy[2] { vacancy4, vacancy5 };
            //Vacancy vacancy6 = new Vacancy { Name = "Usta", JobDescription = "Kafel vuracag", Skills = "Ela kafel vursun", Location = "Shixov", Salary = 500 };
            //Vacancy vacancy7 = new Vacancy { Name = "Muellim", JobDescription = "Riyaziyyat kursu muellimliyi", Skills = "Her bir Riyazi meseleni bilmelidir ve Rus dili ela seviyyede bilmelidir", Location = "Xetai Rayonu", Salary = 1200 };
            //Vacancy[] vacansies2 = new Vacancy[2] { vacancy6, vacancy7 };
            Employer employer1 = new Employer("Akif", "Rzayev", "Baku", "0778685665", 23, "akifrza23", "akif123");
            //{
            //    Vacancies = vacancies
            //};
            Employer employer2 = new Employer("Qenire", "Qemberli", "Baku", "0505505050", 26, "qenireqemberli", "qenire123");
            //{
            //    Vacancies = vacansies1
            //};
            Employer employer3 = new Employer("Nahid", "Nesirli", "Baku", "0553443434", 28, "nahidnesirli", "nahid123");
            //{
            //    Vacancies = vacansies2
            //};
            Employer[] employers = new Employer[3] { employer1, employer2, employer3 };

            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("employers.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, employers);
                }
            }

            Worker worker1 = new Worker("Revan", "Memmedov", "Baku", "0506505050", 21, "revanmemmedov", "revan123");
            Worker worker2 = new Worker("Yunus", "Memmedov", "Baku", "0507505050", 22, "yunusmemmedov", "yunus123");
            Worker worker3 = new Worker("Nihad", "Imamelizade", "Baku", "0508505050", 25, "nihadimamelizade", "nihad123");
            Worker[] workers = new Worker[3] { worker1, worker2, worker3 };

            var serializerworker = new JsonSerializer();
            using(var swworkers=new StreamWriter("workers.json"))
            {
                using(var jwworker=new JsonTextWriter(swworkers))
                {
                    jwworker.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializerworker.Serialize(jwworker, workers);
                }
            }

            #endregion



            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome!");
            WorkerOrEmployer();
            int.TryParse(Console.ReadLine(), out int chooseWorkerOrEmployer);
            Console.Clear();
            if (chooseWorkerOrEmployer == 1)
            {
                EmployerMenu(employers, workers);
            }
            else if (chooseWorkerOrEmployer == 2)
            {
                WorkerMenu(workers, employers);
            }
        }
    }
}
