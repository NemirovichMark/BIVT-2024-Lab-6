using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Blue_1 r = new Blue_1(); //создаем экземпляр структуры

            Blue_1.Response[] responses = new Blue_1.Response[]
               {
                    new Blue_1.Response("Petya", "Vasechkin"),
                    new Blue_1.Response("Ivan", "Ivanov"),
                    new Blue_1.Response("Petya", "Vasechkin"),
                    new Blue_1.Response("Anna", "Sidorova"),
                    new Blue_1.Response("Petya", "Vasechkin")
               };
            Blue_1.Response person = new Blue_1.Response(null, null);
            int votes = person.CountVotes(responses);

            Console.WriteLine($"Человек: {person.Name} {person.Surname}");
            Console.WriteLine($"Количество голосов: {votes}");

        }
    }
}
