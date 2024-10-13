using Mediator;
using MediatorApi.CQRS.Commands;
using MediatorApi.CQRS.Queries;
using MediatorApi.DataStore;
using MediatorApi.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace MediatorApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;      
        IPublisher _publisher;

        public ProductsController(IPublisher publisher, IMediator mediator)
        {
            _publisher = publisher;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            // We don't have a dependency on Fake DataStore - don't know how the query was handeled
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));
         
            await _mediator.Publish(new ProductAddedNotification(product));
            return StatusCode(201);
            //return CreatedAtRoute("GetProductById", new { id = product.Id, productToReturn});
            // Unexpected .Net Error

        }
    }
}
