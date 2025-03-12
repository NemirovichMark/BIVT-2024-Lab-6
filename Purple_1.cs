using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {

            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _count;
            private double _total;


            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _count = 0;
                _total = 0;
            }

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] temp = new double[4];
                    for (int i = 0; i < 4; i++)
                    {
                        temp[i] = _coefs[i];
                    }
                    return temp;
                }
            }
            public double TotalScore { get { return _total; } }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] temp = new int[4, 7];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            temp[i, j] = _marks[i, j];
                        }
                    }

                    return temp;
                }
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || _coefs == null || coefs.Length != 4) { return; }
                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }

            public void Jump(int[] marks)
            {
                if (marks == null || _marks == null || _coefs == null || _count >= 4 || marks.Length != 7) return;
                for (int i = 0; i < 7; i++)
                {
                    _marks[_count, i] = marks[i];
                }
                int[] arr = new int[7];
                for (int i = 0; i < 7; i++) { arr[i] = marks[i]; }
                Array.Sort(arr);
                for (int i = 1; i < 6; i++)
                {
                    _total += arr[i] * _coefs[_count];
                }
                _count++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) { return; }

                for (int i = 1; i < array.Length;)
                {
                    if (i == 0 || array[i - 1].TotalScore >= array[i].TotalScore)
                    {
                        i++;
                    }
                    else
                    {
                        Participant tmp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = tmp;
                        i--;
                    }
                }

            }

            public void Print()
            {
                Console.WriteLine($"Name: {Name}\nSurname: {Surname}\nTotal: {TotalScore}");

            }

        }

    }

}

