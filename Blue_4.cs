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
            private string name;
            private int[] scores;

            public string Name
            {
                get
                {
                    return name;
                }
            }

            public int[] Scores
            {
                get
                {
                    if (scores == null)
                        return null;
                    int[] copy = new int[scores.Length];
                    Array.Copy(scores, copy, copy.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null)
                        return 0;

                    int sum = 0;
                    foreach (int v in scores)
                    {
                        sum += v;
                    }
                    return sum;
                }
            }

            public Team(string name)
            {
                this.name = name;
                this.scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (scores == null) 
                    return;

                int[] newScores = new int[scores.Length + 1];

                for (int i = 0; i < scores.Length; i++)
                {
                    newScores[i] = scores[i];
                }
                newScores[newScores.Length - 1] = result;
                scores = newScores;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}: {TotalScore}");
            }
        }

        public struct Group
        {
            private string name;
            private Team[] teams;
            private int ind;
            public string Name
            {
                get
                {
                    return name;
                }
            }

            public Team[] Teams
            {
                get
                {
                    if (teams == null)
                        return null;
                    return teams;
                }
            }

            public Group(string name)
            {
                this.name = name;
                this.teams = new Team[12];
                ind = 0;
            }

            public void Add(Team team)
            {
                if (teams == null)
                    return;

                for (int i = 0; i < teams.Length; i++)
                {
                    if (teams[i].Name == null)
                    {
                        teams[i] = team;
                        break;
                    }
                }
            }

            public void Add(params Team[] newTeams)
            {
                if (teams == null || teams.Length == 0 || teams == null)
                    return;

                for (int i = 0; i < newTeams.Length; i++)
                {
                    Add(newTeams[i]);
                }
            }

            public void Sort()
            {
                if (teams == null || teams.Length == 0)
                    return;

                int n = teams.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");

                foreach (var team in group1.Teams)
                {
                    if (finalists.Teams.Length < size)
                    {
                        finalists.Add(team);
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (var team in group2.Teams)
                {
                    if (finalists.Teams.Length < size)
                    {
                        finalists.Add(team);
                    }
                    else
                    {
                        break;
                    }
                }

                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {name}");
                Console.WriteLine("Команды:");

                if (teams != null && teams.Length > 0)
                {
                    for (int i = 0; i < teams.Length; i++)
                    {
                        Console.WriteLine($"Команда {i + 1}");
                        teams[i].Print();
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о командах.");
                }
            }
        }
    }
}
