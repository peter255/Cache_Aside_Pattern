namespace Cache_Aside_Pattern.IServices
{
    public interface IApplicationService
    {
        string GetData(string key);

        void RemoveData(string key);
    }
}
