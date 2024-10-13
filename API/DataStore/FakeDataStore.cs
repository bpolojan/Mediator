using System.Collections;

namespace API.DataStore
{
    public class FakeDataStore
    {
        private List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product(){ Id=1, Name= "MyProduct"},
                new Product(){ Id=2, Name= "MyProduct1"},
                new Product(){ Id=3, Name= "MyProduct2"},
                new Product(){ Id=4, Name= "MyProduct3"},
            };
        }

        public async Task AddProduct(Product prod)
        {
            _products.Add(prod);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await Task.FromResult(_products.FirstOrDefault(x => x.Id == id));
        }

        public async Task EventOccured(Product product, string @event)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {@event}";
        }
    }
}
