namespace interface_segregation_demo
{   
    //All in one..
    public interface IWorker
    {
        public void GetSalary();            //for salary
        public void GetMonthBonus();        //for month bonus
        public void GetNightBonus();        //for night shifts
    }
}
