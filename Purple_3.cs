﻿using System;
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
            private string _name, _surname;
            private double[] _marks;
            private int[] _places;
            private int _indexJudge;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    return (double[])_marks.Clone();
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    return (int[])_places.Clone();
                }
            }
            public int Score
            {
                get
                {
                    if (_places == null) return 0;
                    int s = 0;
                    for (int i = 0; i < _places.Length; i++) s += _places[i];
                    return s;
                }
            }
            public Participant(string name, string surname) {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
                _indexJudge = 0;
            }
            public void Evaluate(double result)
            {
                if (_indexJudge >= 7) return;
                if (_marks == null) return;
                _marks[_indexJudge++] = result;
            }
            private double TotalMark
            {
                get
                {
                    if (_marks == null) return 0;

                    double s = 0;
                    for (int i = 0; i < _marks.Length; i++) s += _marks[i];

                    return s;
                }
            }

            private int TopPlace
            {
                get
                {
                    if (_places == null) return 0;
                    return _places.Min();
                }
            }
            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;

                for (int judge = 0; judge < 7; judge++)
                {
                    for (int i = 1, j = 2; i < participants.Length;)
                    {
                        if (i == 0)
                        {
                            i = j++;
                        }
                        else if (participants[i]._marks == null)
                        {
                            i = j++;
                        }
                        else if (participants[i - 1]._marks == null)
                        {
                            Participant tmp = participants[i];
                            participants[i] = participants[i - 1];
                            participants[i - 1] = tmp;
                            i--;
                        }
                        else if (participants[i].Marks[judge] < participants[i - 1].Marks[judge])
                        {
                            i = j++;
                        }
                        else
                        {
                            Participant tmp = participants[i];
                            participants[i] = participants[i - 1];
                            participants[i - 1] = tmp;
                            i--;
                        }
                    }
                    for (int place = 0; place < participants.Length; place++)
                    {
                        if (participants[place]._places != null) participants[place]._places[judge] = place + 1;
                    }

                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                int n = array.Length;
                for (int i = 0; i<n; i++)
                {
                    for (int j = 1; j<n; j++)
                    {
                        int s1 = array[j].Score, s2 = array[j-1].Score;
                        if (s1 < s2)
                        {
                            (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        }
                        else if (s1 == s2)
                        {
                            int pt1 = array[j].TopPlace, pt2 = array[j - 1].TopPlace;
                            if (pt1 < pt2)
                            {
                                (array[j], array[j - 1]) = (array[j - 1], array[j]);
                            }
                            else if (pt1 == pt2)
                            {
                                double m1 = array[j].TotalMark, m2 = array[j - 1].TotalMark;
                                if (m1 > m2)
                                {
                                    (array[j], array[j - 1]) = (array[j - 1], array[j]);
                                }
                            }
                        }
                    }
                }
            }
            
            public void Print()
            {
                Console.WriteLine("{0}, {1}, {2:f}, {3:f}, {4:f}", _name, _surname, Score, TopPlace, TotalMark);
                foreach (double c in _places)
                {
                    Console.Write("{0}, ", c);
                }
                Console.WriteLine();
                foreach (double c in _marks)
                {
                    Console.Write("{0}, ", c);
                }
                Console.WriteLine();
            }
        }
    }
}
