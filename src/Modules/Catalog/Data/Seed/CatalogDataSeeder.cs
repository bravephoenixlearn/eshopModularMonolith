namespace Catalog.Data.Seed
{
    public class CatalogDataSeeder(CatalogDbContext catalogDbContext) 
        : IDataSeeder
    {
        public async Task SeedAllAsync()
        {
            if(!await catalogDbContext.Products.AnyAsync())
            {
                await catalogDbContext.Products.AddRangeAsync(ProductSeedData());
                await catalogDbContext.SaveChangesAsync();
            }
            ProductSeedData();
        }

        private static IEnumerable<Product> ProductSeedData()
        {
            List<Product> products = new List<Product>
            {
                Product.Create(new Guid("80ce7eee-16d6-4f15-836b-554202df018c"), "Samsung Galaxy S22 Ultra", ["category1"], "Released in 2022", null, 70_000),
                Product.Create(new Guid("d8a6fb88-892c-4ff2-8559-e07d000c47d5"), "Samsung Galaxy S23 Ultra", ["category1"], "Released in 2023", null, 80_000),
                Product.Create(new Guid("4d71663b-2d08-4001-a7ef-3ba8b2e9ed93"), "Samsung Galaxy S24 Ultra", ["category1"], "Released in 2024", null, 99_000),
                Product.Create(new Guid("a6e1095f-d724-4758-b33a-663a8e457c55"), "Samsung Galaxy S25 Ultra", ["category1"], "Released in 2025", null, 1_40_000)
            };
            return products;
        }
    }
}
