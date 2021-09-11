using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gradebook
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var book = new Book("Deepak's gradebook");
            while(true){
                System.Console.WriteLine("Enter the grade (or q to stop) :");
                var input = Console.ReadLine();
                if(input=="q"){
                    break;
                }
                try{
                var grade = double.Parse(input);
                book.AddGrade(grade);
                }
                catch(ArgumentException ex){
                    System.Console.WriteLine(ex.Message);
                }
                catch(FormatException ex){
                    System.Console.WriteLine(ex.Message);
                }
                
            }
            // book.AddGrade(89.1);
            // book.AddGrade(12.7);
            // book.AddGrade(12.44);
            
            var stats = book.GetStatistics();
            System.Console.WriteLine($"The lowest grade is {stats.Low}");
            System.Console.WriteLine($"The highest grade is {stats.High}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");    
            System.Console.WriteLine($"The letter grade is {stats.Letter}"); 
        }
    }
}
