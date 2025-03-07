namespace Lab_6;

public class Blue_3
{
    public struct Participant
    {
        private string _name;
        private string _lastname;
        private int[] _minutes;
        
        public readonly string Name => _name;
        public readonly string Lastname => _lastname;

        public Participant(string name, string lastname)
        {
            this._name = name;
            this._lastname = lastname;
            this._minutes = new int[10];
        }
        
        public readonly int[] PenaltyTimes
        {
            get
            {
                if (_minutes == null) return new int[]{};
                return _minutes;
            }
        }

        public readonly int TotalTime
        {
            get
            {
                if (this._minutes == null || this._minutes.Length == 0) return 0;
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

                for (int i = 0; i < this._minutes.Length; i++)
                {
                    if (this._minutes[i] == 10) return false;
                }

                return true;
            }
        }

        public void PlayMatch(int time)
        {
            if (this._minutes == null) return;

            for (int i = 0; i < this._minutes.Length; i++)
            {
                if (this._minutes[i] == 0)
                {
                    this._minutes[i] = time;
                    break;
                }
            }
        }

        public static void Sort(Participant[] arr)
        {
            if (arr == null) return;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].TotalTime < arr[j - 1].TotalTime)
                    {
                        Participant temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("{0} {1} {2}", this.Name, this.Lastname, this.TotalTime);
        }
    }
}