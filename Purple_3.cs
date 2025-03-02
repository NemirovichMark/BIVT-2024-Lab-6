using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Purple_3
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
                var participants_sort = participants.Where(r => r._marks != null && r._places != null).ToArray();
                for (int j = 0; j < 7; j++)
                {
                    participants_sort = participants_sort.OrderByDescending(r => r._marks[j]).ToArray();
                    for (int i = 0; i < participants_sort.Length; i++)
                    {
                        participants_sort[i]._places[j] = i+1;
                    }
                }
                participants_sort = participants_sort.Concat(participants_sort.Where(r => r._marks != null && r._places != null)).ToArray();
                Array.Copy(participants_sort, participants, participants_sort.Length);



            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0, j=1; i< array.Length;)
                {
                    if (i==0 || array[i].Score >= array[i - 1].Score)
                    {
                        i = j;
                        j++;
                    }
                    else if (array[i - 1].Score == array[i].Score &&
                             array[i - 1]._places.Min() <= array[i]._places.Min() &&
                             array[i - 1]._marks.Sum() >= array[i]._marks.Sum())
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        var temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        i--;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"name: {_name}\tsurname:{_surname}\tScore: {Score}\tbest place: {_places.Min()}, marks_sum:{Math.Round(_marks.Sum(),2)}");
            }

        }
    }
}