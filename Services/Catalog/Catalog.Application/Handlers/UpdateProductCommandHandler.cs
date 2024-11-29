using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.UpdateProduct(new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Summary = request.Summary,
                Brands = request.Brands,
                ImageFile = request.ImageFile,
                Price = request.Price,
                Types = request.Types,
            });
            return true;
        }
    }
}
