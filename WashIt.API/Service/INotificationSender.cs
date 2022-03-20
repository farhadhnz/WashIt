using WashIt.API.Models;

namespace WashIt.API.Service
{
    public interface INotificationSender
    {
        void Send(User user);
    }
}