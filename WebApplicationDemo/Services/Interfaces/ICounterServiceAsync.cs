namespace WebApplicationDemo.Services.Interfaces
{
    public interface ICounterServiceAsync
    {
        void Initialize();
        Task<int> GetCounter();
        Task Increment();
    }
}
