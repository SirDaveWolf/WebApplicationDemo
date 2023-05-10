namespace WebApplicationDemo.Services
{
    public class CounterService : Interfaces.ICounterService
    {
        private int _counter;

        public CounterService() 
        {
            _counter = 0;
        }

        public int GetCounter()
        {
            return _counter;
        }

        public void Increment()
        {
            _counter++;
        }
    }
}
