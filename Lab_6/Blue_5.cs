namespace Lab_6;

public class Blue_5
{
    public struct Sportsman
    {
        private string _name;
        private string _lastname;
        private int _place;
        private bool isTrue;
        
        public readonly string Name => _name;
        public readonly string Surname => _lastname;
        public readonly int Place => _place;

        public Sportsman(string name, string lastname)
        {
            this._name = name;
            this._lastname = lastname;
            this._place = 0;
            this.isTrue = true;
        }

        public void SetPlace(int place)
        {
            if (isTrue)
            {
                this._place = place;
                this.isTrue = false;
            }
        }

        public void Print()
        {
            Console.WriteLine("{0} {1} {2}", Name, Surname, Place);
        }
    }
    public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;
            
            public readonly string Name => _name;
            public readonly Sportsman[] Sportsmen => this._sportsmen;

            public int SummaryScore
            {
                get
                {
                    if (this._sportsmen == null) return 0;
                    int summa = 0;
                    
                    foreach (var foo in this._sportsmen)
                    {
                        switch (foo.Place)
                        {
                            case 1: summa += 5; break;
                            case 2: summa += 4; break;
                            case 3: summa += 3; break;
                            case 4: summa += 2; break;
                            case 5: summa += 1; break;
                            default: summa += 0; break;
                        }

                    }

                    return summa;
                }
            }
            
            public int TopPlace
            {
                get
                {
                    if (this._sportsmen == null) return 0;
                    int foo = 18;
                    
                    for (int i = 0; i < this._count; i++) {
                        if (this._sportsmen[i].Place < foo) foo = this._sportsmen[i].Place;
                    }
                    
                    return foo;
                }
            }

            public Team(string name)
            {
                this._name = name;
                this._sportsmen = new Sportsman[6];
                this._count = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (this._sportsmen == null) return;
                if (this._count < 6)
                {
                    this._sportsmen[this._count] = sportsman;
                    this._count++;   
                }
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (this._sportsmen == null || sportsmen == null) return;

                for (int i = 0; i < sportsmen.Length; i++)
                { 
                    Add(sportsmen[i]);
                }

            }
            
            public static void Sort(Team[] teams)
            {
                if (teams == null) return;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if ((teams[j].SummaryScore < teams[j + 1].SummaryScore) || (teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace))
                        { 
                            Team temp = teams[j + 1];
                            teams[j + 1] = teams[j];
                            teams[j] = temp;
                        }
                    }
                }
                    
            }
            public void Print()
            {
                Console.WriteLine(Name);
            }
        }
}