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
            private int[] _penaltyTimes;

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes => _penaltyTimes;

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
            }

            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null || _penaltyTimes.Length == 0) return 0;
                    int s = 0;
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        s += _penaltyTimes[i];
                    }
                    return s;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTimes == null) return false;
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        if (_penaltyTimes[i] == 10)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null || time == null) return;
                int[] new_points = new int[_penaltyTimes.Length + 1];
                Array.Copy(_penaltyTimes, new_points, _penaltyTimes.Length);
                new_points[_penaltyTimes.Length] = time;
                _penaltyTimes = new_points;
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
