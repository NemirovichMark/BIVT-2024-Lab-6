﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;

            public string Name
            {
                get { return _name; }
            }
            public string Surname { get { return _surname; } }
            public double Time { get { return _time; } }

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
            }

            public void Run(double time)
            {
                if (_time != 0) return;
                _time = time;
            }
            public void Print()
            {
                Console.Write(_name + "   ");
                Console.Write(_surname + "   ");
                Console.WriteLine(_time + "   ");
            }
        }

        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsman;

            public string Name { get { return _name; } }
            public Sportsman[] Sportsmen { 
                get 
                {
                    return _sportsman;
                } 
            }

            public Group(string name)
            {
                _name = name;
                _sportsman = new Sportsman[0];
            }
            public Group(Group group)
            {
                if (group._sportsman == null) return;
                _name = group.Name;
                _sportsman = new Sportsman[group._sportsman.Length];
                Array.Copy(group._sportsman, _sportsman, group._sportsman.Length);
            }
            public void Add(Sportsman sportsman)
            {
               if (_sportsman == null) return;
               Array.Resize(ref _sportsman, _sportsman.Length + 1);
                _sportsman[_sportsman.Length - 1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsman == null || sportsmen == null) return;
                int len = _sportsman.Length;

                Array.Resize(ref _sportsman, _sportsman.Length + sportsmen.Length);
                for (int i = len; i < _sportsman.Length; i++)
                {
                    _sportsman[i] = sportsmen[i - len];
                }
            }
            public void Add(Group group)
            {
                if (_sportsman == null) return;
                if (group._sportsman == null) return;
                Add(group._sportsman);
            }
            public void Sort()
            {
                if (_sportsman == null) { return; }
                for (int i = 0; i < _sportsman.Length - 1; i++)
                {
                    for (int j = 0; j < _sportsman.Length - i - 1; j++)
                    {
                        if (_sportsman[j].Time > _sportsman[j + 1].Time)
                        {
                            (_sportsman[j], _sportsman[j + 1]) = (_sportsman[j + 1], _sportsman[j]);
                        }
                    }

                }
            }
            public static Group Merge(Group group1, Group group2)
            {
                if (group1._sportsman == null || group2._sportsman == null) return new Group();
                Group final_group = new Group("Финалисты");
                int i = 0; int j = 0;
                while (i < group1._sportsman.Length &&  j < group2._sportsman.Length)
                {
                    if (group1._sportsman[i].Time < group2._sportsman[j].Time)
                    {
                        final_group.Add(group1._sportsman[i]);
                        i++;
                    }
                    else
                    {
                        final_group.Add(group2._sportsman[j]);
                        j++;
                    }
                }
                while (i < group1._sportsman.Length)
                {
                    final_group.Add(group1._sportsman[i]);
                    i++;
                }
                while (j < group2._sportsman.Length)
                {
                    final_group.Add(group2._sportsman[j]);
                    j++;
                }
                return final_group;
            }

            public void Print()
            {
                foreach (var sport in _sportsman)
                {
                    Console.Write(sport.Name + "   ");
                    Console.Write(sport.Surname + "   ");
                    Console.WriteLine(sport.Time + "   ");
                }
            }
        }
    }
}
