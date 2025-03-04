using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            // поля
            private string name;
            private int[] scores; 

            //свойства
            public string Name => name;
            public int[] Scores 
            { 
                get
                {
                    if (scores == null) return null;
                    int[] copyArray = new int[scores.Length];
                    Array.Copy(scores, copyArray, scores.Length);
                    return copyArray;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null) return 0; // Проверка на инициализацию
                    int total = 0;
                    foreach (int score in scores)
                    {
                        total += score;
                    }
                    return total;
                }
            }

            // Конструктор
            public Team(string name)
            {
                this.name = name;
                this.scores = new int[0]; 
            }

            // Методы
            public void PlayMatch(int result)
            {
                if(scores == null) return; // Проверка на инициализацию
                Array.Resize(ref scores, scores.Length + 1);
                scores[scores.Length - 1] = result;
            }
            public void Print()
            {
                Console.Write($"{Name} ");
                foreach (int score in scores)
                {
                    Console.Write($"{score} ");
                }
                Console.WriteLine();
            }
        }

        public struct Group
        {
            // поля
            private string name;
            private Team[] teams;
            private int index;

            // свойства
            public string Name => name;
            public Team[] Teams => teams;

            // Конструктор
            public Group(string name)
            {
                this.name = name;
                this.teams = new Team[12]; 
                this.index = 0;
            }

            // Методы
            public void Add(Team team)
            {
                if (teams == null) return; // Проверка на инициализацию
                if (index < teams.Length) 
                {
                    teams[index] = team;
                    index++;
                }
            }

            public void Add(params Team[] newTeams)
            {
                if (teams == null) return; // Проверка на инициализацию
                foreach (var team in newTeams)
                {
                    Add(team);
                }
            }

            public void Sort()
            {
                if (teams == null) return ; // Проверка на инициализацию
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length-1-i; j++)
                    {
                        if (teams[j].TotalScore < teams[j+1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j+1];
                            teams[j+1] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group finalists = new Group("Финалисты");

                int index1 = 0, index2 = 0;
                int halfSize = size / 2;

                while (index1 < halfSize && index2 < halfSize)
                {
                    if (group1.teams[index1].TotalScore >= group2.teams[index2].TotalScore)
                    {
                        finalists.Add(group1.teams[index1]);
                        index1++;
                    }
                    else
                    {
                        finalists.Add(group2.teams[index2]);
                        index2++;
                    }
                }

                while (index1 < halfSize)
                {
                    finalists.Add(group1.teams[index1]);
                    index1++;
                }

                while (index2 < halfSize)
                {
                    finalists.Add(group2.teams[index2]);
                    index2++;
                }

                return finalists;
            }


            // Метод
            public void Print()
            {
                Console.Write($"{Name}");
                foreach (var team in teams)
                {
                    team.Print();
                }
                Console.WriteLine();
            }
        }
    }
}
