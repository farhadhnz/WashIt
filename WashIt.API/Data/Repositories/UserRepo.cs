using Microsoft.EntityFrameworkCore;
using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public class UserRepo : BaseRepo, IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async void CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user);
            await SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var userItem = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return userItem;
        }
    }
}