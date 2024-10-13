using MediatorApi.DataStore;
using Mediator;

namespace MediatorApi.CQRS.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;    

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async ValueTask<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetProducts();
        }
    }
}
