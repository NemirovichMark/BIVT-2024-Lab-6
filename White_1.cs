using System;
using System.Linq;
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

            public void Jump(double result)
            {
                if (_firstJump == 0) _firstJump = result;
                else if (_secondJump == 0) _secondJump = result;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].JumpSum < array[j + 1].JumpSum)
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
                Console.WriteLine($"{_surname} {_club} {_firstJump} {_secondJump} {JumpSum}");
            }
        }
    }
}
