using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabParts3
{
    class Part3
    {
        public static void Run()
        {
            List<Employer> employers = new List<Employer>
            {
                new President("Іван", 45, 10000, 10, Education.Higher),
                new Manager("Петро", 35, 5000, 5, Education.Higher),
                new Manager("Микита", 40, 5000, 8, Education.Higher),
                new Worker("Марія", 28, 3300, 3, Education.Secondary),
                new Worker("Федір", 33, 3000, 3, Education.None),
            };

            Company company = new Company(employers);

            Console.WriteLine($"Число робітників на підприємстві: {company.GetNumberOfWorkers()}");
            Console.WriteLine($"Об’єм заробітної платні, що необхідно виплатити: {company.GetTotalSalary()}");

            Employer youngestManager = company.GetYoungestManager();
            Console.WriteLine($"Наймолодший менеджер: {youngestManager.Name}, {youngestManager.Age} років");

            Employer oldestManager = company.GetOldestManager();
            Console.WriteLine($"Найстарший менеджер: {oldestManager.Name}, {oldestManager.Age} років");

            List<Employer> workersBornInOctober = company.GetWorkersBornInOctober();
            Console.WriteLine("Робітники, народжені в жовтні:");
            foreach (var worker in workersBornInOctober)
            {
                Console.WriteLine($"{worker.Name}, {worker.Age} років, Освіта: {worker.Education}, Стаж: {worker.WorkExperience} років");
            }

            Employer youngestVladimir = company.GetYoungestVladimir();
            if (youngestVladimir == null)
            {
                Console.WriteLine($"В цей раз премію ніхто не отримав");
            } else {
                company.CongratulateWithBonus(youngestVladimir); 
            }
            
        }
    }
    enum Education
    {
        None,
        Secondary,
        Higher
    }
    class Employer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int WorkExperience { get; set; }
        public Education Education { get; set; }

        public Employer(string name, int age, double salary, int workExperience, Education education)
        {
            Name = name;
            Age = age;
            Salary = salary;
            WorkExperience = workExperience;
            Education = education;
        }
    }

    class President : Employer
    {
        public President(string name, int age, double salary, int workExperience, Education education)
            : base(name, age, salary, workExperience, education)
        {
        }
    }

    class Manager : Employer
    {
        public Manager(string name, int age, double salary, int workExperience, Education education)
            : base(name, age, salary, workExperience, education)
        {
        }
    }

    class Worker : Employer
    {
        public Worker(string name, int age, double salary, int workExperience, Education education)
            : base(name, age, salary, workExperience, education)
        {
        }
    }

    class Company
    {
        private List<Employer> employers;

        public Company(List<Employer> employers)
        {
            this.employers = employers;
        }

        public int GetNumberOfWorkers()
        {
            return employers.Count();
        }

        public double GetTotalSalary()
        {
            return employers.Sum(e => e.Salary);
        }

        public Employer GetYoungestManager()
        {
            return employers.OfType<Manager>().OrderBy(e => e.Age).FirstOrDefault();
        }

        public Employer GetOldestManager()
        {
            return employers.OfType<Manager>().OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public List<Employer> GetWorkersBornInOctober()
{
    return employers.OfType<Worker>().Where(w => w.Age >= 18 && w.Age <= 60 && w.Education == Education.Higher && w.WorkExperience >= 2).Cast<Employer>().ToList();
}

        public Employer GetYoungestVladimir()
        {
            return employers.Where(e => e.Name.StartsWith("Володимир", StringComparison.OrdinalIgnoreCase)).OrderBy(e => e.Age).FirstOrDefault();
        }

        public void CongratulateWithBonus(Employer employer)
        {
            double bonus = employer.Salary / 3;
            Console.WriteLine($"Поздоровляємо {employer.Name} з премією у розмірі {bonus}!");
        }
    }
}
