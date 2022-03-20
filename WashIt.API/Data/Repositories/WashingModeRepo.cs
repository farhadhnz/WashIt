using Microsoft.EntityFrameworkCore;
using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public class WashingModeRepo : BaseRepo, IWashingModeRepo
    {
        private readonly AppDbContext _context;

        public WashingModeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async void CreateWashingMode(WashingMode washingMode)
        {
            if (washingMode == null)
                throw new ArgumentNullException(nameof(washingMode));

            _context.WashingModes.Add(washingMode);
            await SaveChangesAsync();
        }

        public async Task<WashingMode> GetWashingModeById(int id)
        {
            var washingModeItem = await _context.WashingModes.FirstOrDefaultAsync(x => x.Id == id);

            return washingModeItem;
        }
    }
}