using System;
using System.Linq;


namespace Lab_6
{
    public class Green_5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            

            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }

            public int[] Marks
            {
                get
                {
                    return _marks;
                }
            }

            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    
                    double sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / (double)_marks.Length;
                }
            }
            
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
               
            }

            public void Exam(int mark)
            {
                if (_marks == null) return;
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

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark}");
            }
        }

        public struct Group
        {
            private string _name;
            private Student[] _students;
            private int _studentCount;
            private int _capacity;

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public Student[] Students
            {
                get
                {
                    if (_students == null || _studentCount == 0) return default(Student[]);
                    return _students;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_students == null || _studentCount == 0)
                    {
                        return 0;
                    }
                    double totalMark = 0;

                    for (int i = 0; i < _studentCount; i++)
                    {
                        totalMark += _students[i].AvgMark;
                    }
                    double averageMark = totalMark / (double)_studentCount;

                    return averageMark;
                }
            }

            private static int StudentsCount(Group group)
            {
                if (group._students == null) return 0;
                return group._studentCount;
            }

            public Group(string name)
            {
                _name = name;
                _capacity = 100;
                _students = new Student[_capacity];
                _studentCount = 0;
            }
            public void Add(Student student)
            {
                if (_studentCount == _capacity)
                {
                    ResizeArray();
                }

                _students[_studentCount] = student;
                _studentCount++;
            }

            public void Add(params Student[] students)
            {
                foreach (Student student in students)
                {
                    Add(student);
                }
            }

            private void ResizeArray()
            {
                
                _capacity *= 2;
                if (_capacity <= 0) _capacity = 30;

                Student[] newStudents = new Student[_capacity];

                Array.Copy(_students, newStudents, _studentCount);

                _students = newStudents;
            }

            public static void SortByAvgMark(Group[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
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
                Console.WriteLine($"{_name} {AvgMark}");
                foreach (var student in _students)
                {
                    student.Print();
                }
            }
        }
    }
}
