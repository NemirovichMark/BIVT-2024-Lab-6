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
                    Array.Copy(_marks, marks, _marks.Length);
                    return marks;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    int[] places = new int[_places.Length];
                    Array.Copy(_places, places, _places.Length);
                    return places;
                }
            }
            public int Score
            {
                get
                {
                    if (_places == null || _places.Length == 0) return 0;
                    int score = 0;
                    for (int i = 0; i < _places.Length; i++)
                    {
                        score += _places[i];
                    }
                    return score;
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
            private double TotalMark
            {
                get
                {
                    if (_marks == null || _marks.Length != 7) return 0;
                    double Totalmark = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        Totalmark += _marks[i];

                    }

                    return Totalmark;
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

                if (_nomber >= _marks.Length) return;
                if (_marks == null || _marks.Length == 0 || result < 0||result>6) return;
                _marks[_nomber] = result;

                _nomber++;
            }
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                Participant[] participants1 = new Participant[participants.Length];
                int k = 0;
                for (int i = 0; i < participants.Length; i++)
                {
                    if (participants[i]._places == null || participants[i]._marks == null)
                    {
                        Array.Resize(ref participants1, participants1.Length - 1);
                    }
                    else
                    {
                        participants1[k] = participants[i];
                        k++;
                    }
                }
                for (int j = 0; j < 7; j++)
                {


                    for (int i = 1; i < participants1.Length;)
                    {
                        if (i == 0 || participants1[i]._marks[j] <= participants1[i - 1]._marks[j])
                        {
                            i++;
                        }
                        else
                        {

                            Participant temp1 = participants1[i];
                            participants1[i] = participants1[i - 1];
                            participants1[i - 1] = temp1;
                            i--;
                        }
                    }
                    for (int i = 0; i < participants1.Length; i++)
                    {
                        participants1[i]._places[j] = 1+i;
                    }
                }
                Participant[] participants2 = new Participant[participants.Length];
                
               
                int m = participants1.Length;
                for(int i = 0; i < participants1.Length; i++)
                {
                    participants2[i] = participants1[i];
                    
                }
                for (int i = 0; i < participants.Length; i++)
                {
                    if (participants[i]._places == null || participants[i]._marks == null)
                    {
                        participants2[m] = participants[i];
                        m++;
                    }
                }
                Array.Copy(participants2,participants,participants2.Length);
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
                            i++;
                        }
                        else if (_2 > _1)
                        {
                            Participant temp1 = array[i];
                            array[i] = array[i - 1];
                            array[i - 1] = temp1;
                            i--;
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
