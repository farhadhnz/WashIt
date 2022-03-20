using WashIt.API.Models;

namespace WashIt.API.Service
{
    public class EmailSender : INotificationSender
    {
        public void Send(User user)
        {
            // Send an email to the user
            Console.WriteLine($"Sending Email to {user.Username}...");
        }
    }
}