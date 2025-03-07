using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

            public Response(string animal, string charactertrait, string concept)
            {
                _animal = animal;
                _characterTrait = charactertrait;
                _concept = concept;
            }
            public int CountVotes(Response[] responses, int questionNumber)
            {
                if (questionNumber < 1 || questionNumber > 3 || responses == null) return 0;

                switch (questionNumber)
                {
                    case 1:
                        string answer = _animal;
                        return responses.Count(ans => ans.Animal == answer && ans.Animal != null);
                    case 2:
                        string answer2 = _characterTrait;
                        return responses.Count(ans => ans.CharacterTrait == answer2 && ans.CharacterTrait != null);
                    case 3:
                        string answer3 = _concept;
                        return responses.Count(ans => ans.Concept == answer3 && ans.Concept != null);
                    default:
                        return 0;
                }
            }
            public void Print()
            {
                Console.WriteLine($"Животное: {_animal} \t черта: {_characterTrait} \tВещь: {_concept} \t");
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
                    return _responses;
                }
            }
            

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];

            }

            public void Add(string[] answers)
            {
                if (answers == null || answers.Length <= 2 || _responses==null) return;

                var copy = new Response(answers[0], answers[1], answers[2]);

                Array.Resize(ref _responses, _responses.Length+1);
                _responses[_responses.Length-1] = copy;
            }

            public string[] GetTopResponses(int question)
            {
                if (_responses == null || (question <1  || question > 3)) return null;
                string[] Ans = new string[_responses.Length];
                int[] amount = new int[_responses.Length];
                int index = 0;
                for (int i = 0; i < _responses.Length; i++)
                {
                    string Answer = GetAnswer(_responses[i], question);
                    if (Ans.Count(r => r == Answer) == 0) 
                    { 
                        Ans[index] = Answer;
                        amount[index++] = Ans.Count(r => r == Answer);
                    }
                    else
                    {
                        Ans[index] = "||";
                        amount[index++] = int.MinValue;
                    }

                }
                Sort(ref Ans,ref amount);
                int count = 0;
                for (int i = 0; i < Ans.Length; i++)
                {
                    if (Ans[i] == "||")
                    {
                        count++;
                    }
                }
                Array.Resize(ref Ans, Ans.Length-count);
                Array.Resize(ref amount, amount.Length-count);
                if (Ans.Length >= 5)
                {
                    Array.Resize(ref Ans, 5);
                }

                return Ans;
            }
            public string GetAnswer(Response A, int question)
            {
                string ans;
                switch (question)
                {
                    case 1:
                        ans = A.Animal;
                        return ans;
                    case 2:
                        ans = A.CharacterTrait;
                        return ans;
                    case 3:
                        ans = A.Concept;
                        return ans;
                    default:
                        return null;
                }
            }
            public void Sort(ref string[] resp,ref int[] number)
            {
                for (int i = 0, j=1;i < number.Length;)
                {
                    if (i==0 || number[i] <= number[i - 1])
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        int temp = number[i];
                        number[i] = number[i-1];
                        number[i-1] = temp;
                        string temp2 = resp[i];
                        resp[i] = resp[i-1];
                        resp[i-1] = temp2;
                        
                        i--;
                    }
                }
            }
            public void Print()
            {
                for (int i = 1; i <= 3; i++)
                {
                    string[] result = GetTopResponses(i);

                    for (int j = 0; j < result.Length; j++)
                    {
                        Console.Write(result[j] +" ");
                    }
                    Console.WriteLine();
                }
                
            }

        }
    }
}
