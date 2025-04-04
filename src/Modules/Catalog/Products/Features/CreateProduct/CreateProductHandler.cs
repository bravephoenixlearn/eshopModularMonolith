using FluentValidation;

namespace Catalog.Products.Features.CreateProduct
{
    public record CreateProductCommand(ProductDto Product)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Product.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Maximum length of 50 is allowed for Name");
            RuleFor(x => x.Product.Categories)
                .NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Product.Description)
                .MaximumLength(200).WithMessage("Maximum length of 200 is allowed for Description");
            RuleFor(x => x.Product.ImageFile)
                .NotEmpty().WithMessage("ImageFile is required")
                .MaximumLength(100).WithMessage("Maximum length of 10 is allowed for ImageFile");
            RuleFor(x => x.Product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

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
