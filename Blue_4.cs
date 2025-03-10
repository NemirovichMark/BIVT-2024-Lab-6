using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;
            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null)
                    {
                        return null;
                    }
                    int cnt = 0;
                    int[] cp_scores = new int[_scores.Length];
                    Array.Copy(_scores, cp_scores, cp_scores.Length);
                    return cp_scores;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null)
                    {
                        return 0;
                    }
                    int cnt = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        cnt += _scores[i];
                    }
                    return cnt;
                }
            }
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (_scores == null)
                {
                    return;
                }
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {TotalScore}");
            }
        }
        public struct Group
        {
            private string _name;
            private int _num;
            private Team[] _teams;


            public string Name => _name;
            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _num = 0;
            }
            public void Add(Team team)
            {
                if (_teams == null)
                {
                    return;
                }

                if (_num < _teams.Length)
                {
                    _teams[_num] = team;
                    _num++;
                }
            }
            public void Add(Team[] teams)
            {
                if (teams.Length == 0 || _teams == null || teams == null)
                {
                    return;
                }

                for (int i = 0; i < teams.Length; i++)
                {
                    Add(teams[i]);
                }
            }
            public void Sort()
            {
                if (_teams == null)
                {
                    return;
                }
                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group merged = new Group("Финалисты");
                int i = 0, j = 0;
                while (i < size / 2 && j < size / 2)
                {
                    if (group1._teams[i].TotalScore >= group2._teams[j].TotalScore)
                    {
                        merged.Add(group1._teams[i]);
                        i++;
                    }
                    else
                    {
                        merged.Add(group2._teams[j]);
                        j++;
                    }
                }
                while (i < size / 2)
                {
                    merged.Add(group1._teams[i]);
                    i++;
                }
                while (j < size / 2)
                {
                    merged.Add(group2._teams[j]);
                    j++;
                }
                return merged;
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Teams}");
            }
        }
    }
}