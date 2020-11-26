using IGSCrud.Application.Common.Responses;
using MediatR;

namespace IGSCrud.Application.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}
