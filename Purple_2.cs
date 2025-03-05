using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            //поля

            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;



            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    if (_marks == null)
                    {
                        return null;
                    }
                    var copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int Result { get; private set; }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
                Result = 0;
            }
            public void Jump(int distance, int[] marks)
            {
                if (distance == null || marks == null || marks.Length != 5 || distance < 0 || _marks == null)
                    return;
                _distance = distance;
                Array.Copy(marks, _marks, _marks.Length);
                int Points = 60 + (_distance - 120) * 2;
                if (Points < 0) Points = 0;
                Result += marks.Sum() - marks.Max() - marks.Min() + Points;

            }

            public void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1) return;
                //for (int i = 0, j = 1;i< array.Length;)
                //{
                //    if (i==0 || array[i].Result <= array[i - 1].Result)
                //    {
                //        i = j;
                //        j++;
                //    }
                //    else
                //    {
                //        var temp = array[i];
                //        array[i] = array[i-1];
                //        array[i-1] = temp;
                //        i--;
                //    }
                //}
                var copy = array.OrderByDescending(x => x.Result).ToArray();
                Array.Copy(copy, array, copy.Length);
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}    Фамилия: {_surname}    Результат: {Result}");
            }
        }
    }
}
