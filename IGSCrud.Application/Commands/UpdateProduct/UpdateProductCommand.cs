using IGSCrud.Application.Common.Responses;
using MediatR;

namespace IGSCrud.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
