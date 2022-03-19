namespace WashIt.API.Data.Repositories
{
    public class BaseRepo : IBaseRepo
    {
        private readonly AppDbContext _context;
        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}