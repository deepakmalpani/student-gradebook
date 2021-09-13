using System;
using System.Collections.Generic;

namespace Gradebook{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);
    public class Book{
        
        
        public Book(string name){
            Name = name;
            grades=new List<double>();
        }
        public void AddGrade(double grade){
            if(grade <= 100 && grade >=0){
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
            else{
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public void AddGrade(char letter){
            switch(letter){
                case 'A':
                    grades.Add(90);
                    break;
                case 'B':
                    grades.Add(80);
                    break;
                case 'C':
                    grades.Add(70);
                    break;
                case 'D':
                    grades.Add(60);
                    break;
                default:
                    grades.Add(0);
                    break;
            }
        }

        public Statistics GetStatistics(){
            var result=new Statistics();
            result.Average=0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach(var grade in grades){
                result.High = Math.Max(grade,result.High);
                result.Low = Math.Min(grade,result.Low);
                result.Average+=grade;
            }
            result.Average = result.Average/grades.Count;
            switch(result.Average){
                case var d when d>=90.0:
                    result.Letter='A';
                    break;
                case var d when d>=80.0:
                    result.Letter='B';
                    break;
                case var d when d>=70.0:
                    result.Letter='D';
                    break;
                case var d when d>=60.0:
                    result.Letter='E';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }
        public event GradeAddedDelegate GradeAdded;
        
        private List<double> grades;
        public string Name{
            get;
            set;
        }

        readonly string COURSE="Science"; // can be set in constructor
        const string COURSE2 = "Maths"; // cant be set in constructor
        //both can be read outside the class using public keyword
    }
}