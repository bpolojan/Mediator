using API.DataStore;
using MediatR;
using System.Runtime.CompilerServices;

namespace API.Notifications
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private FakeDataStore _fakeDataStore;

        public CacheInvalidationHandler(FakeDataStore fakeDataStore)
        {
            this._fakeDataStore = fakeDataStore;
        }       

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }

}
