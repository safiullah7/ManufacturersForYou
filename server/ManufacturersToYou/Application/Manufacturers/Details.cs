using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Manufacturers
{
    public class Details
    {
        public class Query : IRequest<ManufacturerDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ManufacturerDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ManufacturerDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var manufacturer = await _context.Manufacturers.FindAsync(request.Id);

                if (manufacturer == null)
                    throw new RestException(HttpStatusCode.NotFound, new {Manufaturer = "Manufacturer Not found with ID supplied"});

                return _mapper.Map<Manufacturer, ManufacturerDto>(manufacturer);
            }
        }
    }
}