using System;
using System.Linq;
namespace Lab_6
{
    public class Green_2
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _examscount;

            public Student(string name, string surname)
            {
                _name=name;
                _surname=surname;
                _marks=new int[4];
                _examscount=0;
            }

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks{
                get{
                    return(int[])_marks.Clone();
                }
            }
            public double AvgMark{
                get
                {
                    if (_examscount<4)  return  0;
                    double sum=0;
                    for  (int i=0;i<_examscount;i++){
                        sum+=_marks[i];
                    }
                    return sum/(double)_examscount;
                }
            }
            public bool IsExcellent{
                get
                {
                    if (_examscount==0)return false;
                    foreach (int mark in _marks){
                        if (mark <4) return false;
                    }
                    return true;
                }
            }

            public void Exam(int mark){
                if(mark>5 || mark<2) return;
                if (_examscount <_marks.Length){
                    _marks[_examscount]=mark;
                    _examscount++;
                }
            }
            public static void SortByAvgMark(Student [] array){
                if (array == null) return;
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