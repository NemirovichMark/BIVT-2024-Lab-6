using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            private bool ind;

            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public string Surname
            {
                get
                {
                    if (surname == null)
                        return null;
                    return surname;
                }
            }

            public int Place
            {
                get
                {
                    if (place == 0)
                        return 0;
                    return place;
                }
            }


            public Sportsman(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.place = 0;
                this.ind = false;
            }


            public void SetPlace(int place)
            {
                if (place != 0)
                {
                    Console.WriteLine("Место установлено ранее");
                    return;
                }
                this.place = place;
                this.ind = true;
            }
            public void Print()
            {
                Console.WriteLine($"Спортсмен: {name} {surname}, Место: {place}");
            }
        }

        public struct Team
        {

            private string name;
            private Sportsman[] sportsmen;
            private int count;

            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public Sportsman[] Sportsmen
            {
                get
                {
                    if (sportsmen == null)
                        return null;
                    return sportsmen;
                }
            }


            public int SummaryScore
            {
                get
                {
                    if (sportsmen == null || sportsmen.Length == 0)
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
                    if (sportsmen == null|| sportsmen.Length == 0)
                        return 0;

                    int top = 18;
                    foreach (var sportsman in sportsmen)
                    {
                        if (sportsman.Place < top && sportsman.Place != 0)
                        {
                            top = sportsman.Place;
                        }
                    }
                    return top;
                }
            }

            public Team(string name)
            {
                this.name = name;
                this.sportsmen = new Sportsman[6];
                this.count = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (count < 6)
                {
                    sportsmen[count] = sportsman;
                    count++;
                }
            }

            public void Add(params Sportsman[] newSportsmen)
            {
                if (sportsmen == null)
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
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore)
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                Team temp = teams[j];
                                teams[j] = teams[j + 1];
                                teams[j + 1] = temp;
                            }
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Команда: {name}");
                Console.WriteLine($"Суммарный балл: {SummaryScore}");
                Console.WriteLine($"Наивысшее место: {TopPlace}");
                Console.WriteLine("Спортсмены:");

                if (sportsmen != null && sportsmen.Length > 0)
                {
                    for (int i = 0; i < sportsmen.Length; i++)
                    {
                        sportsmen[i].Print();
                    }
                }
                else
                {
                    Console.WriteLine("Нет информации");
                }
            }
        }
    }
}
