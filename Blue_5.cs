using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Lab_6.Blue_5;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string _Name;
            private string _Surname;
            private int _Place;
            private bool _State;


            public string Name { get { return _Name; } }
            public string Surname { get { return _Surname; } }
            public int Place { get { return _Place; } }
            public Sportsman(string name, string surname)
            {
                _Name = name;
                _Surname = surname;
                _Place = 0;
                _State = false;
            }
            public void SetPlace(int place)
            {
                if (_Place != 0) return;
                _Place = place;
                _State = true;
            }
            public void Print()
            {
                Console.WriteLine($"{_Name} {_Surname} {_Place}");
            }


        }
        public struct Team
        {
            private string _Name;
            private Sportsman[] _Sportsmen;
            private int _Count;

            public string Name { get { return _Name; } }
            public Sportsman[] Sportsmen { get { return _Sportsmen; } }

            public Team(string name)
            {
                _Name = name;
                _Sportsmen = new Sportsman[6];
                _Count = 0;
            }


            public int SummaryScore
            {
                get
                {
                    if (_Sportsmen == null || _Count == 0)
                        return 0;

                    int Score = 0;
                    for (int i = 0; i < _Count; i++)
                    {
                        int place = _Sportsmen[i].Place;

                        if (place == 1)
                        {
                            Score += 5;
                        }
                        else if (place == 2)
                        {
                            Score += 4;
                        }
                        else if (place == 3)
                        {
                            Score += 3;
                        }
                        else if (place == 4)
                        {
                            Score += 2;
                        }
                        else if (place == 5)
                        {
                            Score += 1;
                        }

                    }
                    return Score;
                }
            }
            public int TopPlace
            {
                get
                {
                    if (_Sportsmen == null)
                        return 0;

                    int TPlace = 18;
                    for (int i = 0; i < _Count; i++)
                    {
                        if (_Sportsmen[i].Place < TPlace)
                        {
                            TPlace = _Sportsmen[i].Place;
                        }
                    }
                    return TPlace;
                }
            }
            public void Add(Sportsman sportsman)
            {
                if (_Sportsmen == null)
                {
                    _Sportsmen = new Sportsman[6];
                }
                if (_Count < 6)
                {
                    _Sportsmen[_Count] = sportsman;
                    _Count++;
                }
            }
            public void Add(Sportsman[] sportsmen)
            {
                foreach (var sportsman in sportsmen)
                {
                    Add(sportsman);
                }
            }
            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0)return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore )
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                Team temp = teams[j];
                                teams[j] = teams[j + 1];
                                teams[j + 1] = temp;
                            }
                        }
                    }
                }

            }
            public void Print()
            {
                Console.WriteLine($"{_Name}: {SummaryScore}  {TopPlace}");
            }
        }
    }
}
