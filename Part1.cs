using System;
using System.Collections.Generic;
using System.Linq;

namespace LabParts
{
    class Part1
    {
        public static void Run()
        {
            // Cтворення колекції фірм
            List<Firm> firms = new List<Firm>
        {
            new Firm("Food Corp", DateTime.Parse("2021-01-01"), "Food", "White", "John", "ASD", 120, "London"),
            new Firm("Marketing Solutions", DateTime.Parse("2020-05-15"), "Marketing", "Black", "Jane", "Asd", 80, "New York"),
            new Firm("QWE", DateTime.Parse("2022-06-07"), "IT", "White", "Qwe", "Asd", 45, "Ukraine"),
            new Firm("WhiteAsd", DateTime.Parse("2022-06-07"), "IT", "Black", "Qwe", "Asd", 45, "Ukraine"),
        };

            // Отримання інформації про всі фірми
            var allFirms = firms;

            // Отримання фірм, які мають назву "Food"
            var foodFirms = firms.Where(f => f.Name.Contains("Food"));

            // Отримання фірм, що працюють у галузі "Marketing"
            var marketingFirms = firms.Where(f => f.BusinessProfile == "Marketing");

            // Отримання фірм, що працюють у галузі "Marketing" або "IT"
            var marketingOrITFirms = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");

            // Отримання фірм з кількістю співробітників більше 100
            var firmsWithMoreThan100Employees = firms.Where(f => f.EmployeeCount > 100);

            // Отримання фірм з кількістю співробітників у діапазоні від 100 до 300
            var firmsWithEmployeesBetween100And300 = firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300);

            // Отримання фірм, що знаходяться у Лондоні
            var londonFirms = firms.Where(f => f.Address.Contains("London"));

            // Отримання фірм, які мають прізвище директора "White"
            var directorWhiteFirms = firms.Where(f => f.DirectorLastName == "White");

            // Отримання фірм, які засновані понад два роки тому
            var firmsFoundedOverTwoYearsAgo = firms.Where(f => (DateTime.Now - f.FoundingDate).TotalDays > 730);

            // Отримання фірм, заснованих більше 150 днів тому
            var firmsFoundedOver150DaysAgo = firms.Where(f => (DateTime.Now - f.FoundingDate).TotalDays > 150);

            // Отримання фірм, у яких прізвище директора "Black" та назва фірми містить слово "White"
            var blackDirectorWhiteInNameFirms = firms
            .Where(f => f.DirectorLastName == "Black" && f.Name.ToLower().Contains("white"))
            .ToList();

            // Виведення результатів
            Console.WriteLine("All Firms:");
            PrintFirms(allFirms);

            Console.WriteLine("\nFood Firms:");
            PrintFirms(foodFirms);

            Console.WriteLine("\nMarketing Firms:");
            PrintFirms(marketingFirms);

            Console.WriteLine("\nMarketing or IT Firms:");
            PrintFirms(marketingOrITFirms);

            Console.WriteLine("\nFirms with more than 100 Employees:");
            PrintFirms(firmsWithMoreThan100Employees);

            Console.WriteLine("\nFirms with Employees between 100 and 300:");
            PrintFirms(firmsWithEmployeesBetween100And300);

            Console.WriteLine("\nLondon Firms:");
            PrintFirms(londonFirms);

            Console.WriteLine("\nDirector White Firms:");
            PrintFirms(directorWhiteFirms);

            Console.WriteLine("\nFirms Founded Over Two Years Ago:");
            PrintFirms(firmsFoundedOverTwoYearsAgo);

            Console.WriteLine("\nFirms Founded Over 150 Days Ago:");
            PrintFirms(firmsFoundedOver150DaysAgo);

            Console.WriteLine("\nBlack Director White In Name Firms:");
            PrintFirms(blackDirectorWhiteInNameFirms);

            Console.ReadLine();
        }

        static void PrintFirms(IEnumerable<Firm> firms)
        {
            foreach (var firm in firms)
            {
                Console.WriteLine($"Name: {firm.Name}, Business Profile: {firm.BusinessProfile}, Director: { firm.DirectorLastName} { firm.DirectorFirstName} {firm.DirectorMiddleName}, Employees: {firm.EmployeeCount}, Address: {firm.Address}");
            }
        }
    }

    class Firm
    {
        public string Name { get; set; }
        public DateTime FoundingDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorLastName { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorMiddleName { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }

        public Firm(string name, DateTime foundingDate, string businessProfile, string directorLastName, string directorFirstName, string directorMiddleName, int employeeCount, string address)
        {
            Name = name;
            FoundingDate = foundingDate;
            BusinessProfile = businessProfile;
            DirectorLastName = directorLastName;
            DirectorFirstName = directorFirstName;
            DirectorMiddleName = directorMiddleName;
            EmployeeCount = employeeCount;
            Address = address;
        }
    }

}