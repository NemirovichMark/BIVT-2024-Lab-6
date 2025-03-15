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
            private string _Name;
            private string _Surname;
            private int _Votes;

            public string Name { get { return _Name; } }
            public string Surname => _Surname;
            public int Votes => _Votes;

            public Response(string Name1, string Surname1)
            {
                _Name = Name1;
                _Surname = Surname1;
                _Votes = 0;
            }
            public int CountVotes(Response[] responses)
            {
                _Votes = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if ((responses[i].Name == _Name) && (responses[i].Surname == _Surname))
                    {
                        _Votes++;
                    }
                }
                return _Votes;
            }
            public void Print()
            {
                Console.WriteLine($"Person: {_Name} {_Surname}, Votes: {_Votes}");
            }
        }
    }
}
