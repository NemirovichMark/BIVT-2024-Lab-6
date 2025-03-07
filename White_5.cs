using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class White_5
    {
        public struct Match
        {
            private int _goals;
            private int _misses;
            public int Goals => _goals;
            public int Misses => _misses;
            public int Difference => Goals - Misses;
            public int Score => Goals > Misses ? 3 : Goals == Misses ? 1 : 0;
            public Match(int goals, int misses)
            {
                _goals = goals;
                _misses = misses;
            }
        }
        public struct Team
        {
            private string _name;
            private Match[] _matches;
            public string Name => _name;
            public Match[] Matches => _matches;
            public int TotalScore
            {
                get 
                {
                    if (_matches == null || _matches.Length == 0)
                        return 0;

                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Score; //общая сумма очков
                    }
                    return total;
                }

            }
            public int TotalDifference
            {
                get
                {
                    if (_matches == null || _matches.Length == 0)
                        return 0;

                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Difference;//разница голов
                    }
                    return total;
                }
            }
            public Team(string name)

            {
                _name = name;
                _matches = new Match[0];
            }
            public void PlayMatch(int goals, int misses)
            {
                if (_matches == null) return;
                Match newMatch = new Match(goals, misses);
                Match[] newMatches = new Match[_matches.Length + 1];
                for (int i = 0; i < _matches.Length; i++)
                {
                    newMatches[i] = _matches[i];
                }
                // Добавляем новый матч в конец массива
                newMatches[newMatches.Length - 1] = newMatch;
                _matches = newMatches;
            }

            public static void SortTeams(Team[] teams)
            {
                if (teams == null)
                {
                    Console.WriteLine("Array of teams can't be null");
                    return;
                }
                if (teams.Length == 0)
                {
                    Console.WriteLine("Array of teams must not be empty");
                    return;
                }
                int l = teams.Length;
                for (int i = 0; i < l - 1; i++)
                {
                    for (int j = 0; j < l - i - 1; j++)
                    {
                        if ((teams[j].TotalScore < teams[j + 1].TotalScore) ||
                         (teams[j].TotalScore == teams[j + 1].TotalScore && teams[j].TotalDifference < teams[j + 1].TotalDifference))
                        {
                            Team tmp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = tmp;

                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Команда: {_name}, Очки: {TotalScore}, Разница голов: {TotalDifference}");
            }
        }
    }
}
