using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public interface IUserRepo : IBaseRepo
    {
        void CreateUser(User user);

        Task<User> GetUserById(int id);
    }
}