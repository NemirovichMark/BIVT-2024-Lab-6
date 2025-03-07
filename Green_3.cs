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
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _isExpelled;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3]; 
                _isExpelled = false;
            }

            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return default;
                    return _marks;
                }
            }

            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return default;
                    double s = 0;
                    int count = 0;
                    foreach (var m in _marks)
                    {
                        if (m != 0 && count != 0)
                        {
                            s += m;
                            count++;
                        }
                    }
                    return s / _marks.Length;
                }
            }

            public bool IsExpelled => _isExpelled;

            public void Exam(int mark)
            {
                if(_isExpelled) return;
                if(mark < 2 || mark > 5) return;
                if (mark == 2)
                {
                    _isExpelled = true;
                }
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 2)
                    {
                        _marks[i] = mark;
                        return;
                    }
                }
            }

            public static void SortByAvgMark(Student[] array)
            {
                if(array == null || array.Length == 0) return;
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j].AvgMark < array[j + 1].AvgMark)
                        {
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}, Средний балл: {AvgMark:F2}, Исключен: {IsExpelled}");
            }
        }
    }
}
