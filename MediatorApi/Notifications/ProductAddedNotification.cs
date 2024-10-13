using MediatorApi.DataStore;
using Mediator;

namespace MediatorApi.Notifications
{
    public record ProductAddedNotification(Product Product):INotification, IMessage;

    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private FakeDataStore _fakeDataStore;

        public EmailHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async ValueTask Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Email sent");
            await Task.CompletedTask;
        }
    }
}
