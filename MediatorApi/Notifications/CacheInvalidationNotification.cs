using MediatorApi.DataStore;
using Mediator;

namespace MediatorApi.Notifications
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private FakeDataStore _fakeDataStore;

        public CacheInvalidationHandler(FakeDataStore fakeDataStore)
        {
            this._fakeDataStore = fakeDataStore;
        }       

        public async ValueTask Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
