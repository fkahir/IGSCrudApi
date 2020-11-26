using System.Data.Entity.Core;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IGSCrud.Application.Common.Validators;
using IGSCrud.Persistence.Repositories;
using MediatR;

namespace IGSCrud.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private ProductDbContext dbContext { get; set; }
        public DeleteProductCommandHandler(ProductDbContext context)
        {
            dbContext = context;
        }


        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Guard.AgainstNullArgument(request, nameof(request));
            
            var product = dbContext.Products.FirstOrDefault(p => p.Id == request.Id);

            if (product == null)
            {
                throw new ObjectNotFoundException($"No product with {request.Id} was found in the database");
            }
            
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
