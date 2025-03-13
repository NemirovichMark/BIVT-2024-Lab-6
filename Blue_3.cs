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
            // поля
            private string _name;
            private string _surname;
            public int[] _penaltyTime;

            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTime = new int[10];
                for(int i = 0; i < 10; i++)
                {
                    _penaltyTime[i] = -1;
                }
            }

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTime == null) return null;
                    int[] newArray = new int[_penaltyTime.Length];
                    Array.Copy(_penaltyTime, newArray, _penaltyTime.Length);
                    return newArray;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penaltyTime == null) return 0;
                    int s = 0;
                    for (int i = 0; i < _penaltyTime.Length; i++)
                    {
                        s += _penaltyTime[i];
                    }
                    return s;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTime == null) return false;
                    for (int i = 0; i < _penaltyTime.Length; i++)
                    {
                        if (_penaltyTime[i] == 10) return false;
                    }
                    return true;
                }
            }

            // методы
            public void PlayMatch(int time)
            {
                if (time == null || time < 0) return;

                for (int i = 0; i < 10; i++)
                {
                    if (_penaltyTime[i] == -1)
                    {
                        _penaltyTime[i] = time;
                        return;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i; j++)
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
