namespace Lab_6{

    public class Purple_3
    {
        public struct Participant
         {
            private string _Name;
            private string _Surname;
            private double[] _Marks;
            private int[] _Places;
            private int _NextMark;

            public string Name => _Name;
            public string Surname => _Surname;
            public double[] Marks 
            {
                get{
                    double[] copy = new double[_Marks.Length];
                    Array.Copy(_Marks, copy, _Marks.Length);
                    return copy;
                }
            }
            public int[] Places
            {
                get{
                    int[] copy = new int[_Places.Length];
                    Array.Copy(_Places, copy, _Places.Length);
                    return copy;
                }
            }
            public Participant(string name, string surname){
                _Name = name;
                _Surname = surname;
                _Marks = new double[7];
                _Places = new int[7];
            }
            public void Evaluate(double result){
                if (_NextMark < _Marks.Length){
                    _Marks[_NextMark++] = result;
                }

            }

            public static void SetPlaces(Participant[] participants){
                for (int judge = 0; judge < participants[0]._Marks.Length; judge++){
                    double[] scores = new double[participants.Length];

                    for (int i = 0; i < participants.Length; i++){
                        scores[i] = participants[i]._Marks[judge];
                    }

                    int[] sortedIndexes = new int[participants.Length];
                    for (int i = 0; i < participants.Length; i++){
                        sortedIndexes[i] = i;
                    }

                    Array.Sort(scores, sortedIndexes);
                    Array.Reverse(sortedIndexes); 

                    for (int i = 0; i < participants.Length; i++){
                        participants[sortedIndexes[i]]._Places[judge] = i + 1;
                    }
                }
            }
            public int Score{
                get{
                    int sum = 0;
                    for (int i = 0; i < _Places.Length; i++){
                        sum += _Places[i];
                    }
                    return sum;
                }
            }
            public double Marks_score{
                get{
                    double sum = 0;
                    for (int i = 0; i < _Places.Length; i++){
                        sum += _Marks[i];
                    }
                    return sum;
                }
            }

            public static void Sort(Participant[] array){
                Array.Sort(array, (p1, p2) => {
                    int sPlaces1 = p1.Score;
                    int sPlaces2 = p2.Score;

                    if (sPlaces1 != sPlaces2){
                        return sPlaces1.CompareTo(sPlaces2); 
                    }

                    for (int i = 0; i < p1.Places.Length; i++) {
                        if (p1.Places[i] < p2.Places[i]) return -1; 
                        if (p1.Places[i] > p2.Places[i]) return 1; 
                    }

                    double sMarks1 = p1.Marks_score;
                    double sMarks2 = p2.Marks_score;

                    return sMarks2.CompareTo(sMarks1);
                });
            }
            public void Print(){
                Console.WriteLine($"{_Name,-12} {_Surname,-12} {Score,-10} {Places.Min(),-8} {Math.Round(Marks.Sum(),2),-7}");
            }
        }
    }
 }
            