using System;
using System.Collections.Generic;
using System.Linq;
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
                if (responses == null || questionNumber < 1 || questionNumber > 3) return 0;

                if (questionNumber == 1)
                {
                    string answer = _animal;
                    return responses.Count(one => one.Animal == answer && one.Animal != null);
                }

                else if (questionNumber == 2)
                {
                    string answer2 = _characterTrait;
                    return responses.Count(ans => ans.CharacterTrait == answer2 && ans.CharacterTrait != null);
                }
                else if (questionNumber == 3)
                {
                    string answer3 = _concept;
                    return responses.Count(ans => ans.Concept == answer3 && ans.Concept != null);
                }
                else return 0;

            }
            public void Print()
            {
                Console.WriteLine(_animal + " ");
                Console.WriteLine(_characterTrait + " ");
                Console.WriteLine(_concept + " ");
            }


        }
        public struct Research
        {
            private string _name;
            private Response[] _responses;
            public string Name => _name;
            public Response[] Responses => _responses;
            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];

            }
            public void Add(string[] answers)
            {
                if (answers == null || answers.Length !=3 || _responses == null) return;
                var Abb = new Response(answers[0], answers[1], answers[2]);
                Response[] _responses1 = new Response[_responses.Length + 1];
                for(int i=0; i < _responses.Length; i++)
                {
                    _responses1[i] = _responses[i];
                }
                _responses1[_responses1.Length-1] = Abb;
                _responses = _responses1;
            }
            //public string [] GetTopResponses(int question)
            //{
            //    string[] kan = new string[5];

            //}
        }

    }
}
