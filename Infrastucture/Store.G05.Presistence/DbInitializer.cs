using Microsoft.EntityFrameworkCore;
using Store.G05.Domain.Contracts;
using Store.G05.Domain.Entities.Products;
using Store.G05.Presistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G05.Presistence
{
    public class DbInitializer(StoreDbContext _context) : IDbInitializer
    {
        

        public async Task InitializeAsync()
        {
            //Create Db
            //Update Db
            if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Any() ) {
                await _context.Database.MigrateAsync();
            }
            //Seed Data

            //ProductsBrand
            if (! _context.ProductBrands.Any()){

                // 1.Read All Data from Json File.        
                var brandsdata = await File.ReadAllTextAsync(@"..\Infrastucture\Store.G05.Presistence\Data\DataSeeding\brands.json");

                // 2. Converting the JsonString data to list<ProductBrands>
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);

                // 3. Add List to Db
                if (brands is not null && brands.Count() > 0)
                {
                    await _context.ProductBrands.AddRangeAsync(brands);
                }
              }

            //ProductsType
            if(! _context.ProductTypes.Any())
            {
                //1. Read the Data
                var typesdata = await File.ReadAllTextAsync(@"..\Infrastucture\Store.G05.Presistence\Data\DataSeeding\types.json");

                //2. Converting to List
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);

                //3. Add to Db
                if(types is not null && types.Count() >0)
                {
                    await _context.ProductTypes.AddRangeAsync(types);
                }
            }

            //Products
            if (! _context.Products.Any())
            {
                //1. Read the Data
                var productsdata = await File.ReadAllTextAsync(@"..\Infrastucture\Store.G05.Presistence\Data\DataSeeding\products.json");

                //2. Converting to List
                var products = JsonSerializer.Deserialize<List<Product>>(productsdata);

                //3. Add to Db
                if (products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
