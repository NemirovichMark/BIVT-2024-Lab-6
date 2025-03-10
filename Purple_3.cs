using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

            private int index;


            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null)
                    {
                        return null;
                    }
                    var copy = new double[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null)
                    {
                        return null;
                    }
                    var copy = new int[_places.Length];
                    Array.Copy(_places, copy, _places.Length);
                    return copy;
                }
            }
            public int Score => _places == null ? 0:_places.Sum();

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;

                _marks = new double[7];
                _places = new int[7];
                index = 0;

            }

            public void Evaluate(double result)
            {
                if (index >= 7 || result==null || _marks == null) return;
                _marks[index++] = result;
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                var participants_sort = new Participant[participants.Length];
                participants_sort = participants.Where(r => r._marks != null && r._places != null).ToArray();
                for (int j = 0; j < 7; j++)
                {
                    participants_sort = participants.OrderByDescending(r => r._marks[j]).ToArray();
                    for (int i = 0; i < participants_sort.Length; i++)
                    {
                        participants_sort[i]._places[j] = i+1;
                    }
                }
                participants_sort = participants_sort.Concat(participants.Where(r => r._marks == null && r._places == null)).ToArray();
                Array.Copy(participants_sort, participants, participants_sort.Length);



            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                var res = array.Where(r => r._marks != null && r._places != null).ToArray();
                for (int i = 0, j=1; i< res.Length;)
                {
                    if (i==0 || res[i].Score > res[i - 1].Score)
                    {
                        i = j;
                        j++;
                    }
                    else if(res[i].Score == res[i - 1].Score)
                    {
                        if (i == 0 || res[i].TopPlace(res[i]) > res[i - 1].TopPlace(res[i - 1]))
                        {
                            i = j;
                            j++;
                        }
                        else if(res[i].TopPlace(res[i]) == res[i - 1].TopPlace(res[i - 1]))
                        {
                            if (i == 0 || res[i]._marks.Sum() > res[i - 1]._marks.Sum())
                            {
                                i = j;
                                j++;
                            }
                            else
                            {
                                var temp = res[i];
                                res[i] = res[i - 1];
                                res[i - 1] = temp;
                                i--;
                            }
                        }
                        else
                        {
                            var temp = res[i];
                            res[i] = res[i - 1];
                            res[i - 1] = temp;
                            i--;
                        }
                    }
                    else
                    {
                        var temp = res[i];
                        res[i] = res[i - 1];
                        res[i - 1] = temp;
                        i--;
                    }
                }
               res = res.Concat(array.Where(r => r._marks == null || r._places == null)).ToArray();
               Array.Copy(res, array, res.Length);
            }
            private int TopPlace(Participant participant)
            {
                int[] places = participant.Places;
                return places.Max();
            }
            public void Print()
            {
                Console.WriteLine($"name: {_name}\tsurname:{_surname}\tScore: {Score}\tbest place: {_places.Min()}\t marks_sum:{Math.Round(_marks.Sum(),2)}");
            }

        }
    }
}
