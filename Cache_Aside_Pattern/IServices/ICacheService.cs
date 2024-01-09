namespace Cache_Aside_Pattern.IServices
{
    public interface ICacheService
    {
        T GetOrSet<T>(string key, Func<T> getItemCallback, TimeSpan cacheDuration);
        void Remove(string key);
    }
}
