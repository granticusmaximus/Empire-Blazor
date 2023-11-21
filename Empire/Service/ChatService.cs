using Empire.Models;

namespace Empire.Service
{
    public class ChatService : IChatService
    {
        private readonly IMessagesPublisher _publisher;
        private readonly IMessagesConsumer _consumer;

        public ChatService(IMessagesPublisher publisher, IMessagesConsumer consumer)
        {
            _publisher = publisher;
            _consumer = consumer;
            _consumer.MessageReceived += OnMessage;
        }

        private void OnMessage(object sender, Message message)
        {
            this.MessageReceived?.Invoke(this, message);
        }

        public event EventHandler<Message> MessageReceived;

        public IEnumerable<User> GetAllUsers() => _usersProvider.GetAll();

        public async Task PostMessageAsync(User user, string message)
        {
            await _publisher.PublishAsync(new Message(user.Username, message, DateTime.UtcNow));
        }
    }
}
