﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_5;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            //поля 
            private string _animal;
            private string _characterTrait;
            private string _concept;

            private string[] _answers;
     

            //свойства
            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;
            private string[] Answers
            {
                get
                {
                    string[] copy = new string[_answers.Length];
                    Array.Copy(_answers, copy, _answers.Length);
                    return copy;
                }
            }

            //Конструктор 
            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;

                _answers = new string[] { animal, characterTrait, concept };
                
            }

            //методы
            public int CountVotes(Response[] responses, int questionNumber)
            {
                int count = 0;
                if (responses == null || questionNumber < 1 || questionNumber > 3) return 0;
                foreach (Response response in responses)
                {
                    if (response._answers == null) return 0;
                    if (response._answers[questionNumber - 1] != null) count++;
                }
                return count;
            }

            public void Print()
            {
                Console.WriteLine($"{_animal}, {_characterTrait}, {_concept}");
            }

        }

        public struct Research
        {
            //поля
            private string _name;
            private Response[] _responses;


            //свойства
            public string Name => _name;
            public Response[] Responses
            {
                get
                {
                    if (_responses == null) return null;
                    Response[] copy = new Response[_responses.Length];
                    Array.Copy(_responses, copy, _responses.Length);
                    return copy;
                }
            }

            //конструктор 
            public Research(string name)
            {
                _name = name;

                _responses = new Response[0];

                
            }

            //методы
            public void Add(string[] answers)
            {
                if (answers == null || _responses==null) return;
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = new Purple_5.Response(answers[0], answers[1], answers[2]);
                
            }
            public string[] GetTopResponses(int question)
            {
                if (_responses==null || question<1 || question>3) return null;

                string[] question_responses = new string[_responses.Length];

                if (question == 1)
                {
                    for (int i = 0, j = 0; i < _responses.Length; i++)
                    {

                        if (_responses[i].Animal == null)
                        {
                            continue;
                        }
                        question_responses[j] = _responses[i].Animal;
                        j++;
                        if (i == _responses.Length - 1)
                        {
                            Array.Resize(ref question_responses, j);
                        }
                    }
                }
                else
                {
                    if (question == 2)
                    {
                        for (int i = 0, j = 0; i < _responses.Length; i++)
                        {

                            if (_responses[i].CharacterTrait == null)
                            {
                                continue;
                            }
                            question_responses[j] = _responses[i].CharacterTrait;
                            j++;
                            if (i == _responses.Length - 1)
                            {
                                Array.Resize(ref question_responses, j);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0, j = 0; i < _responses.Length; i++)
                        {

                            if (_responses[i].Concept == null)
                            {
                                continue;
                            }
                            question_responses[j] = _responses[i].Concept;
                            j++;
                            if (i == _responses.Length - 1)
                            {
                                Array.Resize(ref question_responses, j);
                            }
                        }
                    }
                }
                string[] unic_question_responses = question_responses.Distinct().ToArray();
                

                int[] count_unic_question_responses= new int[unic_question_responses.Length];
                
                for (int i = 0; i < count_unic_question_responses.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < question_responses.Length; j++)
                    {
                    
                        if (question_responses[j] == unic_question_responses[i]) count++;
                    }
                    count_unic_question_responses[i] = count;

                }

                for (int i = 0; i < count_unic_question_responses.Length-1; i++)
                {
                    for (int j = 0; j < count_unic_question_responses.Length - 1 - i; j++)
                    {
                        if (count_unic_question_responses[j] < count_unic_question_responses[j + 1])
                        {
                            int copy = count_unic_question_responses[j + 1];
                            count_unic_question_responses[j + 1] = count_unic_question_responses[j];
                            count_unic_question_responses[j] = copy;

                            string copy1 = unic_question_responses[j + 1];
                            unic_question_responses[j + 1] = unic_question_responses[j];
                            unic_question_responses[j] = copy1;
                        }
                    }
                }
                string[] answer;
                if (unic_question_responses.Length > 5)
                {
                    answer = new string[5];
                    for (int i = 0; i < answer.Length; i++)
                    {
                        answer[i] = unic_question_responses[i];
                    }
                }
                else
                {
                    answer = new string[unic_question_responses.Length];
                    Array.Copy(unic_question_responses, answer, unic_question_responses.Length);
                }
                return answer;
            }

            private int CountResonseInQuestion(string response, int question)
            {
                if (_responses == null) return 0;
                int count = 0;
                if (question == 1)
                {
                    for (int i = 0; i < _responses.Length; i++)
                    {

                        if (_responses[i].Animal == response) count++;
                    }
                }
                else
                {
                    if (question == 2)
                    {
                        for (int i = 0; i < _responses.Length; i++)
                        {

                            if (_responses[i].CharacterTrait == response) count++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _responses.Length; i++)
                        {

                            if (_responses[i].Concept == response) count++;
                        }
                    }
                }
              
                return count;
            }
            public void Print(int question)
            {
                string[] need=GetTopResponses(question);
                foreach (string s in need)
                {
                    Console.WriteLine($"{s} {CountResonseInQuestion(s, question)}"); 
                    
                }
                Console.WriteLine("===");
            }
        }
    }
}
