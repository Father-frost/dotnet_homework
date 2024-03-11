namespace WorkDivision
{
    public class Worker
    {
        public int _id;
        public string _name;
        public string _description;
        public int _rank;
        public bool _isDriver;

        public int GetBonusPercent(int rank) 
        {

            switch (rank)
            {
                case 1: return 10;
                case 2: return 20;
                case 3: return 30;
                default: return 0;
            }
            
        }


    }
}
