using WashIt.API.Models;

namespace WashIt.API.Service
{
    public interface IWaitListService : IBaseService
    {
        void CreateWaitingListItem(WaitingListItem item);
    }
}