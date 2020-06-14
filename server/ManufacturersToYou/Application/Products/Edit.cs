using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; } // need Id here to get a specific company
            public string Name { get; set; }
            public string Description { get; set; }
            // public string Features { get; set; }
            public string Category { get; set; } // needs separate table as well
            public decimal? Price { get; set; }
            // public decimal? OldPrice { get; set; }
            public string ImageUrl { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.Id);

                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Errors = "Company not found in the database" });

                product.Name = request.Name ?? product.Name;
                product.Description = request.Description ?? product.Description;
                // product.Category = request.Category ?? product.Category;
                if (product.Price != request.Price && request.Price != null)
                {
                    product.OldPrice = product.Price;
                    product.Price = request.Price ?? product.Price;
                }
                // product.OldPrice = request.OldPrice ?? product.OldPrice;
                product.ImageUrl = request.ImageUrl ?? product.ImageUrl;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem editing the company");
            }
        }
    }
}