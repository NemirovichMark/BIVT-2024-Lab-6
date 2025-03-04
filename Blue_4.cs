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
        
        public Blue_4()
        {
            
        }
    }

    public class Team
    {
        private string name;
        private List<int> scores;  

        public string Name
        {
            get
            {
                if (name == null)
                    return null;
                return name;
            }
        }

        public int[] Scores
        {
            get
            {
                return scores.ToArray();  
            }
        }

        public int TotalScore
        {
            get
            {
                if (scores == null || scores.Count == 0)
                    return 0;
                return scores.Sum();  
            }
        }

        public Team(string name)
        {
            this.name = name;
            this.scores = new List<int>();  
        }

        public void PlayMatch(int result)
        {
            scores.Add(result);  
        }

        public void Print()
        {
            Console.Write("Name: ");
            Console.WriteLine(name);

            foreach (var score in scores)
            {
                Console.Write(score);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    public struct Group
    {
        private string name;
        private List<Team> teams;  

        public string Name
        {
            get
            {
                if (name == null)
                    return string.Empty;
                return name;
            }
        }

        public Team[] Teams
        {
            get
            {
                return teams.ToArray();  
            }
        }

        public Group(string name)
        {
            this.name = name;
            this.teams = new List<Team>();  
        }

        public void Add(Team team)
        {
            if (team == null)
                return;

            teams.Add(team);  
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
            
            teams.Sort((x, y) => y.TotalScore.CompareTo(x.TotalScore));
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
            foreach (var team in teams)
            {
                team.Print();
            }
        }
    }
}
