using IGSCrud.Application.Common.Responses;
using IGSCrud.Persistence.Entities;

namespace IGSCrud.Application.Extensions
{
    public static class ProductEntityExtension
    {
        public static ProductResponse ToProductResponse(this ProductEntity entitiy) => new ProductResponse
        {
            Id = entitiy.Id,
            Name = entitiy.Name,
            Price = entitiy.Price.ToString()
        };
    }
}
