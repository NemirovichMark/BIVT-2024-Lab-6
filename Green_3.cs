using System;
using System.Linq;


namespace Lab_6
{
    public class Green_3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _count_exams;
            private bool _session_outcome;

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
                    return (int[])_marks?.Clone(); // ? предотвращает ошибку, тк вмето вызова Clone возвращается null
                }
            }


            public double AvgMark
            {
                get
                {
                    if (_marks.Length == 0 || _marks == null)
                    {
                        return 0; 
                    }

                    double sum = 0;
                    foreach (int mark in _marks)
                    {
                        sum += mark;
                    }
                    if (_count_exams != 0) return sum / (double)_count_exams;
                    else return 0;
                }
            }

            public bool IsExpelled 
            {
                get
                {
                    if (_count_exams == 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < _count_exams; i++)
                    {
                        if (_marks[i] <= 2)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3]; // инициализируем массив нулями
                _session_outcome = false;
                _count_exams = 0;
            }

            public void Exam(int mark) 
            {
                
                if (_marks.Length == 0 || _marks == null) return;
                
                if (_count_exams >= 3) return;
                
                if (!_session_outcome)
                {
                    if (mark > 2)
                    {
                        _marks[_count_exams] = mark;
                        _count_exams++;
                    }
                    else
                    {
                        _marks[_count_exams] = mark;
                        _count_exams++;
                        _session_outcome = true;
                    }
                }
                
            }

            public static void SortByAvgMark(Student[] array)
            {
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

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark} {IsExpelled}");
            }
        }
    }
}
