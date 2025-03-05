using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private readonly string _name;
            private readonly string _surname;
            private readonly int[,] marks;
            private int jumpNumber;

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                marks = new int[2, 5];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        marks[i, j] = 0;
                    }
                }
                jumpNumber = 0;
            }

            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    if (marks == null)
                    {
                        return null;
                    }
     
                    int[,] copy = new int[marks.GetLength(0), marks.GetLength(1)];
                    Array.Copy(marks, copy, marks.Length);
                    return copy;
                }
            }

            public void Jump(int[] results)
            {
                if (results == null || results.Length < marks.GetLength(1)) return;
                {
                    for (int i = 0; i < marks.GetLength(1); ++i)
                    {
                        marks[jumpNumber, i] = results[i];
                    }
                }
                jumpNumber += 1;
                if (jumpNumber == 2) jumpNumber = 0;
            }

            public int TotalScore
            {
                get
                {
                    if (marks == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < marks.GetLength(1); j++)
                        {
                            sum += marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1) return; 

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }


            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {TotalScore}");
            }

        }
    }
}
