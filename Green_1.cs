using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_6
{
    public class Green_1{
        public struct Participant{
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result; 
            
            private static readonly double _standard;
            private static int _passedCount;

            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;
            public static int PassedTheStandard => _passedCount;
            public bool HasPassed => _result <= _standard;

            static Participant(){
                _standard =100;
                _passedCount =0;
            }
            
            public Participant(string surname, string group, string trainer){
                _surname = surname; 
                _group = group;
                _trainer = trainer;
                _result = 0;
            }

            public void Run(double result)
                {
                    if (_result==0)
                    {
                        _result = result;
                        if (result <= _standard)
                        {
                            _passedCount++;
                        }
                    }
                }
            public void Print(){
                Console.WriteLine($"{Surname} {Group} {Trainer} {Result} {HasPassed}");
            }
        }
    }
}