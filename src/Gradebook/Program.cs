using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>(){12.7,10.3,12.44};
            

            var book = new Book("Deepak's gradebook");
            book.AddGrade(89.1);
            book.AddGrade(12.7);
            book.AddGrade(12.44);
            
            var stats = book.GetStatistics();
            System.Console.WriteLine($"The lowest grade is {stats.Low}");
            System.Console.WriteLine($"The highest grade is {stats.High}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");    
        }
    }
}
