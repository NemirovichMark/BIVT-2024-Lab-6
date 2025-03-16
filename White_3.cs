using System;
using System.Linq;
namespace Lab_6
{
    public class White_3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _skipped;
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    return (double)_marks.Sum() / _marks.Length;
                }
            }
            public int Skipped => _skipped;
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[0];
                _skipped = 0;
            }
            public void Lesson(int mark)
            {
                if (mark == 0) _skipped++;
                else
                {
                    if (_marks == null) return;
                    int[] new_marks = new int[_marks.Length + 1];
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        new_marks[i] = _marks[i];
                    }
                    new_marks[new_marks.Length - 1] = mark;
                    _marks = new_marks;
                }
            }

            public static void SortBySkipped(Student[] array)
            {
                if (array == null || array.Length == 0) return;
                bool y;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    y = false;
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Skipped < array[j + 1].Skipped)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            y = true;
                        }
                    }
                    if (!y) break;
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {AvgMark} {_skipped}");
            }

        }
    }
}