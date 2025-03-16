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
            private int _examsTaken;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3]; 
                _isExpelled = false;
                _examsTaken = 0;
            }

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    if (_marks == null)
                    {
                        return default;
                    }
                    var a = new int[_marks.Length];
                    Array.Copy(_marks, a, _marks.Length);
                    return a;
                }
                
            }

            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return default;
                    double sum = 0;
                    for (int i = 0; i < _examsTaken; i++) 
                    {
                        sum += _marks[i];
                    }
                    return _examsTaken == 0 ? 0 : sum / _examsTaken;
                }
            }

            public bool IsExpelled => _isExpelled;

            public void Exam(int mark)
            {
                if(IsExpelled || _marks == null || _marks.Length == 0) return;
                if(mark < 2 || mark > 5) return;
                if(_examsTaken >= _marks.Length) return;
                if (mark == 2)
                {
                    _isExpelled = true;
                    return;
                }
                _marks[_examsTaken] = mark;
                _examsTaken++;

            }

            public static void SortByAvgMark(Student[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 1; i < array.Length; i++)
                {
                    Student key = array[i];
                    int j = i - 1;

                    while (j >= 0 && array[j].AvgMark < key.AvgMark)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                    }
                    array[j + 1] = key;
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}, Средний балл: {AvgMark:F2}, Исключен: {IsExpelled}");
            }
        }
    }
}
