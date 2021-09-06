using System;
using System.Collections.Generic;

namespace Gradebook{
    class Book{
        
        
        public Book(string name){
            this.name = name;
            this.grades=new List<double>();
        }
        public void AddGrade(double grade){
            grades.Add(grade);
        }

        public void ShowStatistics(){
            var result=0.0;
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;
            foreach(var number in grades){
                highestGrade = Math.Max(number,highestGrade);
                lowestGrade = Math.Min(number,lowestGrade);
                result+=number;
            }
            result = result/grades.Count;
            System.Console.WriteLine($"The average grade is {result:N1} \n The highest grade is {highestGrade} \n The lowest grade is {lowestGrade}");
        }
        private List<double> grades;
        private string name;
    }
}