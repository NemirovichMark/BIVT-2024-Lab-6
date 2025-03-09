namespace Lab_6;

public class Blue_2
{
    public struct Participant
    {
        private string _name;
        private string _lastname;
        private int[,] _marks;

        public readonly string Name => _name;
        public readonly string Surname => _lastname;

        public readonly int[,] Marks
        {
            get
            {
                if (_marks == null) return new int[2, 5];
                return _marks;
            }
        }
        
        public Participant(string name, string lastname)
        {
            this._name = name;
            this._lastname = lastname;
            this._marks = new int[2, 5];
        }
        
        public int TotalScore {
            get
            {
                if (_marks == null || (_marks.GetLength(0) == 0 && _marks.GetLength(1) == 0)) return 0;

                int summa = 0;
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        summa += _marks[i, j];
                    }
                }

                return summa;
            }
        }

        public void Jump(int[] result)
        {
            if (result == null || this._marks == null) return;

            for (int i = 0; i < this._marks.GetLength(0); i++)
            {
                bool isTrue = false;
                for (int j = 0; j < this._marks.GetLength(1); j++)
                {
                    if (this._marks[i, j] != 0) isTrue = true;
                }

                if (isTrue) continue;
                else
                {
                    for (int j = 0; j < this._marks.GetLength(1); j++)
                    {
                        this._marks[i, j] = result[j];
                    }

                    break;
                }
            }
        }

        public static void Sort(Participant[] array)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].TotalScore > array[j - 1].TotalScore)
                    {
                        Participant temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            
        }

        public void Print()
        {
            Console.WriteLine("{0} {1} {2}", this._name, this._lastname, this.TotalScore);
        }
    }
}