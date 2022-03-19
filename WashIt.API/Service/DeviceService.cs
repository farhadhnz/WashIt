using WashIt.API.Data.Repositories;
using WashIt.API.Models;

namespace WashIt.API.Service
{
    public class DeviceService : BaseService, IDeviceService
    {
        private readonly IDeviceRepo deviceRepo;
        public DeviceService(IBaseRepo baseRepo, IDeviceRepo deviceRepo) : base(baseRepo)
        {
            this.deviceRepo = deviceRepo;
        }

        public void CreateDeviceAsync(Device device)
        {
            deviceRepo.CreateDeviceAsync(device);
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await deviceRepo.GetAllDevicesAsync();
        }
    }
}