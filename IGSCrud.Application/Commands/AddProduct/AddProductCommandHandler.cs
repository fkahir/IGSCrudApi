using System.Threading;
using System.Threading.Tasks;
using IGSCrud.Application.Common.Responses;
using IGSCrud.Application.Common.Validators;
using IGSCrud.Application.Extensions;
using IGSCrud.Persistence.Entities;
using IGSCrud.Persistence.Repositories;
using MediatR;

namespace IGSCrud.Application.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductResponse>
    {
        private ProductDbContext dbContext { get; set; }
        public AddProductCommandHandler(ProductDbContext context)
        {
            dbContext = context;
        }
        public async Task<ProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Guard.AgainstNullArgument(request, nameof(request));
        
            var product = new ProductEntity
            {
                Name = request.Name,
                Price = request.Price
            };

            dbContext.Products.Add(product);

            await dbContext.SaveChangesAsync(cancellationToken);

            return product.ToProductResponse();
        }
    }
}
