using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_6
{
    public class Green_3
    {
        public struct Student
        {
            //поля
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _isExpelled;
            private int _examCount;

            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    if (_examCount == 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < _examCount; i++)
                    {
                        if (_marks[i] <= 2)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;

                    double sum = 0;
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
                    return sum / count;
                }
            }

            //конструктор
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _isExpelled = false;
                _examCount = 0;
            }
            public void Exam(int mark)
            {
                if (_marks == null || _marks.Length == 0) return;
                if (_examCount >= 3){return;}
                if (_isExpelled) return;
                if (mark >= 2 && mark <= 5)
                    {
                        _marks[_examCount] = mark;
                        _examCount++;
                    }
                else
                    {
                        _marks[_examCount] = mark;
                        _examCount++;
                        _isExpelled = true;
                    }
                if (mark <= 2)
                {
                    _isExpelled = true;
                }
            }
            public static void SortByAvgMark(Student [] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AvgMark < array[j+1].AvgMark)
                        {
                            (array[j],array[j+1])=(array[j+1],array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Math.Round(AvgMark, 2)} {IsExpelled}");
            }
        }
    }
}