using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal;
            private string _characterTrait;
            private string _concept;

            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;

            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;
            }


            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (responses == null || questionNumber < 1 || questionNumber > 3) return 0;
                string thisAnimal = _animal;
                string thisCharacterTrait = _characterTrait;
                string thisConcept = _concept;
                if (questionNumber == 1 && thisAnimal != null)
                {
                    return responses.Count(r => r.Animal == thisAnimal);
                }
                else if (questionNumber == 2 && thisCharacterTrait != null)
                {
                    return responses.Count(r => r.CharacterTrait == thisCharacterTrait);
                }
                else if (questionNumber == 3 && thisConcept != null)
                {
                    return responses.Count(r => r.Concept == thisConcept);
                }
                else { return 0; }
            }


            public void Print()
            {
                Console.WriteLine($"{_animal,15} {_characterTrait,15} {_concept,15}");
            }

        }




        public struct Research
        {
            private string _name;
            private Response[] _responses;

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
            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }



            public void Add(string[] answers)
            {
                if (answers == null || _responses == null || answers.Length < 3) return;
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = new Response(answers[0], answers[1], answers[2]);
            }


            public string[] GetTopResponses(int question)
            {
                if (_responses == null || question < 1 || question > 3)
                    return null;

                string[] answers = new string[_responses.Length];
                int validAnswers = 0;

                foreach (Response resp in _responses)
                {
                    string answer = GetAnswer(resp, question);
                    if (!string.IsNullOrEmpty(answer))
                    {
                        answers[validAnswers++] = answer;
                    }

                }

                if (validAnswers == 0)
                {
                    return null;
                }


                var uniqueAnswers = answers.Distinct().ToArray();

                var pairs = new (string Answer, int Count)[uniqueAnswers.Length];
                for (int i = 0; i < uniqueAnswers.Length; i++)
                {
                    pairs[i] = (uniqueAnswers[i], answers.Count(a => a == uniqueAnswers[i]));
                }


                var sortedPairs = pairs
                .OrderByDescending(p => !string.IsNullOrEmpty(p.Answer)) // не понимаю, откуда в pairs взялись null'ы
                .ThenByDescending(p => p.Count)                    // если мы отбрысываем их с помощью validAnswers, но без проверки в сортировке
                                                                  // (второй проверки тех же самхы данных по сути) код работает некорретно
                .ThenBy(p => p.Answer)                                  
                .ToArray();

                int resultSize = Math.Min(5, sortedPairs.Length);
                string[] result = new string[resultSize];
                for (int i = 0; i < resultSize; i++)
                {
                    result[i] = sortedPairs[i].Answer;
                }

                return result;
            }

            private string GetAnswer(Response resp, int question)
            {
                if (question == 1) { return resp.Animal; }
                else if (question == 2) { return resp.CharacterTrait; }
                else if (question == 3) { return resp.Concept; }
                else { return null; }
            }

            public void Print()
            {
                Console.WriteLine($"Name: {_name}");
                if (_responses == null) return;
                Console.WriteLine($"Answers:");
                foreach (Response response in _responses) response.Print();
                Console.WriteLine();
            }

        }




    }
}
