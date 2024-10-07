using LinkDev.Talabat.Core.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbcontext)
        {
            if (!dbcontext.Brand.Any())
            {
                //var currentDirectory = Directory.GetCurrentDirectory();  

                //var brandsData = await File.ReadAllBytesAsync("@C:\\Users\\hp\\Downloads\\LinkDev.Talabat\\LinkDev.Talabat.Infrastructure.Persistence\\_Data\\Seeds\\");
                //var brandsData = await File.ReadAllBytesAsync($"{currentDirectory}/Data/Seeds/brands.json");

                // Correct path to the JSON file containing the data
                var brandsData = await File.ReadAllBytesAsync("../LinkDev.Talabat.Infrastructure.Persistence/_Data/Seeds/brands.json");

                //var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData).Select(b => new ProductBrand()
                //{
                //    Name = b.Name,
                //    CreatedOn = b.CreatedOn,
                //    CreatedBy = b.CreatedBy,
                //    LastModifiedBy = b.LastModifiedBy,
                //    LastModifiedOn = b.LastModifiedOn,
                //});

                // Check if there are any brands to add
                //if (brands.Count())
                //{
                //    await dbcontext.Set<ProductBrand>().AddRangeAsync(brands); // Add brands in bulk
                //    await dbcontext.SaveChangesAsync(); // Save changes to the database
                //}





                // The following commented code is kept for manual addition if needed
                //foreach (var brand in brands)
                //{
                //    await dbcontext.Brand.AddAsync(brand);
                //}
                //await dbcontext.SaveChangesAsync();
            }
        }
    }
}
