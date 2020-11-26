using System;
using System.Data.Entity.Core;
using System.Threading.Tasks;
using IGSCrud.Application.Commands.AddProduct;
using IGSCrud.Application.Commands.DeleteProduct;
using IGSCrud.Application.Commands.UpdateProduct;
using IGSCrud.Application.Queries.GetProduct;
using IGSCrud.Application.Queries.GetProducts;
using IGSCrud.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IGSCrud.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController (IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Route("~/v1/Products")]
        public async Task<IActionResult> Get()
        {
            var query = new GetProductsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var query = new GetProductQuery
                {
                    Id = id
                };

                var result = await _mediator.Send(query);
                
                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"There was a problem processing this request. {ex.Message}");
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductDto model)
        {
            var command = new AddProductCommand
            {
                Name = model.Name,
                Price = model.Price
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound("Product not found");
            }
            else 
            {
                return Ok(result);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ProductDto model)
        {
            var command = new UpdateProductCommand
            {
                Id = id,
                Name = model.Name
            };

            try
            {
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return NotFound("Product not found");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "There was a problem processing this request.");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteProductCommand
                {
                    Id = id
                };

                await _mediator.Send(command);

                return Ok($"Product with Id: {id} was deleted");
            }
            catch(ObjectNotFoundException)
            {
                return NotFound("Product with Id: {id} not found");
            }
            catch(Exception)
            {
                return StatusCode(500, "There was a problem processing this request.");
            }
        }
    }
}
