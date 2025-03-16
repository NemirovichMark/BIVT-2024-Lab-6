using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;

namespace Lab_6
{
    public class Purple_4
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
                Console.Write(_name + " ");
                Console.Write(_surname + " ");
                Console.WriteLine(_time);
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
                    if( _sportsmen == null ) return null;
                    Sportsman[] sportsmen = new Sportsman[_sportsmen.Length];

                    Array.Copy( _sportsmen,sportsmen, _sportsmen.Length);
                    
                    return sportsmen;
                }
            }
            public Group(string name)
            {
                _name= name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                _name = group.Name;
                if (group.Sportsmen == null) _sportsmen = null;
                else
                {
                    _sportsmen = new Sportsman[group.Sportsmen.Length];
                    Array.Copy( group.Sportsmen,_sportsmen, group.Sportsmen.Length);
                }
            }
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length-1] = sportsman;
               
            }
            public void Add(Sportsman[] sportsman)
            {
                if (_sportsmen == null || sportsman.Length == 0||sportsman==null) return;
                int k = _sportsmen.Length;
                Array.Resize(ref _sportsmen,_sportsmen.Length + sportsman.Length);
                int a = 0;
                for(int i = k; i < _sportsmen.Length; i++)
                {
                    _sportsmen[i] = sportsman[a];
                    a++;
                }
                
            }
            public void Add(Group group)
            {
                if (_sportsmen == null || group.Sportsmen == null) return;
                Add(group.Sportsmen);
            }
            public void Sort()
            {
                if (_sportsmen == null) return;
                for (int i = 1; i < _sportsmen.Length;)
                {
                    if (i == 0 || _sportsmen[i].Time>= _sportsmen[i - 1].Time)
                    {
                        i++;
                    }
                    else
                    {
                        Sportsman temp1 = _sportsmen[i];
                        _sportsmen[i] = _sportsmen[i - 1];
                        _sportsmen[i - 1] = temp1;
                        i--;
                    }
                }
            }
            public static Group Merge(Group group1, Group group2)
            {
                Group Finalists = new Group("Финалисты");
                Finalists._sportsmen = new Sportsman [group1._sportsmen.Length + group2._sportsmen.Length];
                for(int i = 0; i < group1._sportsmen.Length; i++)
                {
                    Finalists._sportsmen[i]= group1._sportsmen[i];
                }
                for(int i=group1._sportsmen.Length;i<group2._sportsmen.Length+ group1._sportsmen.Length; i++)
                {
                    Finalists._sportsmen[i] = group2._sportsmen[i-group1._sportsmen.Length];
                }
                
                Finalists.Sort();
                return Finalists;
            }
            public void Print()
            {
                Console.Write(_name + " ");
                Console.WriteLine();
                foreach (var sportsman in _sportsmen)
                {
                    sportsman.Print();
                }
            }
        }
    }
}
