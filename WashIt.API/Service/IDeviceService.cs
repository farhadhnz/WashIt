using WashIt.API.Models;

namespace WashIt.API.Service
{
    public interface IDeviceService : IBaseService
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();

        void CreateDeviceAsync(Device device);
    }
}