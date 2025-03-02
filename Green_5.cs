using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_6{
    public class Green_5{
        public struct Student{
            private string _name;
            private string _surname;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks;
            public double AvgMark{
                get {
                    if (_marks == null || _marks.Length == 0) return 0;
                    return _marks.Average();
                }
            }

            public Student(string name, string surname){
                _name=name;
                _surname=surname;
                _marks=new int[5];
            }

            public void Exam(int mark){
                if (mark<2||mark>5) return;
                if (_marks == null) return;
                for (int i=0; i<_marks.Length; i++){
                    if (_marks[i]==0){
                        _marks[i]=mark;
                        return;
                    }
                }
            }
            public void Print(){
                System.Console.WriteLine($"{Name} {Surname} {AvgMark}");
            }
        }
        public struct Group{
            private string _name;
            private Student[] _students;
            private int _studentcount;

            public string Name=>_name;
            public Student[] Students=>_students;
            public double AvgMark{
                get{
                    if (_students == null || _studentcount == 0) return 0;
                    double sum =0;
                    for (int i=0; i<_studentcount;i++){
                        sum+=_students[i].AvgMark;
                    }
                    return sum/_studentcount;
                }
            }

            public Group(string name){
                _name=name;
                _students=new Student[100];
                _studentcount=0;
            }
            public void Add(Student student){
                if (_studentcount<100){
                    _students[_studentcount++]=student;
                }
                else System.Console.WriteLine("Группа переполнена");
            }
            public void Add(Student[] students){
                foreach(Student student in students){
                    if (_studentcount<100){
                        _students[_studentcount++]=student;
                    }
                    else System.Console.WriteLine("Группа переполнена");
                }
            }
            public void SortByAvgMark(Group[] groups){
                for (int i=0; i<groups.Length-1;i++){
                    for (int j=0; j<groups.Length-i-1; j++){
                        if (groups[j].AvgMark < groups[j+1].AvgMark){
                            Group temp = groups[j];
                            groups[j]= groups[j+1];          
                            groups[j+1]=temp;                  
                        }
                    }
                }
            }
            public void Print(){
                System.Console.WriteLine($"{Name} {AvgMark}");
                foreach (var student in _students){
                    student.Print();
                }
            }
        }
    }
}