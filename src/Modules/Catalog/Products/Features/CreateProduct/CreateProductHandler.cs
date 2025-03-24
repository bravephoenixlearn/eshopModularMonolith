﻿using MediatR;

namespace Catalog.Products.Features.CreateProduct
{
    public record CreateProductCommand
        (string Name, List<string> Categories, string Description, string ImageFile, decimal Price)
        : IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
