namespace WashIt.API.Service
{
    public interface IBaseService
    {
        Task<bool> SaveChangesAsync();
    }
}