using System;

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
            private int _nomber;

            public string Name => _name;
            public string Surname => _surname;

            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    double[] marks = new double[_marks.Length];
                    Array.Copy(_marks, marks, marks.Length);
                    return marks;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    int[] Places = new int[_places.Length];
                    for (int i = 0; i < Places.Length; i++)
                    {
                        Places[i] = _places[i];
                    }
                    return Places;
                }
            }
            public int Score
            {
                get
                {
                    if (_places == null || _places.Length == 0) return 0;
                    int Score = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        Score += _places[i];
                    }
                    return Score;
                }
            }
            private int Max
            {
                get
                {
                    if (_places == null || _places.Length == 0) return 0;
                    int Max = int.MaxValue;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        if (_places[i] < Max) Max = _places[i];
                    }
                    return Max;
                }
            }
            public double TotalMark
            {
                get
                {
                    if (_marks == null) return 0;
                    double TotalMark = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        TotalMark += _marks[i];

                    }

                    return TotalMark;
                }
            }


            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _nomber = 0;

            }
            public void Evaluate(double result)
            {

                if (_nomber == _marks.Length) return;
                if (_marks == null) return;
                _marks[_nomber] = result;

                _nomber++;
            }
            public static void SetPlaces(Participant[] participants)
            {


                for (int j = 0; j < 7; j++)
                {


                    for (int i = 1; i < participants.Length;)
                    {
                        if (i == 0 || participants[i]._marks[j] >= participants[i - 1]._marks[j])
                        {
                            i++;
                        }
                        else
                        {

                            Participant temp1 = participants[i];
                            participants[i] = participants[i - 1];
                            participants[i - 1] = temp1;
                            i--;
                        }
                    }
                    for (int i = 0; i < participants.Length; i++)
                    {
                        participants[i]._places[j] = 10-i;
                    }
                }
            }
            public static void Sort(Participant[] array)
            {

                if (array == null || array.Length == 0) return;
                for (int i = 1; i < array.Length;)
                {
                    
                    if (i == 0 || array[i].Score >= array[i - 1].Score)
                    {
                        i++;
                        
                    }
                    else if (array[i].Score == array[i - 1].Score)
                    {
                        int _1 = 0;
                        int _2 = 0;
                        for (int j = 0; j < 7; j++)
                        {
                            if (array[i]._places[j] > array[i - 1]._places[j])
                            {
                                _1++;
                            }
                            else if (array[i]._places[j] < array[i - 1]._places[j])
                            {
                                _2++;
                            }
                        }
                        if (_1 > _2)
                        {
                            Participant temp1 = array[i];
                            array[i] = array[i - 1];
                            array[i - 1] = temp1;
                            i--;
                        }
                        else if (_2 > _1)
                        {
                            i++;
                        }
                        else
                        {
                            if (array[i].TotalMark < array[i - 1].TotalMark)
                            {
                                i++;
                            }
                            else
                            {
                                Participant temp1 = array[i];
                                array[i] = array[i - 1];
                                array[i - 1] = temp1;
                                i--;
                            }
                        }
                    }

                    else
                    {
                        Participant temp1 = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp1;
                        i--;
                        
                    }
                    
                }
            }
            public void Print()
            {
                Console.Write(_name + " ");
                Console.Write(_surname + " ");
                Console.Write(Score + " ");
                Console.Write(Max + " ");
                Console.WriteLine(TotalMark);
            }
        }
    }
}
