namespace Lab_6;
public class Blue_1
{
    public struct Response
    {
        private string _firstName;
        private string _lastName;
        private int _counter;

        public readonly string Name => _firstName;
        public readonly string Surname => _lastName;
        public readonly int Votes => _counter;

        public Response(string name, string surname)
        {
            this._firstName = name;
            this._lastName = surname;
            this._counter = 0;
        }

        public int CountVotes(Response[] responses)
        {
            if (responses == null) return 0;
            int fooSumma = 0;
            foreach (var res in responses)
            {
                if (res.Name == this._firstName && res.Surname == this._lastName)
                {
                    fooSumma++;
                }
            }

            return fooSumma;
        }

        public void Print()
        {
            Console.WriteLine("{0}, {1}, {2}", this._firstName, this._lastName, this._counter);
        }
    }
}