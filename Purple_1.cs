using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    internal class Purple_1
    {
        public struct Participant
        {


            //поля
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _numJump;



            //свойства
            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    var copy = new double[_coefs.Length];
                    Array.Copy(_coefs,copy, _coefs.Length);
                    return copy;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    var copy = new int[_marks.GetLength(0),_marks.GetLength(1)];
                    Array.Copy(_marks,copy, _marks.Length);
                    return copy;
                }
            }

            public double TotalScore{ get; private set; }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 6];
                TotalScore = 0;
                _numJump = 0;

            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs.Length == 4)
                {
                    Array.Copy(coefs, _coefs, _coefs.Length);
                }
                else
                {
                    return;
                }
            }
            public void Jump(int[] marks)
            {
                if (marks.Length == 7)
                {
                    for (int i = 0; i < marks.Length; i++)
                    {
                        marks[i] = _marks[_numJump,i];
                        
                        

                    }
                    TotalScore += (marks[1] + marks[2] + marks[3]) * Coefs[_numJump];
                    
                    _numJump++;
                }
            }
            public static void Sort(Participant[] array)
            {
                int i = 0, j = 2;
                while (i < array.Length)
                {
                    if (i == 0 || array[i].TotalScore <= array[i - 1].TotalScore) 
                    {
                        i = j; j++;
                    }
                    else
                    {
                        var temp = array[i];
                        array[i-1] = array[i];
                        array[i] = temp;
                        i--;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Имя {_name}");
                Console.WriteLine($"Фамилия {_surname}");


                Console.WriteLine("Коэффиценты");
                foreach(var coef in _coefs)
                {
                    Console.Write(coef+" ");
                }

                Console.WriteLine("Оценки");
                int row = _marks.GetLength(0);
                int col = _marks.GetLength(1);
                for (int i = 0;i<row; i++)
                {
                    for (int j = 0;j<col; j++)
                    {
                        Console.Write(_marks[i, j] + " ");
                    }
                    Console.WriteLine();
                }

            }
            


        }
    }
}
