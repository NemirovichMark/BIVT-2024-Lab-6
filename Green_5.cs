using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            public string Name => _name ?? default;
            public string Surname => _surname ?? default;
            public int[] Marks => _marks ?? default;
            public double AvgMark
            {
                get
                {
                    if (_marks.Length == 0 || _marks == null) return default;
                    double s = 0;
                    foreach (var m in _marks)
                    {
                        s += m;
                    }
                    return s / _marks.Length;
                }
            }
            public void Exam(int mark)
            {
                if(mark < 2 || mark > 5 || _marks == null) return;
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        return;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}, Средний балл: {AvgMark}");
            }
        }
        public struct Group
        {
            private string _name;
            private Student[] _students;
            private int _count;

            public Group(string name, int size = 10)
            {
                _name = name;
                _students = new Student[size];
                _count = 0;
            }
            public string Name => _name ?? default;
            public Student[] Students => _students ?? default;

            public double AvgMark
            {
                get
                {
                    if (_count == 0) return 0;
                    double s = 0;
                    for (int i = 0; i < _count; i++)
                    {
                        s += _students[i].AvgMark;
                    }
                    return s / _count;
                }
            }
            public void Add(Student student)
            {
                if (_count < _students.Length)
                {
                    _students[_count++] = student;
                }
            }
            public void Add(Student[] students)
            {
                foreach (var student in students)
                {
                    Add(student);
                }
            }

            public static void SortByAvgMark(Group[] array)
            {
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j].AvgMark < array[j + 1].AvgMark)
                        {
                            Group temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {Name}, Средний балл: {AvgMark:F2}");
                for (int i = 0; i < _count; i++)
                {
                    _students[i].Print();
                }
            }
        }
    }
}
