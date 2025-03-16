using Catalog.Products.Models;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Events
{
    public record ProductCreatedEvent(Product product) : IDomainEvent;
}
