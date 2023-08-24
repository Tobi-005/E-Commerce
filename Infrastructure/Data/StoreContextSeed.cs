

using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsName=File.ReadAllText("../Infrastructure/Data/Seeding/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsName);
                context.ProductBrands.AddRange(brands);
            }

            if (!context.Products.Any())
            {
                var productData=File.ReadAllText("../Infrastructure/Data/Seeding/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                context.Products.AddRange(products);
            }

            if (!context.ProductTypes.Any())
            {
                var typesData=File.ReadAllText("../Infrastructure/Data/Seeding/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }

            if (context.ChangeTracker.HasChanges()) 
                await context.SaveChangesAsync();
        }
    }
}