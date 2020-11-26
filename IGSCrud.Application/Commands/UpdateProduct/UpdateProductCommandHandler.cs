using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IGSCrud.Application.Common.Responses;
using IGSCrud.Application.Common.Validators;
using IGSCrud.Application.Extensions;
using IGSCrud.Persistence.Repositories;
using MediatR;

namespace IGSCrud.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private ProductDbContext dbContext { get; set; }
        public UpdateProductCommandHandler(ProductDbContext context)
        {
            dbContext = context;
        }

        public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Guard.AgainstNullArgument(request, nameof(request));
            
            var product = dbContext.Products.FirstOrDefault(p => p.Id == request.Id);

            if (product == null)
            {
                return null;
            }

            product.Name = request.Name;

            await dbContext.SaveChangesAsync(cancellationToken);

            return product.ToProductResponse();
        }
    }
}
