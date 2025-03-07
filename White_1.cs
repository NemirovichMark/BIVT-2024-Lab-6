using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class White_1
    {
        public struct Participant
        {
            private string _surname;
            private string _club;
            private double _firstJump;
            private double _secondJump;
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public string Club
            {
                get
                {
                    if (_club == null) return default;
                    return _club;
                }
            }
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double JumpSum => _firstJump + _secondJump;

            public Participant(string surname, string club)
            {
                _surname = surname;
                _surname = surname;
                _club = club;
                _firstJump = 0;
                _secondJump = 0;
            }



            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j].JumpSum < array[j + 1].JumpSum)
                        {
                            // Обмен местами
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Фамилия: {_surname}, Клуб: {_club}, Первый прыжок: {_firstJump}, Второй прыжок: {_secondJump}, Сумма: {JumpSum}");
            }
        }
    }
}