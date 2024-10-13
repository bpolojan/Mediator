using MediatorApi.DataStore;
using Mediator;

namespace   MediatorApi.CQRS.Commands
{
    public record AddProductCommand(Product product) : ICommand<Product>;

    public class AddProductHandler : ICommandHandler<AddProductCommand, Product>
    {
        private FakeDataStore _fakeDataStore;

        public AddProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async ValueTask<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.product);
            return request.product;
        }      
    }
}
