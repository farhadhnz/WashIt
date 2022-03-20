using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<WaitingListItem>> GetWaitingListItems(DateOnly date)
        {
            var items = await _context.WaitingListItems
                            .Where(x => x.Date.Equals(date) && !x.Notified)
                            .ToListAsync();

            return items;
        }

        public async void SetUserAsNotified(WaitingListItem waitingListItem)
        {
            if (waitingListItem == null)
                throw new ArgumentNullException(nameof(waitingListItem));

            waitingListItem.Notified = true;
            await SaveChangesAsync();
        }
    }
}