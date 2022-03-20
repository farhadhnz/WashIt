using WashIt.API.Data.Repositories;
using WashIt.API.Models;

namespace WashIt.API.Service
{
    public class WaitListService : BaseService, IWaitListService
    {
        private readonly IWaitListRepo waitListRepo;

        public WaitListService(IBaseRepo baseRepo, IWaitListRepo waitListRepo) : base(baseRepo)
        {
            this.waitListRepo = waitListRepo;
        }

        public void CreateWaitingListItem(WaitingListItem item)
        {
            waitListRepo.CreateWaitingListItem(item);
        }
    }
}