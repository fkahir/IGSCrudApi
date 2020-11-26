using IGSCrud.Application.Common.Responses;
using MediatR;

namespace IGSCrud.Application.Commands.AddProduct
{
    public class AddProductCommand : IRequest<ProductResponse>
    { 
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
