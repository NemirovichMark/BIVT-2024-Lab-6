using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
                Console.WriteLine($"Имя: {_name}    Фамилия: {_surname}    время: {_time}");
                Console.WriteLine();
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
                    return _sportsmen;
                }
            }

            public Group(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }
            public Group(Group group)
            {
                _name=group.Name;
                var copy = group.Sportsmen;
                _sportsmen = new Sportsman[0];
                if (group.Sportsmen == null) _sportsmen = null;
                Array.Copy(copy, _sportsmen, _sportsmen.Length);

            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;
                Array.Resize(ref _sportsmen,_sportsmen.Length+1);
                _sportsmen[_sportsmen.Length-1] = sportsman;

            }
            public void Add(Sportsman[] sportsman)
            {
                if (_sportsmen == null || sportsman.Length==0) return;
                int index = _sportsmen.Length;
                Array.Resize(ref _sportsmen,_sportsmen.Length+sportsman.Length);
                int a = 0;
                for (int i = index;i < _sportsmen.Length; i++)
                {
                    _sportsmen[i] = sportsman[a++];
                }

            }
            public void Add(Group group)
            {
                if (_sportsmen == null || group.Sportsmen == null)
                    return;
                Add(group.Sportsmen);
            }

            public void Sort()
            {
                if (_sportsmen != null)
                    _sportsmen = _sportsmen.OrderBy(r => r.Time).ToArray();
            }
            public static Group Merge(Group group1, Group group2)
            {
                var group = new Group();
                if (group1.Sportsmen == null || group2.Sportsmen == null)
                {
                    if (group1.Sportsmen != null)
                    {
                        Array.Copy(group1._sportsmen, group.Sportsmen, group1._sportsmen.Length);
                    }
                    else if (group2.Sportsmen != null)
                    {
                        Array.Copy(group2._sportsmen, group.Sportsmen, group2._sportsmen.Length);
                    }

                    return group;
                }
                Array.Resize(ref group._sportsmen, group1._sportsmen.Length+ group2._sportsmen.Length);
                int i = 0, j = 0, k = 0;
                while (i < group1._sportsmen.Length && j < group2._sportsmen.Length)
                {
                    if (group1._sportsmen[i].Time <= group2._sportsmen[j].Time)
                        group._sportsmen[k++] = group1._sportsmen[i++];
                    else
                        group._sportsmen[k++] = group2._sportsmen[j++];
                }
                while (i < group1._sportsmen.Length)
                    group._sportsmen[k++] = group1._sportsmen[i++];
                while (j < group2._sportsmen.Length)
                    group._sportsmen[k++] = group2._sportsmen[j++];
                return group;



            }

            public void Print()
            {
                Console.WriteLine($"Name: {_name}");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Sportsmen");

                foreach(var sportsman in _sportsmen)
                {
                    sportsman.Print();
                }
            }
        }
    }
}
