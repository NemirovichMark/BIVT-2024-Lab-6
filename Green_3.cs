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
            private int _countex;
            private bool _sessionclosed;

            public string Name=>_name;
            public string Surname=>_surname;
            public int[] Marks=> (int[])_marks?.Clone();
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    double sum = 0;
                    for (int i=0; i < _countex; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _countex;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_countex == 0) return false;
                    for (int i=0; i<_countex; i++)
                    {
                        if (_marks[i] <= 2) return true;
                    }
                    return false;
                }
            }


            public Student(string name, string surname){
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _sessionclosed = false;
                _countex = 0;
            }

            public void Exam(int mark)
            {
                if (_marks.Length == null || _marks.Length == 0) return;
                if (_countex >= 3) return;
                if (!_sessionclosed)
                {
                    if (mark > 2)
                    {
                        _marks[_countex] = mark;
                        _countex++;
                    }
                    else
                    {
                        _marks[_countex] = mark;
                        _countex++;
                        _sessionclosed = true;
                    }
                }
            }

            public static void SortByAvgMark(Student [] array){
                if (array == null) return;
                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i].AvgMark <= array[i - 1].AvgMark)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        Student temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        i--;
                    }
                }
            }
            public void Print(){
                System.Console.WriteLine($"{Name} {Surname} {AvgMark} {IsExpelled}");
            }
        }
    }
}