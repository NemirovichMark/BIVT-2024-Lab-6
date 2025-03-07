using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _res;

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _res = new double[3];
            }


            public string Name => _name ?? default;
            public string Surname => _surname ?? default;
            public double[] Jumps => _res ?? default;
            public double BestJump
            {
                get
                {
                    if (_res == null || _res.Length < 0)
                    {
                        return default;
                    }
                    return _res.Max();
                }
            }
            public void Jump(double result)
            {
                if (_res == null) return;
                for (int i = 0; i < _res.Length; i++)
                {
                    if (_res[i] == 0)
                    {
                        _res[i] = result;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}, Лучший результат: {BestJump}");
            }
        }
    }
}
