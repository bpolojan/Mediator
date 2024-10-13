using API.DataStore;
using MediatR;

namespace API.Notifications
{
    public record ProductAddedNotification(Product Product):INotification;

    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private FakeDataStore _fakeDataStore;

        public EmailHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Email sent");
            await Task.CompletedTask;
        }
    }

}
