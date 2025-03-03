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
            //поля
            private string _name;
            private string _surname;
            private int[] _marks;

            //свойства
            public string Name  => _name;
            public string Surname  => _surname;
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
            public bool IsExcellent
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return false;
                    foreach (int mark in _marks)
                    {
                        if (mark < 4)
                            return false;
                    }
                    return true;
                }
            }

            //конструкторы
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[4];
            }

            //остальные методы
            public void Exam(int mark)
            {
                if (_marks == null || _marks.Length == 0) return;
                if (mark < 2 || mark > 5) return;
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }

            public static void SortByAvgMark(Student [] array)
            {
                if (array == null || array.Length == 0)
                    return;

                bool swapped = true;
                while (swapped)
                {
                    swapped = false;
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i].AvgMark < array[i + 1].AvgMark)
                        {
                            Student temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            swapped = true;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark} {IsExcellent}");
            }
            
        }
    }
}
