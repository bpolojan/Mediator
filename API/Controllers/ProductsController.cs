using API.CQRS.Commands;
using API.CQRS.Queries;
using API.DataStore;
using API.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;
        ISender _sender;
        IPublisher _publisher;

        public ProductsController(IPublisher publisher, ISender sender)
        {
            _publisher = publisher;
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            // We don't have a dependency on Fake DataStore - don't know how the query was handeled
            var products = await _sender.Send(new GetProductsQuery());
                return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {            
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {            
            var productToReturn = await _sender.Send(new AddProductCommand(product));
            await _publisher.Publish(new ProductAddedNotification(product));
            return StatusCode(201);
            //return CreatedAtRoute("GetProductById", new { id = product.Id, productToReturn});
            // Unexpected .Net Error

        }
    }
}
