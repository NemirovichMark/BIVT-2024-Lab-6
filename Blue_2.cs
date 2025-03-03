using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int k;

            public string Name => _name;
            public string Surname => _surname;
            public int[,] Mark
            {
                get 
                {
                    int[,] copy = new int[2, 5];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                k = 0; 
            }

            public void Jump(int[] result)
            {
                if (result == null || _marks == null || _marks.GetLength(0) != 2 || _marks.GetLength(1) != 5 || result.Length != 5)
                {
                    return;
                }

                
                
                if (k > 1) return;
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        _marks[k, j] = result[j];
                    }
                    k++;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return;
                }

                
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            var temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
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