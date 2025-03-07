using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
                _distance = 0;
            }

            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int Result { get; private set; }

            public void Jump(int distance, int[] marks)
            {
                if (_marks == null || marks == null || marks.Length != 5) return;
                _distance = distance;
                Array.Copy(marks, _marks, marks.Length);
                int points = 60 + (_distance - 120) * 2;
                if (points <= 0) points = 0;
                Result += points + marks.Sum() - (marks.Max() + marks.Min());

            }

            public static void Sort(Participant[] array)
            {
                if (array == null) { return; }

                for (int i = 1; i < array.Length;)
                {
                    if (i == 0 || array[i - 1].Result >= array[i].Result)
                    {
                        i++;
                    }
                    else
                    {
                        Participant tmp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = tmp;
                        i--;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Name: {_name}\nSurname: {_surname}\nDistance: {_distance}");
                Console.WriteLine("\nMarks:");
                foreach (int mark in _marks) Console.Write($"{mark} ");
                Console.WriteLine();
                Console.WriteLine($"Result: {Result}\n");
            }


        }


    }
}
