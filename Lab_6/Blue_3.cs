namespace Lab_6;

public class Blue_3
{
    public struct Participant
    {
        private string _name;
        private string _lastname;
        private int[] _minutes;
        private bool _isExpelled;
        
        public readonly string Name => _name;
        public readonly string Surname => _lastname;

        public Participant(string name, string lastname)
        {
            this._name = name;
            this._lastname = lastname;
            this._minutes = new int[]{};
            this._isExpelled = true;
        }
        
        public readonly int[] PenaltyTimes
        {
            get
            {
                if (this._minutes == null) return null;
                int[] arr = new int[this._minutes.Length];
                for (int i = 0; i < this._minutes.Length; i++)
                {
                    arr[i] = this._minutes[i];
                }
                return arr;
            }
        }

        public readonly int TotalTime
        {
            get
            {
                if (this._minutes == null) return 0;
                int res = 0;
                for (int i = 0; i < this._minutes.Length; i++)
                {
                    res += this._minutes[i];
                }

                return res;
            }
        }

        public bool isExpelled
        {
            get
            {
                if (this._minutes == null || this._minutes.Length == 0) return false;

                return this._isExpelled;
            }
        }

        public void PlayMatch(int time)
        {
            if (this._minutes == null) return;
            if (time == 10) this._isExpelled = false;
            
            int[] arr = new int[this._minutes.Length + 1];
            for (int i = 0; i < this._minutes.Length; i++)
            {
                arr[i] = this._minutes[i];
            }
            this._minutes = arr;
            arr[this._minutes.Length - 1] = time;
        }

        public static void Sort(Participant[] arr)
        {
            if (arr == null) return;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j + 1].TotalTime < arr[j].TotalTime)
                    {
                        Participant temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("{0} {1} {2}", this.Name, this.Surname, this.TotalTime);
        }
    }
}