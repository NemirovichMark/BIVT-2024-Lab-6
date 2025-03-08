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
                    Sportsman[] Sportsmen = new Sportsman[_sportsmen.Length];
                    for( int i = 0; i < _sportsmen.Length; i++ )
                    {
                        Sportsmen[i] = _sportsmen[i];
                    }
                    return Sportsmen;
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
                    for(int i = 0;i< _sportsmen.Length;i++ )
                    {
                        _sportsmen[i]=group.Sportsmen[i];
                    }
                }
            }
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;
                Sportsman[] add = new Sportsman[_sportsmen.Length+1];
                for(int i=0;i< _sportsmen.Length; i++)
                {
                    add[i]=_sportsmen[i];
                }
                add[add.Length-1] = sportsman;
                _sportsmen= add;
            }
            public void Add(Sportsman[] sportsman)
            {
                if (_sportsmen == null || sportsman.Length == 0) return;
                Sportsman[] add = new Sportsman[_sportsmen.Length + sportsman.Length];
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    add[i] = _sportsmen[i];
                }
                for(int i = _sportsmen.Length; i < _sportsmen.Length + sportsman.Length; i++)
                {
                    add[i] = Sportsmen[i-_sportsmen.Length];
                }
                _sportsmen = add;
            }
            public void Add(Group group)
            {
                if (_sportsmen == null || group.Sportsmen == null) return;
                Sportsman[] add = new Sportsman[group.Sportsmen.Length];
                for(int i = 0; i < add.Length; i++)
                {
                    add[i] = group.Sportsmen[i];
                }
                _sportsmen= add;
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
