using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string _Name;
            private string _Surname;
            private int[,] _Marks;
            private int _JNumber;

            public string Name { get { return _Name; } }
            public string Surname { get { return _Surname; } }

            public int[,] Marks
            {
                get
                {
                    if (_Marks == null || _Marks.GetLength(0) < 1 || _Marks.GetLength(1) < 1) return null;
                    int[,] NMarks = new int[_Marks.GetLength(0), _Marks.GetLength(1)];
                    for (int i = 0; i < _Marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _Marks.GetLength(1); j++)
                        {
                            NMarks[i, j] = _Marks[i, j];
                        }
                    }
                    return NMarks;
                }
            }

            public Participant (string Name1, string Surname1)
            {
                _Name = Name1;
                _Surname = Surname1;
                _Marks = new int[2, 5];
                _JNumber = 0;
            }

            public int TotalScore
            {
                get
                {
                    if (_Marks == null || _Marks.GetLength(0) < 1 || _Marks.GetLength(1) < 1)
                        return 0;
                    int sum = 0;
                    for(int i = 0; i < _Marks.GetLength(0); i++)
                        for (int j = 0; j < _Marks.GetLength(1); j++)
                        {
                            sum += _Marks[i, j];
                        }
                    return sum;
                }
            }

            public void Jump(int[] result)
            {
                if (_Marks == null || _Marks.GetLength(0) == 0 || _Marks.GetLength(1) == 0 || result == null || result.Length == 0 ) return;
                if (_JNumber == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _Marks[0, i] = result[i];
                    }
                    _JNumber++;
                }
                else if (_JNumber == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        _Marks[1, i] = result[i];
                    }
                    _JNumber++;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array.Length < 0) return;
                for (int i = 0; i < array.Length; i++)
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
                Console.WriteLine();
                Console.WriteLine($"Participant: {_Name} {_Surname}");
                for (int i = 0; i < _Marks.GetLength(0); i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < _Marks.GetLength(1); j++)
                    {
                        Console.Write($"{_Marks[i, j]} ");
                    }
                    
                }
                Console.WriteLine();
      
                Console.WriteLine(TotalScore);

            }


        }
    }
}
