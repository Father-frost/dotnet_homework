namespace interface_segregation_demo
{   
    //Class must not have to implement any interface method that is not required
    //Interface should be split into several smaller more specific interfaces 
    public interface IWorker
    {
        public void GetSalary();    //for salary
    }

    public interface IShiftWorker: IWorker 
    {
        public void GetNightBonus();    //for night shifts
    }

    public interface IOfficeWorker: IWorker 
    { 
        public void GetMonthBonus();      //for month bonus
    }
}
