using WashIt.API.Data.Repositories;

namespace WashIt.API.Service
{
    public class BaseService : IBaseService
    {
        private readonly IBaseRepo baseRepo;
        public BaseService(IBaseRepo baseRepo)
        {
            this.baseRepo = baseRepo;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await baseRepo.SaveChangesAsync();
        }
    }
}