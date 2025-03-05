using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            // поля
            private string _name;
            private string _surname;
            private int votes;

            // конструкторы
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                votes = 0;
            }

            // свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Votes { get { return votes; } }

            // методы 
            public int CountVotes(Response[] responses)
            {
                if (responses == null) { return 0; }

                votes = 0;
                foreach (Response response in responses)
                {
                    if (response.Name == _name && response.Surname == _surname)
                    {
                        votes++;
                    }
                }

                return votes;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {votes}");
            }
        }
    }
}