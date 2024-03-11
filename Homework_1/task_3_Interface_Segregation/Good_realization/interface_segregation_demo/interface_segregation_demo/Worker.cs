namespace interface_segregation_demo
{
    //Specialist haven't night shifts, that's why GetNightBonus() is unnecessary method
    public class Specialist: IOfficeWorker
    {
        public void GetMonthBonus() { }
        public void GetSalary() { }
    }

    public class CheesseMaker : IOfficeWorker, IShiftWorker 
    {
        public void GetMonthBonus() { }
        public void GetNightBonus() { }
        public void GetSalary() { }
    }

    public class Intern: IWorker
    {
        public void GetSalary() { }
    }

}
