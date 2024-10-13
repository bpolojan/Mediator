using API.DataStore;
using MediatR;

namespace API.CQRS.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;

    public class GetPersonsByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetPersonsByIdQueryHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetProductById(request.id);
        }
    }
}
