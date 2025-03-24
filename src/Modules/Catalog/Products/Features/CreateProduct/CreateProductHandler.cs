namespace Catalog.Products.Features.CreateProduct
{
    public record CreateProductCommand(ProductDto Product)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler(CatalogDbContext dbContext) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Product product = CreateNewProduct(command.Product);
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new CreateProductResult(product.Id);
        }

        private static Product CreateNewProduct(ProductDto productDto)
        {
            Product product = Product.Create(productDto.Id, productDto.Name, productDto.Categories,
                productDto.Description, productDto.ImageFile, productDto.Price);
            return product;
        }
    }
}
