using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {

        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;
            private int _markIndex;

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _markIndex = 0;
            }

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    double[] marks = new double[_marks.Length];
                    Array.Copy(_marks, marks, _marks.Length);
                    return marks;
                }
            }

            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    int[] copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);

                    return copy;
                }
            }

            public int Score
            {
                get
                {
                    if (_places == null) return 0;

                    return _places.Sum();
                }
            }

            public void Evaluate(double result)
            {
                if (_markIndex >= 7 || _marks == null) return;
                _marks[_markIndex++] = result;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;

                for (int judge = 0; judge < 7; judge++)
                {
                    int validCount = 0;

                    foreach (Participant participant in participants)
                    {
                        if (participant.Marks != null && participant.Places != null) validCount++;
                    }

                    Participant[] valid = new Participant[validCount];
                    int index = 0;

                    foreach (Participant participant in participants)
                    {
                        if (participant.Marks != null && participant.Places != null) valid[index++] = participant;
                    }


                    for (int i = 1; i < valid.Length;)
                    {
                        
                        if (i == 0 || valid[i - 1].Marks[judge] >= valid[i].Marks[judge])
                        {
                            i++; 
                        }
                        else
                        {
                            Participant temp = valid[i - 1];
                            valid[i - 1] = valid[i];
                            valid[i] = temp;
                            i--; 
                        }
                    }

                    for (int i = 0; i < validCount; i++)
                    {
                        valid[i]._places[judge] = i + 1;
                    }

                    if (judge == 6)
                    {
                        index = valid.Length;
                        Participant[] res = new Participant[participants.Length];
                        Array.Copy(valid, res, valid.Length);

                        foreach (var participant in participants)
                        {
                            if (participant.Marks == null) res[index++] = participant;
                        }

                        Array.Copy(res, participants, participants.Length);
                    }
                }
            }




            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 1; i < array.Length;)
                {

                    Participant current = array[i];
                    Participant previous = array[i - 1];

                    bool currentIsNull = current._places == null || current._marks == null;
                    bool prevIsNull = previous._places == null || previous._marks == null;

                    if (prevIsNull && !currentIsNull)
                    {
                        (array[i - 1], array[i]) = (current, previous);
                        if (i > 1) i--; 
                        continue;
                    }

                    if (!currentIsNull && !prevIsNull)
                    {
                        if (current.Score < previous.Score)
                        {
                            (array[i - 1], array[i]) = (current, previous);
                            if (i > 1) i--;
                            continue;
                        }
                        else if (current.Score == previous.Score)
                        {
                            int currentMinPlace = current._places.Min();
                            int prevMinPlace = previous._places.Min();

                            if (currentMinPlace > prevMinPlace)
                            {
                                (array[i - 1], array[i]) = (current, previous);
                                if (i > 1) i--;
                                continue;
                            }
                            else if (currentMinPlace == prevMinPlace)
                            {

                                double currentSum = current._marks.Sum();
                                double prevSum = previous._marks.Sum();

                                if (currentSum < prevSum)
                                {
                                    (array[i - 1], array[i]) = (current, previous);
                                    if (i > 1) i--;
                                    continue;
                                }
                            }
                        }
                    }



                    i++;
                }
            }



         public void Print()
            {

                Console.Write($"{Name} {Surname}:  ");
                if (Places != null && Places.Length > 0)
                {
                    Console.Write($"{Places.Sum()} ");
                    Console.Write($"{Places.Min()} ");
                }

                //else
                //{
                //    Console.Write("nul null");
                //}

                if (Marks != null && Marks.Length > 0)
                {
                    Console.Write($"{Marks.Sum():F2}");
                }
                //else
                //{
                //    Console.Write("null");
                //}

                Console.WriteLine();
            }





        }
    }
}
