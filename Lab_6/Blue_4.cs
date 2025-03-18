namespace Lab_6;

public class Blue_4
{
    public struct Team
    {
        private string _name;
        private int[] _counts;

        public readonly string Name => _name;

        public readonly int[] Scores
        {
            get
            {
                if (this._counts == null) return null;
                int[] arr = new int[this._counts.Length];

                for (int i = 0; i < this._counts.Length; i++)
                {
                    arr[i] = this._counts[i];
                }

                return arr;
            }
        }

        public int TotalScore
        {
            get
            {
                if (this._counts == null) return 0;
                int res = 0;

                for (int i = 0; i < this._counts.Length; i++)
                {
                    res += this._counts[i];
                }

                return res;
            }
        }

        public Team(string name)
        {
            this._name = name;
            this._counts = new int[0];
        }

        public void PlayMatch(int result)
        {
            if (this._counts == null) return;
            Array.Resize(ref this._counts, this._counts.Length + 1);
            this._counts[this._counts.Length - 1] = result;
        }

        public void Print()
        {
            Console.WriteLine(this.Name, this.TotalScore);
        }
    }

    public struct Group
    {
        private string _name;
        private Team[] _teams;
        private int _count;
        
        public readonly string Name => _name;
        public readonly Team[] Teams => this._teams;

        public Group(string name)
        {
            this._name = name;
            this._teams = new Team[12];
            this._count = 0;
        }

        public void Add(Team team)
        {
            if (this._teams == null) return;

            if (this._count < 12)
            {
                this._teams[this._count] = team;
                this._count++;
            }
        }

        public void Add(Team[] teams)
        {
            if (this._teams == null || teams == null) return;
            
            Team[] arr = new Team[this._teams.Length + teams.Length];
            
            for (int i = 0; i < 12; i++)
            {
                Add(teams[i]);
            }
        }

        public void Sort()
        {
            if (this._teams == null) return;
            for (int i = 0; i < this._teams.Length - 1; i++)
            {
                for (int j = 0; j < this._teams.Length - i - 1; j++)
                {
                    if (this._teams[j + 1].TotalScore > this._teams[j].TotalScore)
                    {
                        Team temp = this._teams[j + 1];
                        this._teams[j + 1] = this._teams[j];
                        this._teams[j] = temp;
                    }
                }
            }
        }

        public static Group Merge(Group group1, Group group2, int size)
        {
            if (group1.Teams == null || group2.Teams == null || size <= 0) return new Group();
            Group group = new Group("Финалисты");
            group1.Sort();
            group2.Sort();
            
            int foo1 = 0;
            int foo2 = 0;

            while (foo1 < size / 2 && foo2 < size / 2)
            {
                if (group1.Teams[foo1].TotalScore >= group2.Teams[foo2].TotalScore)
                {
                    group.Add(group1.Teams[foo1]);
                    foo1++;
                }
                else
                {
                    group.Add(group2.Teams[foo2]);
                    foo2++;
                }
            }
            
            while (foo1 < size / 2)
            {
                group.Add(group1.Teams[foo1]);
                foo1++;
                    
            }

            while (foo2 < size / 2)
            {
                group.Add(group2.Teams[foo2]);
                foo2++;
                    
            }
            
            return group;
        }

        public void Print()
        {
            Console.WriteLine(Name);
        }
    }
}