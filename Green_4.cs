using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_6
{
    public class Green_4
    {
        public struct Participant{
            private string _name;
            private string _surname;
            private double[] _jumps;

            public string Name=>_name;
            public string Surname=>_surname;
            public double[] Jumps=>_jumps;
            public double BestJump{
                get{
                    double best=_jumps[0];
                    if (_jumps != null && _jumps.Length > 0){
                        for (int i=0;i<_jumps.Length; i++){
                            if (_jumps[i]>best) best = _jumps[i];
                        }
                    }
                    return best;
                }
            }

            public Participant(string name, string surname){
                _name=name;
                _surname=surname;
                _jumps=new double[3];
            }

            public void Jump(double result){
                if (_jumps==null) return;
                for (int i = 0;i<_jumps.Length; i++){
                    if (_jumps[i]==0){
                        _jumps[i]=result;
                        return;
                    }
                }
            }
            public static void Sort(Participant[] array){
                if (array==null) return;
                    for(int i =0; i<array.Length-1;i++){
                        for (int j =0; j<array.Length-i-1; j++){
                            if (array[j].BestJump<array[j+1].BestJump){
                                Participant temp = array[j];
                                array[j]=array[j+1];
                                array[j+1]=temp;
                            }
                        }
                }
            }
            public void Print(){
                System.Console.WriteLine($"{Name} {Surname} {BestJump}");
            }
        }
    }
}