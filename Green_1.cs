using System;
using System.Linq;
namespace Lab_6
{
    public class Green_1{
        public struct Participant{
            private string _surname;
            private string _group;
            private string _trainer;
            private double _result; 
            
            private static readonly double standard;
            private static int passedcount;
            static Participant(){
                standard=100;
                passedcount=0;
            }
            public Participant(string surname, string group, string trainer){
                _surname = surname; 
                _group = group;
                _trainer = trainer;
                _result = 0;
            }

            public string Surname => _surname;
            public string Group => _group;
            public string Trainer => _trainer;
            public double Result => _result;
            public static int PassedTheStandard => passedcount;
            public bool HasPassed => (_result > 0 && _result <= standard);
            public void Run(double result)
                {
                    if (_result==0)
                    {
                        _result = result;
                        if (HasPassed)
                        {
                            passedcount++;
                        }
                    }
                }
            public void Print(){
                Console.WriteLine($"{Surname} {Group} {Trainer} {Result} {HasPassed}");
                Console.WriteLine(PassedTheStandard);
            }
        }
    }
}