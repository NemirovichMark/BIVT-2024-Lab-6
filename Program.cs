using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Purple_2.Participant[] participants = new Purple_2.Participant[2];
            for (int i = 0;i< 2;i++)
            {
                var participant = new Purple_2.Participant(Console.ReadLine(), Console.ReadLine());
                
                int[] a = new int[5];
                int s = int.Parse(Console.ReadLine());
                for (int j = 0;j< 5; j++)
                {
                    a[j] = int.Parse(Console.ReadLine());
                }//это для второго
                
                //Console.WriteLine(s);
                participant.Jump(s, a);
                
                participants[i] = participant;
                participant.Sort(participants);
                participant.Print();

               
            }
            Console.WriteLine(participants.Length);
            foreach (var participant in participants)
            {
                participant.Print();
            }



        }
    }
}
