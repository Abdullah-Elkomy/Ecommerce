using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = ProductMapper.Mapper.Map<Product>(request);
            if (product is null)
                throw new ValidationException("Error in mapping ur product");
            var newProduct = await _productRepository.CreateProduct(product);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            return productResponse;
        }
    }
}
