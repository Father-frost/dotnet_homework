namespace DecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Decorator Design Pattern
            IWorker worker = new Worker();
            IWorker monthBonusDecorator = new MonthBonusDecorator(worker);
            IWorker difficultyBonusDecorator = new DifficultyBonusDecorator(monthBonusDecorator);
            IWorker exportBonusDecorator = new ExportBonusDecorator(difficultyBonusDecorator);

            Console.WriteLine(exportBonusDecorator.GetBonusType());
        }
    }

    // base interface
    interface IWorker
    {
        string GetBonusType();
    }

    // specific implementation
    class Worker : IWorker
    {
        public string GetBonusType()
        {
            return "Standard rate: 1000";
        }
    }

    // base decorator
    class WorkerDecorator: IWorker
    {
        private IWorker _worker;

        public WorkerDecorator(IWorker worker)
        {
            _worker = worker;
        }

        //base virtual method for overriding
        public virtual string GetBonusType() 
        {
            return _worker.GetBonusType();
        }
    }

    // specific decorators
    //month bonus for worker
    class MonthBonusDecorator : WorkerDecorator
    {
        public MonthBonusDecorator(IWorker worker) : base(worker) { }

        public override string GetBonusType()
        {
            string type = base.GetBonusType();
            type += "\r\n Month bonus: +15%";
            return type;
        }
    }

    //difficulty bonus
    class DifficultyBonusDecorator : WorkerDecorator
    {
        public DifficultyBonusDecorator(IWorker worker) : base(worker) { }

        public override string GetBonusType()
        {
            string type = base.GetBonusType();
            type += "\r\n Difficulty bonus: +10%";
            return type;
        }
    }

    //export bonus
    class ExportBonusDecorator : WorkerDecorator
    {
        public ExportBonusDecorator(IWorker worker) : base(worker) { }

        public override string GetBonusType()
        {
            string type = base.GetBonusType();
            type += "\r\n Export bonus: +20%";
            return type;
        }
    }
}
