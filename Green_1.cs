using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_1
    {
        public struct Participant
        {
            private string _surname;
            private string _group;
            private string _teacher;
            private double _result;

            private static readonly double standart;
            private static int passedcount;

            static Participant()
            {
                standart = 100; 
                passedcount = 0;
            }

            public Participant(string surname, string group, string teacher)
            {
                _surname = surname;
                _group = group;
                _teacher = teacher;
                _result = 0;
            }

            public string Surname
            {
                get 
                { 
                    //if(_surname == null) return default;
                    return _surname; 
                }
            }

            public string Group
            {
                get
                {
                    //if (_group == null) return default;
                    return _group;
                }
            }

            public string Teacher
            {
                get
                {
                    //if ( _teacher == null) return default;
                    return _teacher;
                }
            }

            public double Result
            {
                get
                {
                    //if(_result == null) return default;
                    return _result;
                }
            }

            public static int PassedTheStandard => passedcount;

            public bool HasPassed => _result <= standart && _result > 0;

            public void Run(double result)
            {
                if (_result == 0)
                {
                    _result = result;
                    if (HasPassed)
                    {
                        passedcount++;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Фамиия: {Surname}");
                Console.WriteLine($"Группа: {Group}");
                Console.WriteLine($"Учитель: {Teacher}");
                Console.WriteLine($"Результат: {Result}");
                Console.WriteLine($"Прошли: {HasPassed}");
            }
        }
    }
}
