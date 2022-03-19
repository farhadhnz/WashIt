using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public interface IDeviceRepo : IBaseRepo
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();

        void CreateDeviceAsync(Device device);
    }
}