using System;
using System.Linq;
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
                if (goals < 0) return;
                if (misses < 0) return;
                _goals = goals;
                _misses = misses;
            }
            public void Print()
            {
                Console.WriteLine($"{_goals} {_misses} {Score}");
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
                    if (_matches == null || _matches.Length == 0) return 0;
                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Score;
                    }
                    return total;
                }
            }
            public int TotalDifference
            {
                get
                {
                    if (_matches == null || _matches.Length == 0) return 0;
                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Difference;
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
                newMatches[newMatches.Length - 1] = newMatch;
                _matches = newMatches;
            }
            public static void SortTeams(Team[] teams)
            {
                if (teams == null) return;
                if (teams.Length == 0) return;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
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
                Console.WriteLine($"{_name} {TotalScore} {TotalDifference}");
            }
        }
    }
}