using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;

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
                    return responses.Count(one => one.CharacterTrait == answer2 && one.CharacterTrait != null);
                }
                else if (questionNumber == 3)
                {
                    string answer3 = _concept;
                    return responses.Count(one => one.Concept == answer3 && one.Concept != null);
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
                Array.Copy( _responses1,_responses, _responses1.Length);
            }
            public string [] GetTopResponses(int question)
            {
                if (_responses == null || question > 3 || question < 1 ) return null;
                string[] kan = new string[_responses.Length];
                for(int i=0,k=0;i<_responses.Length;i++,k++)
                {
                    string a1 = Geta1(_responses[i], question);
                    if (a1=="") Array.Resize(ref kan, kan.Length - 1);
                    else
                    {
                        kan[k] = a1;
                        k++;
                    }
                }
                string[] kan1 = new string[kan.Length];
                for (int i = 0, k = 0; i < kan.Length; i++, k++)
                {
                    for(int j=0; j < kan1.Length; j++)
                    {
                        if (kan[i] == kan1[j]) Array.Resize(ref kan1, kan1.Length - 1);
                        else
                        {
                            kan1[k] = kan1[i];
                            k++;
                        }
                    }
                }
                int[] mas = new int[kan1.Length];
                for(int i = 0; i < kan1.Length; i++)
                {
                    mas[i] = kan.Count(x => x == kan1[i]);
                }
                for (int i = 1; i < mas.Length;)
                {
                    if (i == 0 || mas[i] <= mas[i - 1])
                    {
                        i++;
                    }
                    else
                    {
                        int temp1 = mas[i];
                        mas[i] = mas[i - 1];
                        mas[i - 1] = temp1;
                        string temp = kan1[i];
                        kan1[i] = kan[i - 1];
                        kan[i-1] = temp;
                        i--;
                    }
                }
                string[] kan2= new string[5];
                if (kan1.Length >= 5)
                {
                    for(int i = 0; i < 5; i++)
                    {
                        kan2[i]=kan1[i];
                    }
                }
                else
                {
                    for(int i = 0; i < kan1.Length; i++)
                    {
                        kan2[i]=kan1[i];
                    }
                }
                
                    foreach (string x in kan2)
                    {
                        Console.Write(x + " ");
                        
                    }
                    Console.WriteLine();
                foreach (int x in mas)
                {
                    Console.Write(x + " ");

                }

                return kan2;
            }
           
            private string Geta1(Response a, int question)
            {
                string a1;
                switch (question)
                {
                    case 1:
                        a1 = a.Animal;
                        return a1;
                    case 2:
                        a1 = a.CharacterTrait;
                        return a1;
                    case 3:
                        a1 = a.Concept;
                        return a1;
                    default:
                        return null;
                }
            }
            public void Print()
            {
                for(int i=0; i < 3; i++)
                {
                    string[] answer = GetTopResponses(i);
                    foreach (string x in answer)
                    {
                        Console.Write(answer + " ");
                    }
                    Console.WriteLine();
                }
                
            }
        }

    }
}
