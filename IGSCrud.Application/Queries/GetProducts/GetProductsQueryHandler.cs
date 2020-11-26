using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IGSCrud.Application.Common.Responses;
using IGSCrud.Application.Common.Validators;
using IGSCrud.Persistence.Repositories;
using MediatR;

namespace IGSCrud.Application.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
    {
        private ProductDbContext dbContext { get; set; }
        public GetProductsQueryHandler(ProductDbContext context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            Guard.AgainstNullArgument(query, nameof(query));
            
            var products = dbContext.Products;

            if (products != null)
            {
                var productsDto = new List<ProductResponse>();
                foreach (var p in products)
                {
                    productsDto.Add(new ProductResponse
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price.ToString()
                    }); ;
                }

                return productsDto;
            }

            return null;
        }

    }
}
