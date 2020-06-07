using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest
        {
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
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Command, Product>(request);

                _context.Products.Add(product);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving a new company");
            }
        }
    }
}