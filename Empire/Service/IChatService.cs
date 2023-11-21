using Empire.Models;

namespace Empire.Service
{
    public interface IChatService
    {
        event EventHandler<Message> MessageReceived;

        IEnumerable<ApplicationUser> GetAllUsers();
        Task PostMessageAsync(ApplicationUser user, string message);
    }
}
