using Cache_Aside_Pattern.IServices;

namespace Cache_Aside_Pattern.Services
{
    public class ApplicationService : IApplicationService
    {

        private readonly ICacheService _cacheService;

        public ApplicationService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public string GetData(string key)
        {
            return _cacheService.GetOrSet<string>(key, () => YourDataFetchingMethod(key), TimeSpan.FromMinutes(10));
        }

        private string YourDataFetchingMethod(string key)
        {
            // Implement the logic to fetch data from the source (database, API, etc.)
            // This method will only be called if the data is not found in the cache.
            return Guid.NewGuid().ToString();
        }

        public void RemoveData(string key)
        {
            _cacheService.Remove(key);
        }
    }
}

