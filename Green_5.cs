 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Text.RegularExpressions;
 using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_5
    {
        public struct Student
        {
            // Поля
            private string _name;
            private string _surname;
            private int[] _marks;

            // Свойства
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
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0){return 0;}
                    double sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _marks.Length;
                }
            }

            // Конструкторы
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5]{-1, -1, -1, -1, -1};
            }

            // Методы
            public void Exam(int mark)
            {
                if (_marks == null || _marks.Length == 0){return;}
                if (mark < 2 || mark > 5) return;
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == -1)
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark:F2}");
            }
        }

        public struct Group
        {
            // Поля
            private string _name;
            private Student[] _students;
            private int _studentCount;

            // Свойства
            public string Name => _name;
            public Student[] Students => _students;
            public double AvgMark
            {
                get
                {
                    if (_students == null || _studentCount == 0) return 0;
                    double totalAvg = 0;
                    int validStudents = 0;
                    for (int i = 0; i < _studentCount; i++)
                    {
                        if (_students[i].AvgMark > 0)
                        {
                            totalAvg += _students[i].AvgMark;
                            validStudents++;
                        }
                    }
                    return validStudents == 0 ? 0 : totalAvg / validStudents;
                }
            }

            // Конструкторы
            public Group(string name)
            {
                _name = name;
                _students = new Student[0];
                _studentCount = 0;
            }

            // Методы
            public void Add(Student student)
            {
                if (_students == null)
                    _students = new Student[0];
                Array.Resize(ref _students, _studentCount + 1);
                _students[_studentCount] = student;
                _studentCount++;
            }

            public void Add(Student[] students)
            {
                if (students == null)
                     return;
                 if (_students == null)
                     _students = new Green_5.Student[0];

                 int newLength = _studentCount + students.Length;
                 Array.Resize(ref _students, newLength);
                 for (int i = 0; i < students.Length; i++)
                 {
                     _students[_studentCount + i] = students[i];
                 }
                 _studentCount = newLength;
            }

            public static void SortByAvgMark(Group[] groups)
            {
                for (int i = 0; i < groups.Length - 1; i++)
                {
                    for (int j = 0; j < groups.Length - 1 - i; j++)
                    {
                        if (groups[j].AvgMark < groups[j + 1].AvgMark)
                        {
                            (groups[j], groups[j + 1]) = (groups[j + 1], groups[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {AvgMark:F2}");
                for (int i = 0; i < _studentCount; i++)
                {
                    _students[i].Print();
                }
            }
        }
    }
}