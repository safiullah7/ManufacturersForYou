using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Manufacturers
{
    public class List
    {
        public class ManufacturersEnvelope
        {
            public List<ManufacturerDto> Manufacturers { get; set; }
            public int ManufacturersCount { get; set; }
        }
        public class Query : IRequest<ManufacturersEnvelope> 
        {
            public Query(int? limit, int? offset)
            {
                Limit = limit;
                Offset = offset;
            }
            public int? Limit { get; set; }
            public int? Offset { get; set; }
        }

        public class Handler : IRequestHandler<Query, ManufacturersEnvelope>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ManufacturersEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                // var manufacturers = await _context.Manufacturers.Select(m => m.Products.SelectMany(x => x.Products.Take(10).ToList())).ToListAsync();

                var queryable = _context.Manufacturers
                    .AsQueryable();

                // to limit 10 products against each manufacturer
                // foreach(var m in manufacturers)
                // {
                //     m.Products = m.Products.Take(10).ToList();
                // }

                var manufacturers = await queryable
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 3).ToListAsync();

                // return _mapper.Map<List<Manufacturer>, List<ManufacturerDto>>(manufacturers);
                return new ManufacturersEnvelope
                {
                    Manufacturers = _mapper.Map<List<Manufacturer>, List<ManufacturerDto>>(manufacturers),
                    ManufacturersCount = queryable.Count()
                };
            }
        }
    }
}