using System;
using System.Linq;


namespace Lab_6
{
    public class Green_2
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _exams_taken_count;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[4]; 
                _exams_taken_count = 0;
            }

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
                    return (int[])_marks.Clone(); 
                }
            }

            public double AvgMark
            {
                get
                {
                    if (_exams_taken_count < 4) return 0; 

                    double sum = 0;
                    for (int i = 0; i < _exams_taken_count; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / (double)_exams_taken_count;
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

            public bool IsExcellent
            {
                get
                {
                    if (_exams_taken_count == 0) return false;
                    for (int i = 0; i < _exams_taken_count; i++)
                    {
                        if (_marks[i] < 4)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            public void Exam(int mark)
            {
                if (mark < 2 || mark > 5) return;

                if (_exams_taken_count < _marks.Length) 
                {
                    _marks[_exams_taken_count] = mark;
                    _exams_taken_count++;
                }

            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark} {IsExcellent}");
            }

        }

    }




    
}
