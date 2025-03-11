using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int [] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[] marks = new int[_marks.Length];
                    Array.Copy(_marks, marks, marks.Length);
                    return marks;
                }
            }
            public int Result
            {
                get
                {

                    if (_marks == null) return 0;
                    int k = 0;
                    int sum = 0;
                    int min = int.MaxValue;
                    int max = int.MinValue;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                            sum += _marks[i];
                            if (min > _marks[i]) min = _marks[i];
                            if (max < _marks[i]) max = _marks[i];
                    }
                    sum = sum - min - max;
                    if (_distance > 120) return (sum + 60 + 2 * (_distance - 120));
                    else k = (sum + 120 - 2 * (120 - _distance));
                    if (k <= 0) return 0;
                    else return k;

                }
            }
            public Participant(string name, string surname)
            {
                _name = name;   
                _surname = surname;
                _marks = new int[5];
                _distance = 0;
            }
            public void Jump(int distance, int[] marks)
            {
                if (distance == null || marks == null || marks.Length != 5 || distance < 0 || _marks == null) return;
                _distance = distance;
                for (int i = 0; i < marks.Length; i++) _marks[i] = marks[i];

            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1) return;
                for (int i = 1; i < array.Length;)
                {
                    if (i == 0 || array[i].Result <= array[i - 1].Result)
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
            public void Print()
            {
                Console.Write(_name + " ");
                Console.Write(_surname + " ");
                Console.WriteLine(Result);
            }
        }
    }
}
