using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _Name;
            private int[] _Scores;

            public string Name { get { return _Name; } }
            public int[] Scores
            {
                get
                {
                    if (_Scores == null) return null;
                    int[] Nscores = new int[_Scores.Length];
                    for (int i = 0; i < Nscores.Length; i++)
                    {
                        Nscores[i] = _Scores[i];
                    }
                    return Nscores;
                }
            }

            public Team(string name)
            {
                _Name = name;
                _Scores = new int[0];
            }

            public int TotalScore
            {
                get
                {
                    if (_Scores == null) return 0;
                    int ts = 0;
                    for (int i = 0; i < _Scores.Length; i++)
                    {
                        ts += _Scores[i];
                    }
                    return ts;
                }
            }

            public void PlayMatch(int result)
            {
                int[] NScores = new int[_Scores.Length+1];
                for (int i = 0;i < _Scores.Length;i++)
                {
                    NScores[i] = _Scores[i];
                }
                NScores[NScores.Length - 1] = result;
                _Scores = NScores;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}: {TotalScore}");
            }

        }

        public struct Group
        {
            private string _Name;
            private Team[] _Teams;
            private int _AdTeams;

            public string Name { get { return _Name; } }
            public Team[] Teams { get { return _Teams; } }
            public Group(string name)
            {
                _Name = name;
                _Teams = new Team[12];
                _AdTeams = 0;
            }
            public void Add(Team team)
            {
                if ((_AdTeams >= 12)|| (_Teams == null)) return;

                else
                {
                    _Teams[_AdTeams] = team;
                    _AdTeams++;
                }
            }
            public void Add(Team[] teams)
            {
                if (_Teams == null || teams.Length == 0 || teams == null) return;

                for (int i = 0; i < teams.Length; i++)
                {
                    Add(teams[i]);
                }
            }
            public void Sort()
            {
                if (_Teams == null || _Teams.Length == 0) return;
                for (int i = 0; i < _Teams.Length - 1; i++)
                {
                    for (int j = 0; j < _Teams.Length - i - 1; j++)
                    {
                        if (_Teams[j].TotalScore < _Teams[j + 1].TotalScore)
                        {
                            Team temp = _Teams[j];
                            _Teams[j] = _Teams[j + 1];
                            _Teams[j + 1] = temp;
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group ngroup = new Group("Финалисты");
                int i = 0;
                int j = 0; 
                int k = 0; 

                while (i < group1.Teams.Length && j < group2.Teams.Length && k < size)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        ngroup.Add(group1.Teams[i++]);
                    }
                    else
                    {
                        ngroup.Add(group2.Teams[j++]);
                    }
                    k++;
                }

                
                while (i < group1.Teams.Length && k < size)
                {
                    ngroup.Add(group1.Teams[i++]);
                    k++;
                }

                
                while (j < group2.Teams.Length && k < size)
                {
                    ngroup.Add(group2.Teams[j++]);
                    k++;
                }

                return ngroup;

            }

            public void Print()
            {
                Console.WriteLine($"Group {_Name}");
                Console.WriteLine("Teams");
                for (int i = 0; i < _Teams.Length; i++)
                {
                    _Teams[i].Print();
                }


            }

        }

    }

}
