﻿using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductsByName(string productName);
        Task<IEnumerable<Product>> GetProductsByBrand(string brandName);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);

    }
}
