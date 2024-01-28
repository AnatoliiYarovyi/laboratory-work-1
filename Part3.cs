using System;
using System.Collections.Generic;
using System.Linq;

namespace LabParts3
{
    class Part3
    {
        public static void Run()
        {
            List<Employer> employers = new List<Employer>
            {
                new President("Іван", 10000, 10, Education.Higher, new DateTime(1991, 10, 25)),
                new Manager("Петро", 5000, 5, Education.Higher, new DateTime(1987, 5, 15)),
                new Manager("Микита", 5000, 8, Education.Higher, new DateTime(1982, 6, 7)),
                new Manager("Михайло", 5000, 8, Education.Higher, new DateTime(1995, 10, 7)),
                new Worker("Марія", 3300, 3, Education.Secondary, new DateTime(1993, 3, 10)),
                new Worker("Федір", 3000, 3, Education.None, new DateTime(1990, 8, 20)),
                new Worker("Володимир", 3000, 3, Education.None, new DateTime(1997, 8, 20)),
                new Worker("Анна", 2800, 2, Education.Secondary, new DateTime(1994, 7, 15)),
                new Worker("Ігор", 3200, 4, Education.Higher, new DateTime(1992, 4, 5)),
                new Worker("Оксана", 2900, 2, Education.Secondary, new DateTime(1996, 1, 8)),
                new Worker("Степан", 3100, 3, Education.Higher, new DateTime(1989, 9, 12)),
                new Worker("Наталя", 2700, 1, Education.Secondary, new DateTime(1998, 11, 18)),
                new Worker("Віталій", 3300, 4, Education.Higher, new DateTime(1992, 12, 22)),
                new Worker("Юлія", 3000, 2, Education.None, new DateTime(1995, 6, 30)),
                new Worker("Роман", 3100, 3, Education.Secondary, new DateTime(1993, 2, 14)),
                new Worker("Тетяна", 3200, 4, Education.Higher, new DateTime(1988, 3, 7)),
            };

            Company company = new Company(employers);

            Console.WriteLine($"Number of workers in the company: {company.GetNumberOfWorkers()}");
            Console.WriteLine($"Total salary volume to be paid: {company.GetTotalSalary()}");

            Employer youngestWithHigherEducation = company.GetYoungestManager();
            Console.WriteLine($"Найменший за віком робітник з вищою освітою: {youngestWithHigherEducation.Name}");

            Employer youngestManager = company.GetYoungestManager();
            Console.WriteLine($"Youngest manager: {youngestManager.Name}, {company.CalculateAge(youngestManager.BirthDate)} years old");

            Employer oldestManager = company.GetOldestManager();
            Console.WriteLine($"Oldest manager: {oldestManager.Name}, {company.CalculateAge(oldestManager.BirthDate)} years old");

            List<Employer> workersBornInOctober = company.GetWorkersBornInOctober();
            Console.WriteLine("Workers born in October:");
            foreach (var worker in workersBornInOctober)
            {
                Console.WriteLine($"{worker.Name}, {company.CalculateAge(worker.BirthDate)} years old, Education: {worker.Education}, Work Experience: {worker.WorkExperience} years, Birthdate: {worker.BirthDate.ToString("dd.MM.yyyy")}");
            }

            Employer youngestVladimir = company.GetYoungestVladimir();

            if (youngestVladimir != null)
            {
                company.CongratulateWithBonus(youngestVladimir);
            }
            else
            {
                Console.WriteLine($"This time, no one received a bonus");
            }

            Console.ReadLine();
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
        public double Salary { get; set; }
        public int WorkExperience { get; set; }
        public Education Education { get; set; }
        public DateTime BirthDate { get; set; }

        public Employer(string name, double salary, int workExperience, Education education, DateTime birthDate)
        {
            Name = name;
            Salary = salary;
            WorkExperience = workExperience;
            Education = education;
            BirthDate = birthDate;
        }
    }

    class President : Employer
    {
        public President(string name, double salary, int workExperience, Education education, DateTime birthDate)
            : base(name, salary, workExperience, education, birthDate)
        {
        }
    }

    class Manager : Employer
    {
        public Manager(string name, double salary, int workExperience, Education education, DateTime birthDate)
            : base(name, salary, workExperience, education, birthDate)
        {
        }
    }

    class Worker : Employer
    {
        public Worker(string name, double salary, int workExperience, Education education, DateTime birthDate)
            : base(name, salary, workExperience, education, birthDate)
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

        public Employer GetYoungestWithHigherEducation()
        { 
            List < Employer > topWorkers = employers.OrderByDescending(w => w.WorkExperience).Take(10).ToList();
            Employer youngestWithHigherEducation = topWorkers.Where(w => w.Education == Education.Higher).OrderBy(w => w.BirthDate).FirstOrDefault();
            return youngestWithHigherEducation;
        }

        public Employer GetYoungestManager()
        {
            return employers.OfType<Manager>().OrderByDescending(e => e.BirthDate).FirstOrDefault();
            
        }

        public Employer GetOldestManager()
        {
            return employers.OfType<Manager>().OrderBy(e => e.BirthDate).FirstOrDefault();
        }

        public List<Employer> GetWorkersBornInOctober()
        {
            return employers.Where(e => e.BirthDate.Month == 10).ToList();
        }

        public Employer GetYoungestVladimir()
        {
            return employers.FirstOrDefault(e => e.Name.StartsWith("Володимир", StringComparison.OrdinalIgnoreCase));
        }

        public void CongratulateWithBonus(Employer employer)
        {
            double bonus = employer.Salary / 3;
            Console.WriteLine($"Congratulations to {employer.Name} on receiving a bonus of {bonus}!");
        }

        public int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
