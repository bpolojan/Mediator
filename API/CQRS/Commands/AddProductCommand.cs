using API.DataStore;
using MediatR;

namespace API.CQRS.Commands
{    
    public record AddProductCommand(Product product) : IRequest<Product>;

    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private FakeDataStore _fakeDataStore;

        public AddProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.product);
            return request.product;
        }      
    }
}
