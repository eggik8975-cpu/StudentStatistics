using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentStatistics
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double AverageScore { get; set; }
        public string GroupName { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { FirstName = "Иван",    LastName = "Петров",    Age = 19, AverageScore = 85.5, GroupName = "Группа 1" },
                new Student { FirstName = "Анна",    LastName = "Сидорова",  Age = 20, AverageScore = 92.1, GroupName = "Группа 1" },
                new Student { FirstName = "Олег",    LastName = "Кузнецов",  Age = 19, AverageScore = 74.9, GroupName = "Группа 1" },
                new Student { FirstName = "Мария",   LastName = "Васильева", Age = 20, AverageScore = 99.8, GroupName = "Группа 1" },

                new Student { FirstName = "Алексей", LastName = "Смирнов",   Age = 21, AverageScore = 88.3, GroupName = "Группа 2" },
                new Student { FirstName = "Елена",   LastName = "Морозова",  Age = 22, AverageScore = 91.4, GroupName = "Группа 2" },
                new Student { FirstName = "Дмитрий", LastName = "Волков",    Age = 21, AverageScore = 79.6, GroupName = "Группа 2" },

                new Student { FirstName = "Ольга",   LastName = "Соколова",  Age = 22, AverageScore = 72.5, GroupName = "Группа 3" },
            };

            Console.WriteLine("--- Статистика по студенческим группам ---");

            var groupStats = students
                .GroupBy(s => s.GroupName)                       
                .Select(g => new
                {
                    GroupName = g.Key,
                    Count = g.Count(),
                    AverageAge = g.Average(s => s.Age),
                    MaxScore = g.Max(s => s.AverageScore)
                })
                .OrderBy(g => g.GroupName);

            foreach (var group in groupStats)
            {
                Console.WriteLine($"Группа: {group.GroupName}");
                Console.WriteLine($" - Количество студентов: {group.Count}");
                Console.WriteLine($" - Средний возраст: {group.AverageAge:F1}");
                Console.WriteLine($" - Максимальный балл: {group.MaxScore:F1}");
            }

            Console.ReadLine();
        }
    }
}