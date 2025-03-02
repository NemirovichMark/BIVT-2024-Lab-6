using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_6
{
    public class Green_3
    {
        public struct Student{
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _isExpelled;

            public string Name=>_name;
            public string Surname=>_surname;
            public int[] Marks => _marks;
            public double AvgMarks
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    int sum = 0;
                    int count = 0;
                    foreach (int mark in _marks)
                    {
                        if (mark != 0)
                        {
                            sum += mark;
                            count++;
                        }
                    }
                    if (count == 0) return 0;
                    return (double)sum / count;
                }
            }

            public bool IsExpelled => _isExpelled;

            public Student(string name, string surname){
                _name = name;
                _surname = surname;
                _marks = new int[] {2,2,2};
                _isExpelled=false;
            }

            public void Exam(int mark)
            {
                if (mark<0||mark>5) return;
                if (mark ==2) _isExpelled = true;
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 2)
                    {
                        _marks[i] = mark;
                        return;
                    }
                }
            }
            public static void SortByAvgMark(Student [] array){
                if (array==null) return;
                for (int i =0; i<array.Length-1; i++){
                    for (int j = 0; j<array.Length-i-1; j++){
                        if (array[j].AvgMarks<array[j+1].AvgMarks){
                            Student temp = array[j];
                            array[j]=array[j+1];
                            array[j+1]=temp;
                        }
                    }
                }
            }
            public void Print(){
                System.Console.WriteLine($"{Name} {Surname} {Math.Round(AvgMarks,2)} {IsExpelled}");
            }
        }
    }
}