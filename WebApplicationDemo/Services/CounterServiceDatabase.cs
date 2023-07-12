using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Database;
using WebApplicationDemo.Services.Interfaces;

namespace WebApplicationDemo.Services
{
    public class CounterServiceDatabase : ICounterServiceAsync
    {
        private DatabaseContext _databaseContext;

        public CounterServiceDatabase(DatabaseContext databaseContext) 
        {
            _databaseContext = databaseContext;
        }

        public void Initialize()
        {
            var hasValues = _databaseContext.Counters.AsNoTracking().Any();
            if (hasValues == false)
            {
                _databaseContext.Counters.Add(new Database.Entities.CounterEntity()
                {
                    Counter = 1
                });

                _databaseContext.SaveChanges();
            }
        }

        public async Task<int> GetCounter()
        {
            return await _databaseContext.Counters.AsNoTracking().Select(counter => counter.Counter).FirstAsync();
        }

        public async Task Increment()
        {
            var firstEntry = await _databaseContext.Counters.FirstAsync();
            firstEntry.Counter++;

            await _databaseContext.SaveChangesAsync();
        }
    }
}
