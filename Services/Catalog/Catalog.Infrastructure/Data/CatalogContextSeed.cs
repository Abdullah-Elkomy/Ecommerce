using Catalog.Core.Entities;
using MongoDB.Driver;
using System.IO;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool ckeckProducts = productCollection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!ckeckProducts)
            {
                //var productsData = File.ReadAllText(path);
                var productsData = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null)
                {
                    foreach (var type in products)
                        productCollection.InsertOneAsync(type);
                }
            }
        }
    }
}
