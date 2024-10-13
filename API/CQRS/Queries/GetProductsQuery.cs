using API.DataStore;
using MediatR;

namespace API.CQRS.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;    

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetProducts();
        }
    }
}
