using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public interface IWashingModeRepo : IBaseRepo
    {
        void CreateWashingMode(WashingMode washingMode);

        Task<WashingMode> GetWashingModeById(int id);
    }
}