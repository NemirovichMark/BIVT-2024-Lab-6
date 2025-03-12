using System.Linq;
using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            // поля
            private string _name;
            private int[] _scores;

            // свойства
            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;
                    int[] newScores = new int[_scores.Length];
                    Array.Copy(_scores, newScores, _scores.Length);
                    return newScores;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int s = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        s += _scores[i];
                    }
                    return s;
                }
            }

            // конструктор 
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            // методы
            public void PlayMatch(int result)
            {
                if (result == null) return;
                int[] newScores = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[newScores.Length - 1] = result;
                _scores = newScores;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {TotalScore}");
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;

            private int _count;

            public string Name => _name;
            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }

            public void Add(Team team)
            {
                if (_teams == null) return;
                if (_count < _teams.Length)
                {
                    _teams[_count] = team;
                    _count++;
                }
            }

            public void Add(Team[] teams)
            {
                if (_teams == null || teams == null || teams.Length == 0) return;
                for (int i = 0; i < teams.Length; i++)
                {
                    Add(teams[i]);
                }
            }

            public void Sort()
            {
                if (_teams == null) return;
                for (int i = 0; i < _teams.Length - 1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            Team newT = _teams[j + 1];
                            _teams[j + 1] = _teams[j];
                            _teams[j] = newT;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group newG = new Group("Финалисты");
                int i = 0;
                int j = 0;
                int k = 0;
                while (i < group1.Teams.Length && j < group2.Teams.Length)
                {
                    if (k == size) return newG;
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                       newG.Add(group1.Teams[i++]);
                    }
                    else
                    {
                       newG.Add(group2.Teams[j++]);
                    }
                }

                while (i < size / 2)
                {
                    newG.Add(group1._teams[i]);
                    i++;
                }
                while (j < size / 2)
                {
                    newG.Add(group2._teams[j]);
                    j++;
                }
                return newG;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}");
                for (int i = 0; i < _teams.Length; i++)
                {
                    _teams[i].Print();
                }
                Console.WriteLine("");
            }
        }
    }
}

