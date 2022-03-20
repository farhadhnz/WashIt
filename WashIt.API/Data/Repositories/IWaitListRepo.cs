using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public interface IWaitListRepo : IBaseRepo
    {
        void CreateWaitingListItem(WaitingListItem item);
        Task<IEnumerable<WaitingListItem>> GetWaitingListItems(DateOnly date);
        void SetUserAsNotified(WaitingListItem waitingListItem);
    }
}