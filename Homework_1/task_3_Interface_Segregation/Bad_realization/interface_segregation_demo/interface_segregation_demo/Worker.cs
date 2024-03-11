namespace interface_segregation_demo
{
    //Specialist haven't night shifts, that's why GetNightBonus() is unnecessary method
    public class Specialist: IWorker
    {
        public void GetMonthBonus() { }
        public void GetNightBonus() { }   //Has no night shift
        public void GetSalary() { }
    }

    public class CheesseMaker : IWorker 
    {
        public void GetMonthBonus() { }
        public void GetNightBonus() { }
        public void GetSalary() { }
    }

    public class Intern: IWorker
    {
        public void GetMonthBonus() { }   //Has no month bonus
        public void GetNightBonus() { }   //Has no night shift
        public void GetSalary() { }
    }

}
