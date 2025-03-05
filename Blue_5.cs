using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name { get => _name; }
            public string Surname { get => _surname; }
            public int Place { get => _place; }

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                _place = place;
            }


            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Place}");
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _k;

            public string Name { get => _name; }
            public Sportsman[] Sportsmen { get => _sportsmen; }

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _k == 0) return 0;
                    int score = 0;
                    foreach (var s in _sportsmen)
                    {
                        switch (s.Place)
                        {
                            case 1: score += 5; break;
                            case 2: score += 4; break;
                            case 3: score += 3; break;
                            case 4: score += 2; break;
                            case 5: score += 1; break;
                            default: break;
                        }
                    }
                    return score;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;

                    int topPlace = 18;
                    foreach (var s in _sportsmen)
                    {
                        if (s.Place < topPlace) topPlace = s.Place;
                    }
                    return topPlace;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _k = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null || _k >= 6) return;

                if (_k < 6)
                {
                    _sportsmen[_k] = sportsman;
                    _k++;
                }
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null || _k >= 6) return;

                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    if (_k >= 6) return;
                    if (_k < 6)
                    {
                        _sportsmen[_k++] = sportsmen[i];
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name}");
                Console.WriteLine("Состав команды:");
                foreach (var s in _sportsmen)
                {
                    s.Print();
                }
                Console.WriteLine($"Общее количество баллов: {SummaryScore}");
                Console.WriteLine($"Лучшее место: {TopPlace}\n");
            }

            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore ||
                            teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace)
                        {
                            Team x = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = x;
                        }
                    }
                }
            }
        }

    }
}
