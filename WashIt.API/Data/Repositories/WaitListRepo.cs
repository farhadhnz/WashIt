using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public class WaitListRepo : BaseRepo, IWaitListRepo
    {
        private readonly AppDbContext _context;

        public WaitListRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async void CreateWaitingListItem(WaitingListItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.WaitingListItems.Add(item);
            await SaveChangesAsync();
        }
    }
}