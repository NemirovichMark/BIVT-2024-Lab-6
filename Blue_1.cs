using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_1;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            //поля
            private string _name;
            private string _surname;
            private int _votes;

            //свойства
            public string Name => _name; // ?? "Unknown";
            public string Surname => _surname; // ?? "Unknown";
            public int Votes => _votes;


            //конструкторы
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            //методы
            public int CountVotes(Response[] responses)
            {
                int count = 0;
                if (responses == null || responses.Length == 0)
                {
                    return 0;
                }
                foreach (var response in responses)
                {
                    if (response.Name == null)
                    {
                        continue;
                    }
                    if (response.Surname == null)
                    {
                        continue;
                    }
                    if (response.Name == this.Name && response.Surname == this.Surname)
                    {
                        _votes++;
                    }
                }
                return _votes;
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {_votes}");
            }
        }
    }
}
