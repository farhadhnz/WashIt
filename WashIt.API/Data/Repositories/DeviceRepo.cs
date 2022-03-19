using Microsoft.EntityFrameworkCore;
using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public class DeviceRepo : BaseRepo, IDeviceRepo
    {
        private readonly AppDbContext _context;
        public DeviceRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async void CreateDeviceAsync(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            await _context.Devices.AddAsync(device);
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _context.Devices.ToListAsync();
        }
    }
}