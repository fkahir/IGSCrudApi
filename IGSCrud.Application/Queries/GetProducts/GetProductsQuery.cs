using System.Collections.Generic;
using IGSCrud.Application.Common.Responses;
using MediatR;

namespace IGSCrud.Application.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductResponse>>
    {
    }
}
