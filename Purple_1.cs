using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        { 
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private  int _number;
            private double _sum;
            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] coefs = new double[_coefs.Length];
                    Array.Copy(_coefs,coefs,_coefs.Length);
                    return coefs;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, marks, _marks.Length);
                    return marks;
                }
            }
            public double TotalScore
            {
                get
                {
                    return _sum;
                }

            }
            private void Sum()
            {
                

                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    int min = int.MaxValue;
                    int max = int.MinValue;
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        _sum += _marks[i, j] * _coefs[i];
                        if (min > _marks[i, j]) min = _marks[i, j];
                        if (max < _marks[i, j]) max = _marks[i, j];
                    }
                    _sum -= (min + max) * _coefs[i];

                }
                
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _sum = 0;
                _number = 0;
            }
            public void SetCriterias(double[] coefs)
            {
                if (coefs.Length == 4 && coefs != null && _coefs != null)
                {
                    Array.Copy(coefs, _coefs, coefs.Length);
                }
            }
            public void Jump(int[] marks)
            {

                if (marks.Length == 7 && _number < 4 && marks != null && _marks != null && _coefs != null)
               
                {
                    for (int i = 0; i < marks.Length; i++)
                    {
                        _marks[_number, i] = marks[i];
                    }
                    
                    _number++;
                    if (_number == 4)
                    {
                        Sum();
                    }
                }
            }
            public static void Sort( Participant[] array)
            {
                if (array == null || array.Length <= 1) return;
                for (int i = 1; i < array.Length;)
                {
                    if (i == 0 || array[i].TotalScore <= array[i - 1].TotalScore)
                    {
                        i++;
                    }
                    else
                    {
                        Participant temp1 = array[i];
                        array[i] = array[i - 1];
                        array[i-1] = temp1;
                        i--;
                    }
                }
                
            }
         
            public void Print()
            {
                Console.Write(_name+" ");
                Console.Write(_surname + " ");
                Console.WriteLine(_sum);
            }
        }
 
    }
}

