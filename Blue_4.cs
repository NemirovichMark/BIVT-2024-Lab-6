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
        public struct Group
        {
            private string name;
            private Team[] teams;
            private int count;

            public string Name
            {
                get
                {
                    return name ?? string.Empty;
                }
            }

            public Team[] Teams
            {
                get
                {
                    if (teams == null)
                        return new Team[0];

                    Team[] result = new Team[count];
                    for (int i = 0; i < count; i++)
                    {
                        result[i] = teams[i];
                    }
                    return result;
                }
            }

            public Group(string name)
            {
                this.name = name;
                this.teams = new Team[10]; 
                this.count = 0;
            }

            public void Add(Team team)
            {
                if (team == null)
                    return;

                if (teams == null)
                {
                    teams = new Team[10];
                    count = 0;
                }
                
                if (count >= teams.Length)
                {
                    Team[] newTeams = new Team[teams.Length * 2];
                    for (int i = 0; i < teams.Length; i++)
                    {
                        newTeams[i] = teams[i];
                    }
                    teams = newTeams;
                }

                teams[count] = team;
                count++;
            }

            public void Add(params Team[] newTeams)
            {
                if (newTeams == null)
                    return;

                foreach (var team in newTeams)
                {
                    Add(team);
                }
            }

            public void Sort()
            {
                if (teams == null || count <= 1)
                    return;

                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        if (teams[i].TotalScore < teams[j].TotalScore)
                        {
                            Team temp = teams[i];
                            teams[i] = teams[j];
                            teams[j] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");
                
                group1.Sort();
                group2.Sort();

                int addedCount = 0;
                for (int i = 0; i < group1.count && addedCount < size; i++)
                {
                    finalists.Add(group1.teams[i]);
                    addedCount++;
                }

                for (int i = 0; i < group2.count && addedCount < size; i++)
                {
                    finalists.Add(group2.teams[i]);
                    addedCount++;
                }

                finalists.Sort();
                
                return finalists;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {name}");
                for (int i = 0; i < count; i++)
                {
                    teams[i].Print();
                }
            } // <-- Добавлена недостающая закрывающая скобка для метода Print()
        }

        public class Team
        {
            private string name;
            private int[] scores;
            private int count;

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
                        return new int[0];

                    int[] result = new int[count];
                    for (int i = 0; i < count; i++)
                    {
                        result[i] = scores[i];
                    }
                    return result;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null || count == 0)
                        return 0;

                    int sum = 0;
                    for (int i = 0; i < count; i++)
                    {
                        sum += scores[i];
                    }
                    return sum;
                }
            }

            public Team(string name)
            {
                this.name = name;
                this.scores = new int[10]; 
                this.count = 0;
            }

            public void PlayMatch(int result)
            {
                if (scores == null)
                {
                    scores = new int[10];
                    count = 0;
                }

                if (count >= scores.Length)
                {
                    int[] newScores = new int[scores.Length * 2];
                    for (int i = 0; i < scores.Length; i++)
                    {
                        newScores[i] = scores[i];
                    }
                    scores = newScores;
                }

                scores[count] = result;
                count++;
            }

            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                Console.Write("Scores: ");
                for (int i = 0; i < count; i++)
                {
                    Console.Write(scores[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        
        public Blue_4()
        {
            
        }
    }
}
