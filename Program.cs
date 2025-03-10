using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Blue_3 r = new Blue_3(); //создаем экземпляр структуры

            Blue_3.Participant[] participants = new Blue_3.Participant[10];

            participants[0] = new Blue_3.Participant("Инна", "Пономарева");
            participants[0].PlayMatch(2); participants[0].PlayMatch(2); participants[0].PlayMatch(0);
            participants[0].PlayMatch(2); participants[0].PlayMatch(0); participants[0].PlayMatch(0);
            participants[0].PlayMatch(0); participants[0].PlayMatch(5); participants[0].PlayMatch(2);
            participants[0].PlayMatch(5);

            participants[1] = new Blue_3.Participant("Юрий", "Ушаков");
            participants[1].PlayMatch(0); participants[1].PlayMatch(10); participants[1].PlayMatch(10);
            participants[1].PlayMatch(0); participants[1].PlayMatch(5); participants[1].PlayMatch(5);
            participants[1].PlayMatch(2); participants[1].PlayMatch(10); participants[1].PlayMatch(10);
            participants[1].PlayMatch(10);

            participants[2] = new Blue_3.Participant("Дмитрий", "Иванов");
            participants[2].PlayMatch(2); participants[2].PlayMatch(5); participants[2].PlayMatch(5);
            participants[2].PlayMatch(2); participants[2].PlayMatch(0); participants[2].PlayMatch(10);
            participants[2].PlayMatch(5); participants[2].PlayMatch(2); participants[2].PlayMatch(0);
            participants[2].PlayMatch(0);

            participants[3] = new Blue_3.Participant("Иван", "Кристиан");
            participants[3].PlayMatch(2); participants[3].PlayMatch(10); participants[3].PlayMatch(2);
            participants[3].PlayMatch(5); participants[3].PlayMatch(2); participants[3].PlayMatch(2);
            participants[3].PlayMatch(10); participants[3].PlayMatch(10); participants[3].PlayMatch(5);
            participants[3].PlayMatch(0);

            participants[4] = new Blue_3.Participant("Татьяна", "Ушакова");
            participants[4].PlayMatch(5); participants[4].PlayMatch(2); participants[4].PlayMatch(0);
            participants[4].PlayMatch(10); participants[4].PlayMatch(10); participants[4].PlayMatch(2);
            participants[4].PlayMatch(10); participants[4].PlayMatch(5); participants[4].PlayMatch(0);
            participants[4].PlayMatch(2);

            participants[5] = new Blue_3.Participant("Александра", "Козлова");
            participants[5].PlayMatch(5); participants[5].PlayMatch(2); participants[5].PlayMatch(5);
            participants[5].PlayMatch(0); participants[5].PlayMatch(0); participants[5].PlayMatch(10);
            participants[5].PlayMatch(5); participants[5].PlayMatch(5); participants[5].PlayMatch(2);
            participants[5].PlayMatch(10);

            participants[6] = new Blue_3.Participant("Дарья", "Павлова");
            participants[6].PlayMatch(0); participants[6].PlayMatch(2); participants[6].PlayMatch(0);
            participants[6].PlayMatch(2); participants[6].PlayMatch(5); participants[6].PlayMatch(5);
            participants[6].PlayMatch(5); participants[6].PlayMatch(5); participants[6].PlayMatch(2);
            participants[6].PlayMatch(5);

            participants[7] = new Blue_3.Participant("Мирослав", "Лисицын");
            participants[7].PlayMatch(0); participants[7].PlayMatch(2); participants[7].PlayMatch(2);
            participants[7].PlayMatch(10); participants[7].PlayMatch(10); participants[7].PlayMatch(2);
            participants[7].PlayMatch(5); participants[7].PlayMatch(2); participants[7].PlayMatch(5);
            participants[7].PlayMatch(0);

            participants[8] = new Blue_3.Participant("Юлия", "Чехова");
            participants[8].PlayMatch(0); participants[8].PlayMatch(10); participants[8].PlayMatch(5);
            participants[8].PlayMatch(10); participants[8].PlayMatch(5); participants[8].PlayMatch(5);
            participants[8].PlayMatch(5); participants[8].PlayMatch(2); participants[8].PlayMatch(5);
            participants[8].PlayMatch(2);

            participants[9] = new Blue_3.Participant("Дарья", "Лисицына");
            participants[9].PlayMatch(5); participants[9].PlayMatch(2); participants[9].PlayMatch(5);
            participants[9].PlayMatch(0); participants[9].PlayMatch(10); participants[9].PlayMatch(10);
            participants[9].PlayMatch(0); participants[9].PlayMatch(0); participants[9].PlayMatch(0);
            participants[9].PlayMatch(2);


            Blue_3.Participant.Sort(participants);

            foreach (var participant in participants)
            {
                participant.Print();
            }

        }
    }
}
