using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string _Name;
            private string _Surname;
            private int[] _PenaltyTimes;

            public string Name { get { return _Name; } }
            public string Surname { get { return _Surname; } }

            public int[] PenaltyTimes
            {
                get
                {
                    if (_PenaltyTimes == null) return null;
                    int[] NPenaltyTimes = new int[_PenaltyTimes.Length];
                    for (int i = 0; i < _PenaltyTimes.Length; i++)
                    {
                        NPenaltyTimes[i] = _PenaltyTimes[i];
                    }
                    return NPenaltyTimes;

                }
            }

            public Participant (string Name1, string Surname1)
            {
                _Name = Name1;
                _Surname = Surname1;
                _PenaltyTimes = new int[0];
            }

            public int TotalTime 
            {
                get
                {
                    if (_PenaltyTimes == null) return 0;
                    int TT = 0;
                    for (int i = 0; i < _PenaltyTimes.Length; ++i)
                    {
                        TT += _PenaltyTimes[i];
                    }
                    return TT;
                }
            }

            public bool IsExpelled
            {
                get 
                {
                    if (_PenaltyTimes == null) return true;
                    bool expelled = true;
                    for (int i = 0; i  < _PenaltyTimes.Length; i++)
                    {
                        if (_PenaltyTimes[i] == 10)
                        {
                            expelled = false;
                            return expelled;
                        }
                    }
                    return expelled;
                }
            }
            public void PlayMatch(int time)
            {
                if (_PenaltyTimes == null) return;
                int[] newPenaltyTimes = new int[_PenaltyTimes.Length + 1];
                for (int i = 0; i < _PenaltyTimes.Length; i++)
                {
                    newPenaltyTimes[i] = _PenaltyTimes[i];
                }
                _PenaltyTimes = newPenaltyTimes;
                _PenaltyTimes[_PenaltyTimes.Length-1] = time;
            }

            public static void Sort(Participant[] array)
            {
                if (array.Length < 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
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
                Console.WriteLine($"{_Name} {_Surname} : {TotalTime} {IsExpelled}");
                for (int i = 0; i < _PenaltyTimes.Length; i++)
                {
                    Console.WriteLine(_PenaltyTimes[i]);
                }
                Console.WriteLine();
            }
        }
    }
}
