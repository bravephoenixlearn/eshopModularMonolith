namespace Catalog.Products.Features.UpdateProduct
{
    public record UpdateProductComamnd(ProductDto Product)
        : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    internal class UpdateProductHandler(CatalogDbContext dbContext) : ICommandHandler<UpdateProductComamnd, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductComamnd command, CancellationToken cancellationToken)
        {
            var product = await dbContext.Products.FindAsync([command.Product.Id], cancellationToken);

            if (product is null)
                throw new Exception($"Product not found: {command.Product.Id}");

            UpdateProductWithNewValues(product, command.Product);
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return new UpdateProductResult(true);
        }

        private void UpdateProductWithNewValues(Product product, ProductDto productDto)
        {
            product.Update(productDto.Name, productDto.Categories, productDto.Description, productDto.ImageFile, productDto.Price);
        }
    }
}
