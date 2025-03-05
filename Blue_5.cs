using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_5;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string name;
            private string surname;
            private int place;

            public string Name
            {
                get
                {
                    return name ?? string.Empty; 
                }
            }

            public string Surname
            {
                get
                {
                    return surname ?? string.Empty; 
                }
            }

            public int Place
            {
                get
                {
                    return place == 0 ? 0 : place; 
                }
            }

            public Sportsman(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.place = 0;
            }

            public void SetPlace(int place)
            {
                this.place = place;
            }

            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                Console.Write("Surname: ");
                Console.WriteLine(surname);

                Console.Write("Place: ");
                Console.WriteLine(place);
            }
        }

        public struct Team
        {
            private string name;
            private List<Sportsman> sportsmen;

            public string Name
            {
                get
                {
                    return name ?? string.Empty; 
                }
            }

            public Sportsman[] Sportsmen
            {
                get
                {
                    return sportsmen?.ToArray() ?? new Sportsman[0]; 
                }
            }

            public int SummaryScore
            {
                get
                {
                    if (sportsmen == null)
                        return 0;

                    int total = 0;
                    foreach (var s in sportsmen)
                    {
                        switch (s.Place)
                        {
                            case 1: total += 5; break;
                            case 2: total += 4; break;
                            case 3: total += 3; break;
                            case 4: total += 2; break;
                            case 5: total += 1; break;
                            default: total += 0; break;
                        }
                    }
                    return total;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (sportsmen == null || sportsmen.Count == 0)
                        return 18;

                    int top = int.MaxValue;
                    foreach (var sportsman in sportsmen)
                    {
                        if (sportsman.Place > 0 && sportsman.Place < top)
                        {
                            top = sportsman.Place;
                        }
                    }
                    return top == int.MaxValue ? 18 : top;
                }
            }

            public Team(string name)
            {
                this.name = name;
                this.sportsmen = new List<Sportsman>();
            }

            public void Add(Sportsman sportsman)
            {
                if (sportsman.Name == string.Empty) 
                    return;

                sportsmen.Add(sportsman);
            }

            public void Add(params Sportsman[] newSportsmen)
            {
                if (newSportsmen == null || newSportsmen.Length == 0)
                    return;

                foreach (var sportsman in newSportsmen)
                {
                    Add(sportsman);
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0)
                    return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = i + 1; j < teams.Length; j++)
                    {
                        if (teams[i].SummaryScore < teams[j].SummaryScore ||
                            (teams[i].SummaryScore == teams[j].SummaryScore && teams[i].TopPlace > teams[j].TopPlace))
                        {
                            Team temp = teams[i];
                            teams[i] = teams[j];
                            teams[j] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name}");
                foreach (var sportsman in sportsmen)
                {
                    sportsman.Print();
                }
                Console.WriteLine($"Суммарный балл: {SummaryScore}, Наивысшее место: {TopPlace}");
            }
        }
    }
}
