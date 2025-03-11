using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_2;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int _count;

            //свойства
            public string Name => _name; // ?? "Unknown";
            public string Surname => _surname; // ?? "Unknown";
            public int[,] Marks
            {
                get
                {
                    if (_marks == null)
                    {
                        return null;
                    }
                    int[,] nMarks = new int[2, 5];
                    for (int i = 0; i <= 1; i++)
                    {
                        for (int j = 0; j <= 4; j++)
                        {
                            nMarks[i, j] = _marks[i, j];
                        }
                    }
                    return nMarks;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0)
                    {
                        return 0;
                    }
                    int cnt = 0;
                    for (int i = 0; i <= 1; i++)
                    {
                        for (int j = 0; j <= 4; j++)
                        {
                            cnt += _marks[i, j];
                            //Console.Write(_marks[i,j]);
                        }
                        //Console.WriteLine();
                    }
                    //Console.WriteLine($"{Name} {Surname}");
                    return cnt;
                }
            }

            //конструкторы
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _count = 0;
                _marks = new int[2, 5];
            }

            //методы
            public void Jump(int[] result)
            {
                if (result == null || result.Length == 0 || _marks == null)
                {
                    return;
                }
                if (_count > 1) return;
                for (int i = 0; i <= 4; i++)
                {
                    _marks[_count, i] = result[i];
                }
                _count++;

            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 1; j< array.Length - i; j++)
                    {
                        if (array[j].TotalScore > array[j - 1].TotalScore)
                        {
                            (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {TotalScore}");
            }
        }
    }
}
