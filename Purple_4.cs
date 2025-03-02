using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;


            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
            }

            public void Run(double time)
            {
                if (time > 0 && _time == 0)
                {
                    _time = time;
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {_name}    Фамилия: {_surname}    время: {_time}");
                Console.WriteLine();
            }
        }
        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    var copy = new Sportsman[ _sportsmen.Length ];
                    Array.Copy(_sportsmen, copy, _sportsmen.Length );
                    return copy;
                }
            }

        }
    }
}
