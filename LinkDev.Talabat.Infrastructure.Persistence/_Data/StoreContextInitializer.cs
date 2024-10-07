using LinkDev.Talabat.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data
{
    //class Test {
    //    public Test()
    //    {
    //        StoreContextInitializer storeContextInitializer = new StoreContextInitializer();
    //        storeContextInitializer.
    //    }
    //}
    internal class StoreContextInitializer(StoreContext _dbContext) : IStoreContextInitializer
    {
        public StoreContext StoreContext { get; set; } = _dbContext;
        private readonly StoreContext _dbContext;

        //public async Task StoreContextInitializer(StoreContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public async Task InitializeAsync()
        {
            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
                await _dbContext.Database.MigrateAsync(); // Update-Database
        }

        public async Task SeedAsync()
        {
            if (!_dbContext.Brand.Any())
            {
                //var currentDirectory = Directory.GetCurrentDirectory();  

                //var brandsData = await File.ReadAllBytesAsync("@C:\\Users\\hp\\Downloads\\LinkDev.Talabat\\LinkDev.Talabat.Infrastructure.Persistence\\_Data\\Seeds\\");
                //var brandsData = await File.ReadAllBytesAsync($"{currentDirectory}/Data/Seeds/brands.json");

                // Correct path to the JSON file containing the data
                var brandsData = await File.ReadAllBytesAsync("../LinkDev.Talabat.Infrastructure.Persistence/_Data/Seeds/brands.json");

                // Uncomment and complete this section to deserialize and add brands
                //var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData).Select(b => new ProductBrand()
                //{
                //    Name = b.Name,
                //    CreatedOn = b.CreatedOn,
                //    CreatedBy = b.CreatedBy,
                //    LastModifiedBy = b.LastModifiedBy,
                //    LastModifiedOn = b.LastModifiedOn,
                //});

                // Check if there are any brands to add
                //if (brands.Any())
                //{
                //    await _dbContext.Set<ProductBrand>().AddRangeAsync(brands); // Add brands in bulk
                //    await _dbContext.SaveChangesAsync(); // Save changes to the database
                //}

                // The following commented code is kept for manual addition if needed
                //foreach (var brand in brands)
                //{
                //    await _dbContext.Brand.AddAsync(brand);
                //}
                //await _dbContext.SaveChangesAsync();
            }
        }
    }
}
