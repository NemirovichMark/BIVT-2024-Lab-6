using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _points;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Points => _points;

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _points = new int[0];
            }

            public int TotalTime
            {
                get
                {
                    if (_points == null || _points.Length == 0) return 0;
                    int s = 0;
                    for (int i = 0; i < _points.Length; i++)
                    {
                        s += _points[i];
                    }
                    return s;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_points == null) return false;
                    for (int i = 0; i < _points.Length; i++)
                    {
                        if (_points[i] == 10)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public void PlayMatch(int time)
            {
                if (_points == null || time == null) return;
                int[] new_points = new int[_points.Length + 1];
                Array.Copy(_points, new_points, _points.Length);
                new_points[_points.Length] = time;
                _points = new_points;
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
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
                Console.WriteLine($"{_name} {_surname} {TotalTime} {IsExpelled}");
            }
        }
    }
}
