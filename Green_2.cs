using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_6
{
    public class Green_2
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks => _marks;
            public double AvgMark{
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    return _marks.Average();
                }
            }
            public bool IsExcellent{
                get
                {
                    if (_marks==null)return false;
                    foreach (int mark in _marks){
                        if (mark <4) return false;
                    }
                    return true;
                }
            }

            public Student(string name, string surname)
            {
                _name=name;
                _surname=surname;
                _marks=new int[4];
            }

            public void Exam(int mark){
                if (_marks == null) return;
                if(mark>5 || mark<2) return;
                for (int i =0; i<_marks.Length; i++){
                    if (_marks[i]==0){
                        _marks[i]=mark;
                        return;
                    }
                    else System.Console.WriteLine("Все экзамены сданы");
                }
            }
            public static void SortByAvgMark(Student [] array){
                if (array == null || array.Length==0) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].AvgMark < array[j+1].AvgMark)
                        {
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print(){
                System.Console.WriteLine($"{Name} {Surname} {AvgMark} {IsExcellent}");
            }
        }
    }
}