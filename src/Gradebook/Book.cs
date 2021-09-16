using System;
using System.Collections.Generic;
using System.IO;

namespace Gradebook{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);

    public class NamedObject{
        public NamedObject(string name)
        {
            Name=name;
        }

        public string Name{
            get;
            set;
        }
    }
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get;}
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
            
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt")){ 
                writer.WriteLine(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null){
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }    
            }

            return result;
        }
    }
    public class InMemoryBook : Book
    {       
        public InMemoryBook(string name) : base(name){
            Name = name;
            grades=new List<double>();
        }
        public override void AddGrade(double grade){
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

        public override Statistics GetStatistics(){
            var result=new Statistics();
            
            for(var index = 0; index < grades.Count; index ++){
                result.Add(grades[index]);
            }
            
            return result;
        }
        public override event GradeAddedDelegate GradeAdded;
        
        private List<double> grades;
        
        readonly string COURSE="Science"; // can be set in constructor
        const string COURSE2 = "Maths"; // cant be set in constructor
        //both can be read outside the class using public keyword
    }
    

}