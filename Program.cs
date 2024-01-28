using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a part of the laboratory work [1, 2, 3]:");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                LabParts.Part1.Run();
                break;

            case "2":
                LabParts2.Part2.Run();
                break;

            case "3":
                LabParts3.Part3.Run();
                break;

            default:
                Console.WriteLine("Wrong choice, goodbye!");
                Console.ReadLine();
                break;
        }
    }
}
