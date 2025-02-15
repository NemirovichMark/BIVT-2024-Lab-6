﻿using System;
using System.Linq;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Purple_1.Participant[] participants = new Purple_1.Participant[]
        {
            new Purple_1.Participant("Иван", "Иванов"),
            new Purple_1.Participant("Петр", "Петров"),
            new Purple_1.Participant("Сергей", "Сергеев")
        };

        participants[0].SetCriterias(new double[] { 3.0, 3.2, 3.1, 3.3 });
        participants[1].SetCriterias(new double[] { 2.8, 3.0, 3.2, 3.1 });
        participants[2].SetCriterias(new double[] { 3.1, 3.0, 2.9, 3.2 });

        participants[0].Jump(new int[] { 5, 6, 5, 4, 5, 6, 5 }); 
        participants[0].Jump(new int[] { 6, 6, 5, 5, 6, 6, 5 });
        participants[0].Jump(new int[] { 5, 5, 4, 5, 5, 5, 4 });
        participants[0].Jump(new int[] { 6, 6, 6, 5, 6, 6, 5 });

        participants[1].Jump(new int[] { 4, 5, 4, 5, 4, 5, 4 });
        participants[1].Jump(new int[] { 5, 5, 5, 5, 5, 5, 5 });
        participants[1].Jump(new int[] { 6, 6, 6, 6, 6, 6, 6 });
        participants[1].Jump(new int[] { 5, 5, 5, 5, 5, 5, 5 });

        participants[2].Jump(new int[] { 6, 6, 6, 6, 6, 6, 6 });
        participants[2].Jump(new int[] { 5, 5, 5, 5, 5, 5, 5 });
        participants[2].Jump(new int[] { 4, 4, 4, 4, 4, 4, 4 });
        participants[2].Jump(new int[] { 3, 3, 3, 3, 3, 3, 3 });

        Purple_1.Participant.Sort(participants);

        Console.WriteLine("Итоговая таблица:");
        foreach (var participant in participants)
        {
            Console.WriteLine($"{participant.Surname} {participant.Name}: " +
                $"Итоговый результат: {participant.TotalScore:F2}");
        }


            Purple_3.Participant[] participants1 = new Purple_3.Participant[]
            {
                new Purple_3.Participant("Иван", "Иванов"),
                new Purple_3.Participant("Петр", "Петров"),
                new Purple_3.Participant("Сергей", "Сергеев"),
                new Purple_3.Participant("Алексей", "Алексеев")
            };

            participants1[0].Evaluate(5.5);
            participants1[0].Evaluate(6.0);
            participants1[0].Evaluate(5.0);
            participants1[0].Evaluate(4.5);
            participants1[0].Evaluate(5.0);
            participants1[0].Evaluate(6.0);
            participants1[0].Evaluate(5.5);

            participants1[1].Evaluate(6.0);
            participants1[1].Evaluate(5.5);
            participants1[1].Evaluate(5.5);
            participants1[1].Evaluate(5.0);
            participants1[1].Evaluate(5.5);
            participants1[1].Evaluate(6.0);
            participants1[1].Evaluate(5.0);

            participants1[2].Evaluate(4.5);
            participants1[2].Evaluate(5.0);
            participants1[2].Evaluate(4.0);
            participants1[2].Evaluate(5.5);
            participants1[2].Evaluate(4.5);
            participants1[2].Evaluate(5.0);
            participants1[2].Evaluate(4.0);

            participants1[3].Evaluate(5.5);
            participants1[3].Evaluate(6.0);
            participants1[3].Evaluate(5.0);
            participants1[3].Evaluate(4.5);
            participants1[3].Evaluate(5.0);
            participants1[3].Evaluate(6.0);
            participants1[3].Evaluate(5.5);

            foreach (var participant in participants1)
            {
                Console.WriteLine($"{participant.Surname} {participant.Name}: " +
                    $"Оценки: {string.Join(", ", participant.Marks), 10}, " +
                    $"Места: {string.Join(", ", participant.Places), 10}, " +
                    $"Сумма мест: {participant.Score}");
            }

            Purple_3.Participant.SetPlaces(participants1);

            Console.WriteLine("Результаты соревнований:");
            foreach (var participant in participants1)
            {
                Console.WriteLine($"{participant.Surname} {participant.Name}: " +
                    $"Оценки: {string.Join(", ", participant.Marks), 10}, " +
                    $"Места: {string.Join(", ", participant.Places), 10}, " +
                    $"Сумма мест: {participant.Score}");
            }


            Console.WriteLine("До сортировки:");
            foreach (var participant in participants1)
            {
                Console.WriteLine($"{participant.Surname} {participant.Name}: " +
                    $"Сумма мест: {participant.Score}, " +
                    $"Наивысшее место: {participant.Places.Min()}, " +
                    $"Сумма очков: {participant.Marks.Sum()}");
            }

            Purple_3.Participant.Sort(participants1);

            Console.WriteLine("\nПосле сортировки:");
            foreach (var participant in participants1)
            {
                Console.WriteLine($"{participant.Surname} {participant.Name}: " +
                    $"Сумма мест: {participant.Score}, " +
                    $"Наивысшее место: {participant.Places.Min()}, " +
                    $"Сумма очков: {participant.Marks.Sum()}");
            }

            //4
            Purple_4.Sportsman sportsman1 = new Purple_4.Sportsman("Иван", "Иванов");
            sportsman1.Run(30.5);
            Purple_4.Sportsman sportsman2 = new Purple_4.Sportsman("Петр", "Петров");
            sportsman2.Run(28.7);

            Purple_4.Group group1 = new Purple_4.Group("Группа 1");
            group1.Add(sportsman1);
            group1.Add(sportsman2);
            group1.Sort();

            Purple_4.Sportsman sportsman3 = new Purple_4.Sportsman("Сергей", "Сергеев");
            sportsman3.Run(29.8);
            Purple_4.Sportsman sportsman4 = new Purple_4.Sportsman("Алексей", "Алексеев");
            sportsman4.Run(27.3);

            Purple_4.Group group2 = new Purple_4.Group("Группа 2");
            group2.Add(sportsman3);
            group2.Add(sportsman4);
            group2.Sort();

            Purple_4.Group finalGroup = Purple_4.Group.Merge(group1, group2);

            Console.WriteLine($"Группа: {finalGroup.Name}");
            foreach (var sportsman in finalGroup.Sportsmen)
            {
                Console.WriteLine($"{sportsman.Surname} {sportsman.Name}: {sportsman.Time} сек");
            }
            //5
            Purple_5.Response[] responses = new Purple_5.Response[]
        {
            new Purple_5.Response("Сакура", "Трудолюбие", "Самурай"),
            new Purple_5.Response("", "Вежливость", "Самурай"),
            new Purple_5.Response("Кошка", "Трудолюбие", "Чай"),
            new Purple_5.Response("Сакура", "", "Самурай"), 
            new Purple_5.Response("Кошка", "Вежливость", ""),
            new Purple_5.Response("Сакура", "Трудолюбие", "Самурай")
        };
        Purple_5.Research research = new Purple_5.Research("Опрос о Японии");
        foreach (var response in responses)
        {
            research.Add(new string[]{response.Animal, response.CharacterTrait, response.Concept});
        }
        Console.WriteLine("Топ-5 ответов по вопросу 1:");
        foreach (var response in research.GetTopResponses(1))
        {
            Console.WriteLine(response);
        }

        Console.WriteLine("\nТоп-5 ответов по вопросу 2:");
        foreach (var response in research.GetTopResponses(2))
        {
            Console.WriteLine(response);
        }

        Console.WriteLine("\nТоп-5 ответов по вопросу 3:");
        foreach (var response in research.GetTopResponses(3))
        {
            Console.WriteLine(response);
        }
        }
    }
}
