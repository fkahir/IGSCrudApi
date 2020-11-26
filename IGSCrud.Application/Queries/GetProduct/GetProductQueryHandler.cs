using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IGSCrud.Application.Common.Responses;
using IGSCrud.Application.Common.Validators;
using IGSCrud.Persistence.Repositories;
using MediatR;

namespace IGSCrud.Application.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
    {
        private ProductDbContext dbContext { get; set; }
        public GetProductQueryHandler(ProductDbContext context)
        {
            dbContext = context;
        }

        public async Task<ProductResponse> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            Guard.AgainstNullArgument(query, nameof(query));
            
            if (query == null)
            {
                throw new ArgumentNullException($"Parameter {query} not found");
            }

            if (query.Id == 0)
            {
                throw new ArgumentException($"Id parameter cannot be null");
            }

            var product =  dbContext.Products.FirstOrDefault(p => p.Id == query.Id);

            if (product != null)
            {
                var productDto = new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price.ToString()
                };

                return productDto;
            }

            return null;

        }
    }
}
