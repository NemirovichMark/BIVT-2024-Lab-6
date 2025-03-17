namespace Lab_6;

public class Blue_2
{
    public struct Participant
    {
        private string _name;
        private string _lastname;
        private int[,] _marks;
        private int _count;

        public readonly string Name => _name;
        public readonly string Surname => _lastname;

        public readonly int[,] Marks
        {
            get
            {
                if (this._marks == null) return null;
                
                int[,] arr = new int[this._marks.GetLength(0), this._marks.GetLength(1)];
                
                for (int i = 0; i < this._marks.GetLength(0); i++)
                {
                    for (int j = 0; j < this._marks.GetLength(1); j++)
                    {
                        arr[i, j] = this._marks[i, j];
                    }
                }
                return arr;

            }
        }
        
        public Participant(string name, string lastname)
        {
            this._name = name;
            this._lastname = lastname;
            this._marks = new int[2, 5];
            this._count = 0;
        }
        
        public int TotalScore {
            get
            {
                if (this._marks == null || (this._marks.GetLength(0) == 0 && this._marks.GetLength(1) == 0)) return 0;
    
                int summa = 0;
                for (int i = 0; i < this._marks.GetLength(0); i++)
                {
                    for (int j = 0; j < this._marks.GetLength(1); j++)
                    {
                        summa += this._marks[i, j];
                    }
                }

                return summa;
            }
        }

        public void Jump(int[] result)
        {
            if (result == null || this._marks == null || this._count > 1) return;
            
            for (int j = 0; j < this._marks.GetLength(1); j++) { 
                if (this._count == 0) this._marks[0, j] = result[j];
                else if (this._count == 1) this._marks[1, j] = result[j];
            }

            this._count++;
        }

        public static void Sort(Participant[] array)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j + 1].TotalScore > array[j].TotalScore)
                    {
                        Participant temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
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