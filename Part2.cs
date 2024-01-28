using System;
using System.Collections.Generic;
using System.Linq;

namespace LabParts2
{
    class Part2
    {
        public static void Run()
        {
            // Cтворення колекції телефонів
            List<Phone> phones = new List<Phone>
        {
            new Phone("iPhone 13", "Apple", 1200, DateTime.Parse("2021-09-14")),
            new Phone("Galaxy S22", "Samsung", 900, DateTime.Parse("2022-01-20")),
            new Phone("iPhone 7", "Apple", 450, DateTime.Parse("2015-08-22")),
            new Phone("Galaxy S22", "Samsung", 900, DateTime.Parse("2022-01-20")),
            new Phone("Pixel 6", "Google", 800, DateTime.Parse("2022-02-15")),
            new Phone("OnePlus 9", "OnePlus", 750, DateTime.Parse("2021-11-10")),
            new Phone("Xperia 5 III", "Sony", 900, DateTime.Parse("2022-03-05")),
            // Додайте інші телефони за необхідностю
        };

            // Порахуйте кількість телефонів
            int totalPhones = phones.Count;

            // Порахуйте кількість телефонів із ціною більше 100
            int phonesWithPriceOver100 = phones.Count(p => p.Price > 100);

            // Порахуйте кількість телефонів з ціною в діапазоні від 400 до 700
            int phonesWithPriceBetween400And700 = phones.Count(p => p.Price >= 400 && p.Price <= 700);

            // Порахуйте кількість телефонів конкретного виробника (наприклад, Apple)
            int applePhonesCount = phones.Count(p => p.Manufacturer == "Apple");

            // Знайдіть телефон із мінімальною ціною
            Phone minPricePhone = phones.OrderBy(p => p.Price).FirstOrDefault();

            // Знайдіть телефон із максимальною ціною
            Phone maxPricePhone = phones.OrderByDescending(p => p.Price).FirstOrDefault();

            // Відобразіть інформацію про найстарший телефон
            Phone oldestPhone = phones.OrderBy(p => p.ReleaseDate).FirstOrDefault();

            // Відобразіть інформацію про найсвіжіший телефон
            Phone newestPhone = phones.OrderByDescending(p => p.ReleaseDate).FirstOrDefault();

            // Знайдіть середню ціну телефона
            double averagePrice = phones.Average(p => p.Price);

            // Відобразіть п'ять найдорожчих телефонів
            var top5ExpensivePhones = phones.OrderByDescending(p => p.Price).Take(5);

            // Відобразіть п'ять найдешевших телефонів
            var top5CheapestPhones = phones.OrderBy(p => p.Price).Take(5);

            // Відобразіть три найстаріші телефони
            var top3OldestPhones = phones.OrderBy(p => p.ReleaseDate).Take(3);

            // Відобразіть три найновіші телефони
            var top3NewestPhones = phones.OrderByDescending(p => p.ReleaseDate).Take(3);

            // Відобразіть статистику щодо кількості телефонів кожного виробника
            var manufacturerStatistics = phones
                .GroupBy(p => p.Manufacturer)
                .Select(group => $"{group.Key} - {group.Count()}")
                .ToList();

            // Відобразіть статистику щодо кількості моделей телефонів
            var modelStatistics = phones
                .GroupBy(p => p.Model)
                .Select(group => $"{group.Key} - {group.Count()}")
                .ToList();

            // Відобразіть статистику телефонів за роками
            var yearStatistics = phones
                .GroupBy(p => p.ReleaseDate.Year)
                .Select(group => $"{group.Key} - {group.Count()}")
                .ToList();

            // Виведення результатів
            Console.WriteLine($"Total Phones: {totalPhones}");
            Console.WriteLine($"Phones with Price > 100: {phonesWithPriceOver100}");
            Console.WriteLine($"Phones with Price between 400 and 700: {phonesWithPriceBetween400And700}");
            Console.WriteLine($"Apple Phones Count: {applePhonesCount}");

            Console.WriteLine($"\nPhone with Min Price: {minPricePhone}");
            Console.WriteLine($"\nPhone with Max Price: {maxPricePhone}");
            Console.WriteLine($"\nOldest Phone: {oldestPhone}");
            Console.WriteLine($"\nNewest Phone: {newestPhone}");

            Console.WriteLine($"\nAverage Price: {averagePrice}");

            Console.WriteLine("\nTop 5 Expensive Phones:");
            PrintPhones(top5ExpensivePhones);

            Console.WriteLine("\nTop 5 Cheapest Phones:");
            PrintPhones(top5CheapestPhones);

            Console.WriteLine("\nTop 3 Oldest Phones:");
            PrintPhones(top3OldestPhones);

            Console.WriteLine("\nTop 3 Newest Phones:");
            PrintPhones(top3NewestPhones);

            Console.WriteLine("\nManufacturer Statistics:");
            foreach (var stat in manufacturerStatistics)
            {
                Console.WriteLine(stat);
            }

            Console.WriteLine("\nModel Statistics:");
            foreach (var stat in modelStatistics)
            {
                Console.WriteLine(stat);
            }

            Console.WriteLine("\nYear Statistics:");
            foreach (var stat in yearStatistics)
            {
                Console.WriteLine(stat);
            }

            Console.ReadLine();
        }

        static void PrintPhones(IEnumerable<Phone> phones)
        {
            foreach (var phone in phones)
            {
                Console.WriteLine($"{phone.Model} - {phone.Manufacturer} - {phone.Price}");
            }
        }
    }

    class Phone
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Phone(string model, string manufacturer, double price, DateTime releaseDate)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public override string ToString()
        {
            return $"{Model} - {Manufacturer} - {Price}";
        }
    }
}