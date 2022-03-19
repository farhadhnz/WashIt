namespace WashIt.API.Data.Repositories
{
    public interface IBaseRepo
    {
        Task<bool> SaveChangesAsync();
    }
}