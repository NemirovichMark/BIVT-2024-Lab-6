using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class White_2
    {
        public struct Participant
        {
            // поля 
            private string _surname;
            private string _name;
            private double _firstJump;
            private double _secondJump;
            //свойства
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }
            
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double BestJump => Math.Max(_firstJump, _secondJump);
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _firstJump = 0;
                _secondJump = 0;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                bool y;
                for (int i = 0; i < n - 1; i++)
                {
                    y = false;
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump) 
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            y = true;
                        }
                    }
                    if (!y) break; 
                }
            }
            public void Jump(double result)
            {
                if (_firstJump == 0)
                {
                    _firstJump = result;
                }
                else if (_secondJump == 0)
                {
                    _secondJump = result;
                }
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Первый прыжок: {_firstJump}, Второй прыжок: {_secondJump}, Лучший прыжок: {BestJump}");
            }
        }
    }
}
